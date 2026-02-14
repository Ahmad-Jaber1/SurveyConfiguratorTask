using Microsoft.Data.SqlClient;
using Repository;
using Serilog;
using Shared;
using SurveyConfiguratorTask.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SurveyConfiguratorTask.Repo
{
    public class QuestionRepo
    {
        private  string? mConnectionString;
        public List<Question> Questions { get; set; }
        public QuestionRepo()
        {
            Questions = new List<Question>();
        }


        

        public Result<List<Question>> QuestionsLoad()
        {
            //var savedConnection = ConfigurationManager.ConnectionStrings["DbConnectionString"]?.ConnectionString;
            var tResult = new Result<List<Question>>() {Success = true , Error = ErrorTypeEnum.None ,Data = Questions };
            if (string.IsNullOrWhiteSpace(mConnectionString))
            {
                Log.Error("Attempted to load questions but the database connection string is not set. ");
                return new Result<List<Question>>
                {
                    Success = false,
                    Error = ErrorTypeEnum.ConnectionStringNotSet,
                    
                };
            }

            try
            {
                Questions.Clear();

                // Load Slider Questions
                var tSliderResult = SliderQuestionsLoad(mConnectionString);
                if (!tSliderResult.Success)
                {
                    Log.Error("Failed to load slider questions: {Message}", tSliderResult.Message);
                    return new Result<List<Question>>
                    {
                        Success = false,
                        Error = tSliderResult.Error,
                        Message = tSliderResult.Message
                    };
                }
                Questions.AddRange(tSliderResult.Data);
                

                // Load Smiley Questions
                var tSmileyResult = SmileyQuestionsLoad(mConnectionString);
                if (!tSmileyResult.Success)
                {
                    Log.Error("Failed to load smiley questions: {Message}", tSmileyResult.Message);
                    return new Result<List<Question>>
                    {
                        Success = false,
                        Error = tSmileyResult.Error,
                        Message = tSmileyResult.Message
                    };
                }
                Questions.AddRange(tSmileyResult.Data);


                // Load Stars Questions
                var tStarsResult = StarsQuestionsLoad(mConnectionString);
                if (!tStarsResult.Success)
                {
                    Log.Error("Failed to load star questions: {Message}", tStarsResult.Message);
                    return new Result<List<Question>>
                    {
                        Success = false,
                        Error = tStarsResult.Error,
                        Message = tStarsResult.Message
                    };
                }
                Questions.AddRange(tStarsResult.Data);

            }
            catch (Exception ex)
            {
                return new Result<List<Question>>
                {
                    Success = false,
                    Error = ErrorTypeEnum.UnknownErrorQuestionsLoad,
                    Message = "Unexpected error occurred while loading questions."
                };
            }
            return tResult; 
        }
        public Result<List<Question>> SliderQuestionsLoad(string pConnectionString)
        {
            var tResult = new Result<List<Question>> { Success = true, Error = ErrorTypeEnum.None };
            var tQuestions = new List<Question>();

            try
            {
                using (var tConnection = new SqlConnection(pConnectionString))
                using (var tCommand = tConnection.CreateCommand())
                {
                    tCommand.CommandText = $"SELECT {DbConsts.QuestionsSelectColumns}, {DbConsts.SliderSelectColumns} " +
                                      $"FROM {DbConsts.QuestionsTableName} " +
                                      $"INNER JOIN {DbConsts.SliderTableName} " +
                                      $"ON {DbConsts.QuestionsTableName}.{DbConsts.QuestionsId} = {DbConsts.SliderTableName}.{DbConsts.SliderId}";

                    tConnection.Open();
                    using (var tReader = tCommand.ExecuteReader())
                    {
                        while (tReader.Read())
                        {
                            tQuestions.Add(new SliderQuestion(
                                Convert.ToInt32(tReader[DbConsts.QuestionsId]),
                                tReader[DbConsts.QuestionsQuestionText].ToString(),
                                Convert.ToInt32(tReader[DbConsts.QuestionsQuestionOrder]),
                                Convert.ToInt32(tReader[DbConsts.SliderStartValue]),
                                Convert.ToInt32(tReader[DbConsts.SliderEndValue]),
                                tReader[DbConsts.SliderStartCaption].ToString(),
                                tReader[DbConsts.SliderEndCaption].ToString()
                            ));
                        }
                    }
                    tConnection.Close();
                }

                tResult.Data = tQuestions;
            }
            catch (SqlException sqlEx)
            {
                tResult.Success = false;
                tResult.Message = "SQL error occurred while loading slider questions.";
                tResult.Error = ErrorTypeEnum.SqlErrorSliderLoad;
                Log.Error(sqlEx, "SQL error while loading slider questions.");
            }
            catch (Exception ex)
            {
                tResult.Success = false;
                tResult.Message = "Unexpected error occurred while loading slider questions.";
                tResult.Error = ErrorTypeEnum.UnknownErrorSliderLoad;
                Log.Error(ex, "Unexpected error while loading slider questions.");
            }

            return tResult;
        }
        public Result<List<Question>> SmileyQuestionsLoad(string pConnectionString)
        {
            var tResult = new Result<List<Question>> { Success = true, Error = ErrorTypeEnum.None };
            var tQuestions = new List<Question>();

            try
            {
                using (var tConnection = new SqlConnection(pConnectionString))
                using (var tCommand = tConnection.CreateCommand())
                {
                    tCommand.CommandText = $"SELECT {DbConsts.QuestionsSelectColumns}, {DbConsts.SmileySelectColumns} " +
                                      $"FROM {DbConsts.QuestionsTableName} " +
                                      $"INNER JOIN {DbConsts.SmileyTableName} " +
                                      $"ON {DbConsts.QuestionsTableName}.{DbConsts.QuestionsId} = {DbConsts.SmileyTableName}.{DbConsts.SmileyId}";

                    tConnection.Open();
                    using (var tReader = tCommand.ExecuteReader())
                    {
                        while (tReader.Read())
                        {
                            tQuestions.Add(new SmileyFacesQuestion(
                                Convert.ToInt32(tReader[DbConsts.QuestionsId]),
                                tReader[DbConsts.QuestionsQuestionText].ToString(),
                                Convert.ToInt32(tReader[DbConsts.QuestionsQuestionOrder]),
                                Convert.ToInt32(tReader[DbConsts.SmileySmileyCount])
                            ));
                        }
                    }
                    tConnection.Close();
                }

                tResult.Data = tQuestions;
            }
            catch (SqlException sqlEx)
            {
                tResult.Success = false;
                tResult.Message = "SQL error occurred while loading smiley questions.";
                tResult.Error = ErrorTypeEnum.SqlErrorSmileyLoad;
                Log.Error(sqlEx, "SQL error while loading smiley questions.");
            }
            catch (Exception ex)
            {
                tResult.Success = false;
                tResult.Message = "Unexpected error occurred while loading smiley questions.";
                tResult.Error = ErrorTypeEnum.UnknownErrorSmileyLoad;
                Log.Error(ex, "Unexpected error while loading smiley questions.");
            }

            return tResult;
        }
        public Result<List<Question>> StarsQuestionsLoad(string pConnectionString)
        {
            var tResult = new Result<List<Question>> { Success = true, Error = ErrorTypeEnum.None };
            var tQuestions = new List<Question>();

            try
            {
                using (var tConnection = new SqlConnection(pConnectionString))
                using (var tCommand = tConnection.CreateCommand())
                {
                    tCommand.CommandText = $"SELECT {DbConsts.QuestionsSelectColumns}, {DbConsts.StarsSelectColumns} " +
                                      $"FROM {DbConsts.QuestionsTableName} " +
                                      $"INNER JOIN {DbConsts.StarsTableName} " +
                                      $"ON {DbConsts.QuestionsTableName}.{DbConsts.QuestionsId} = {DbConsts.StarsTableName}.{DbConsts.StarsId}";

                    tConnection.Open();
                    using (var tReader = tCommand.ExecuteReader())
                    {
                        while (tReader.Read())
                        {
                            tQuestions.Add(new StarsQuestion(
                                Convert.ToInt32(tReader[DbConsts.QuestionsId]),
                                tReader[DbConsts.QuestionsQuestionText].ToString(),
                                Convert.ToInt32(tReader[DbConsts.QuestionsQuestionOrder]),
                                Convert.ToInt32(tReader[DbConsts.StarsStarsCount])
                            ));
                        }
                    }
                    tConnection.Close();
                }

                tResult.Data = tQuestions;
            }
            catch (SqlException sqlEx)
            {
                tResult.Success = false;
                tResult.Message = "SQL error occurred while loading star questions.";
                tResult.Error = ErrorTypeEnum.SqlErrorStarsLoad;
                Log.Error(sqlEx, "SQL error while loading star questions.");
            }
            catch (Exception ex)
            {
                tResult.Success = false;
                tResult.Message = "Unexpected error occurred while loading star questions.";
                tResult.Error = ErrorTypeEnum.UnknownErrorStarsLoad;
                Log.Error(ex, "Unexpected error while loading star questions.");
            }

            return tResult;
        }
        public Result<int> AddQuestion(Question pQuestion)
        {
            Result<int> tResult = new Result<int>
            {
                Success = true,
                Error = ErrorTypeEnum.None
            };

            try
            {
                using (var tConnection = new SqlConnection(mConnectionString))
                {
                    tConnection.Open();

                    using (var tTransaction = tConnection.BeginTransaction())
                    {
                        try
                        {
                            using (var tCommand = tConnection.CreateCommand())
                            {
                                tCommand.Transaction = tTransaction;

                                // 1. Insert into Questions (Id is auto-generated)
                                tCommand.CommandText = $"INSERT INTO {DbConsts.QuestionsTableName} " +
                                                  $"({DbConsts.QuestionsQuestionText}, {DbConsts.QuestionsQuestionOrder}, {DbConsts.QuestionsQuestionType}) " +
                                                  $"VALUES (@{DbConsts.QuestionsQuestionText}, @{DbConsts.QuestionsQuestionOrder}, @{DbConsts.QuestionsQuestionType}); " +
                                                  "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                                tCommand.Parameters.Add($"@{DbConsts.QuestionsQuestionText}", SqlDbType.NVarChar,60).Value = pQuestion.Text;
                                tCommand.Parameters.Add($"@{DbConsts.QuestionsQuestionOrder}", SqlDbType.Int).Value = pQuestion.Order;
                                tCommand.Parameters.Add($"@{DbConsts.QuestionsQuestionType}", SqlDbType.Int).Value = (int)pQuestion.TypeQuestion;

                                // Get the generated Question Id
                                int tQuestionId = (int)tCommand.ExecuteScalar();

                                // 2. Insert into the specific question type table
                                tCommand.Parameters.Clear(); 

                                switch (pQuestion.TypeQuestion)
                                {
                                    case TypeQuestionEnum.SliderQuestion:
                                        var tSliderQuestion = (SliderQuestion)pQuestion;
                                        tCommand.CommandText = $"INSERT INTO {DbConsts.SliderTableName} " +
                                                          $"({DbConsts.SliderId}, {DbConsts.SliderStartValue}, {DbConsts.SliderEndValue}, {DbConsts.SliderStartCaption}, {DbConsts.SliderEndCaption}) " +
                                                          $"VALUES (@Id, @StartValue, @EndValue, @StartCaption, @EndCaption)";
                                        tCommand.Parameters.Add("@Id", SqlDbType.Int).Value = tQuestionId;
                                        tCommand.Parameters.Add("@StartValue", SqlDbType.Int).Value = tSliderQuestion.StartValue;
                                        tCommand.Parameters.Add("@EndValue", SqlDbType.Int).Value = tSliderQuestion.EndValue;
                                        tCommand.Parameters.Add("@StartCaption", SqlDbType.NVarChar,30).Value = tSliderQuestion.StartCaption;
                                        tCommand.Parameters.Add("@EndCaption", SqlDbType.NVarChar,30).Value = tSliderQuestion.EndCaption;
                                        break;

                                    case TypeQuestionEnum.SmileyFacesQuestion:
                                        var tSmileyFaceQuestion = (SmileyFacesQuestion)pQuestion;
                                        tCommand.CommandText = $"INSERT INTO {DbConsts.SmileyTableName} " +
                                                          $"({DbConsts.SmileyId}, {DbConsts.SmileySmileyCount}) " +
                                                          $"VALUES (@Id, @SmileyCount)";
                                        tCommand.Parameters.Add("@Id", SqlDbType.Int).Value = tQuestionId;
                                        tCommand.Parameters.Add("@SmileyCount", SqlDbType.Int).Value = tSmileyFaceQuestion.SmileyCount;
                                        break;

                                    case TypeQuestionEnum.StarsQuestion:
                                        var tStarsQuestion = (StarsQuestion)pQuestion;
                                        tCommand.CommandText = $"INSERT INTO {DbConsts.StarsTableName} " +
                                                          $"({DbConsts.StarsId}, {DbConsts.StarsStarsCount}) " +
                                                          $"VALUES (@Id, @StarsCount)";
                                        tCommand.Parameters.Add("@Id", SqlDbType.Int).Value = tQuestionId;
                                        tCommand.Parameters.Add("@StarsCount", SqlDbType.Int).Value = tStarsQuestion.StarsCount;
                                        break;

                                    default:
                                        throw new Exception("Unsupported question type.");
                                }

                                // Execute the insert for the child table
                                tCommand.ExecuteNonQuery();

                                // Commit transaction
                                tTransaction.Commit();

                                // Return the generated question Id
                                tResult.Data = tQuestionId;
                            }
                        }
                        catch (SqlException sqlEx)
                        {
                            tTransaction.Rollback();
                            tResult.Success = false;
                            tResult.Message = "We couldn't save your question at the moment. Please try again later.";
                            tResult.Error = ErrorTypeEnum.SqlErrorAddQuestion;
                            Log.Error(sqlEx, "SQL error occurred while inserting question of type {Type}", pQuestion.TypeQuestion);
                        }
                        catch (Exception ex)
                        {
                            tTransaction.Rollback();
                            tResult.Success = false;
                            tResult.Message = "Unexpected error occurred while adding question.";
                            tResult.Error = ErrorTypeEnum.UnknownErrorAddQuestion;
                            Log.Error(ex, "Unexpected error occurred while inserting question of type {Type}", pQuestion.TypeQuestion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                tResult.Success = false;
                tResult.Message = "Failed to connect to the database. Contact the administrator to resolve the issue.";
                tResult.Error = ErrorTypeEnum.DatabaseConnectionFailed;
                Log.Error(ex, "Database connection failed.");
            }

            return tResult;
        }
        public Result<object> DeleteQuestion(int pId)
        {
            Result<object> tResult = new Result<object>();
            tResult.Success = true;
            tResult.Error = ErrorTypeEnum.None;
            try
            {
                using (var tConnection = new SqlConnection(mConnectionString))
                {
                    using (var tCommand = tConnection.CreateCommand())
                    {
                        tCommand.CommandText = $"DELETE FROM {DbConsts.QuestionsTableName} WHERE {DbConsts.QuestionsId} = @{DbConsts.QuestionsId}";
                        tCommand.Parameters.Add($"@{DbConsts.QuestionsId}", System.Data.SqlDbType.Int).Value = pId;


                        tConnection.Open();
                        tCommand.ExecuteNonQuery();



                    }


                }
            }
            catch (SqlException sqlEx)
            {

                tResult.Success = false;
                tResult.Message = "We couldn't delete your question at the moment. Please try again later.";
                tResult.Error = ErrorTypeEnum.SqlErrorDeleteQuestion;
                Log.Error(sqlEx, "SQL error occurred while deleting question ,Id: {Id}", pId);
            }
            catch (Exception ex)
            {
                tResult.Success = false;
                tResult.Message = "We couldn't delete your question due to an unexpected error. Please try again or contact support.";
                tResult.Error = ErrorTypeEnum.UnknownErrorDeleteQuestion;
                Log.Error(ex, "Unexpected error occurred while deleting question. QuestionId: {Id}", pId);

            }
            return tResult; 
        }
        public Result<int> EditQuestion(Question pQuestion)
        {
           Result<int> tResult = new Result<int>() ;
            tResult.Success= true ;
            tResult.Error = ErrorTypeEnum.None;
            tResult.Data = 0;
            try
            {
                using (var tConnection = new SqlConnection(mConnectionString))
                {
                    tConnection.Open();

                    using (var tTransaction = tConnection.BeginTransaction())
                    {


                        try
                        {
                            using (var tCommand = tConnection.CreateCommand())
                            {
                                //edit object data in general question table in database 
                                tCommand.CommandText = $"UPDATE {DbConsts.QuestionsTableName} " +
                                    $"SET {DbConsts.QuestionsQuestionText} = @{DbConsts.QuestionsQuestionText} " +
                                    $"WHERE {DbConsts.QuestionsTableName}.{DbConsts.QuestionsId} = @{DbConsts.QuestionsId}";
                                tCommand.Parameters.Add($"@{DbConsts.QuestionsId}", System.Data.SqlDbType.Int).Value = pQuestion.Id;
                                tCommand.Parameters.Add($"@{DbConsts.QuestionsQuestionText}", System.Data.SqlDbType.NVarChar,60).Value = pQuestion.Text;
                                tCommand.Transaction = tTransaction;
                                tCommand.ExecuteNonQuery();

                                //edit object data in specific question type 
                                switch (pQuestion.TypeQuestion)
                                {
                                    case TypeQuestionEnum.SliderQuestion:
                                        tCommand.CommandText = $"UPDATE {DbConsts.SliderTableName} " +
                                            $"SET {DbConsts.SliderStartValue} = @{DbConsts.SliderStartValue} ," +
                                            $"{DbConsts.SliderEndValue} = @{DbConsts.SliderEndValue} " +
                                            $", {DbConsts.SliderStartCaption} =@{DbConsts.SliderStartCaption} " +
                                            $", {DbConsts.SliderEndCaption} = @{DbConsts.SliderEndCaption}" +
                                            $" WHERE {DbConsts.SliderTableName}.{DbConsts.SliderId} = @{DbConsts.SliderId} ";

                                        var tSliderQuestion = (SliderQuestion)pQuestion;
                                        tCommand.Parameters.Add($"@{DbConsts.SliderStartValue}", System.Data.SqlDbType.Int).Value = tSliderQuestion.StartValue;
                                        tCommand.Parameters.Add($"@{DbConsts.SliderEndValue}", System.Data.SqlDbType.Int).Value = tSliderQuestion.EndValue;
                                        tCommand.Parameters.Add($"@{DbConsts.SliderStartCaption}", System.Data.SqlDbType.NVarChar,30).Value = tSliderQuestion.StartCaption;
                                        tCommand.Parameters.Add($"@{DbConsts.SliderEndCaption}", System.Data.SqlDbType.NVarChar,30).Value = tSliderQuestion.EndCaption;



                                        break;
                                    case TypeQuestionEnum.SmileyFacesQuestion:
                                        tCommand.CommandText = $"UPDATE {DbConsts.SmileyTableName} " +
                                            $"SET {DbConsts.SmileySmileyCount} = @{DbConsts.SmileySmileyCount} " +
                                            $"WHERE {DbConsts.SmileyTableName}.{DbConsts.SmileyId} = @{DbConsts.SmileyId} ";
                                        var tSmileyFaceQuestion = (Models.SmileyFacesQuestion)pQuestion;
                                        tCommand.Parameters.Add($"@{DbConsts.SmileySmileyCount}", System.Data.SqlDbType.Int).Value = tSmileyFaceQuestion.SmileyCount;

                                        break;
                                    case TypeQuestionEnum.StarsQuestion:
                                        tCommand.CommandText = $"UPDATE {DbConsts.StarsTableName} " +
                                            $"SET {DbConsts.StarsStarsCount} = @{DbConsts.StarsStarsCount} " +
                                            $"WHERE {DbConsts.StarsTableName}.{DbConsts.StarsId} = @{DbConsts.StarsId} ";
                                        var tStarsQuestion = (StarsQuestion)pQuestion;
                                        tCommand.Parameters.Add($"@{DbConsts.StarsStarsCount}", System.Data.SqlDbType.Int).Value = tStarsQuestion.StarsCount;

                                        break;

                                }
                                tCommand.ExecuteNonQuery();


                            }
                            tTransaction.Commit();
                            tConnection.Close();

                        }
                        catch (SqlException ex)
                        {
                            tTransaction.Rollback();
                            tResult.Success = false;
                            tResult.Message = "We couldn't update your question at the moment. Please try again later.";
                            tResult.Error = ErrorTypeEnum.SqlErrorUpdateLastModified;
                            Log.Error(ex, "SQL error occurred while updating question. QuestionId: {Id}", pQuestion.Id);
                        }
                        catch (Exception ex)
                        {
                            tTransaction.Rollback();
                            tResult.Success = false;
                            tResult.Message = "Unexpected error occurred while adding question.";
                            tResult.Error = ErrorTypeEnum.UnknownErrorUpdateLastModified;
                            Log.Error(ex, "Unexpected error occurred while inserting question of type {Type}", pQuestion.TypeQuestion);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                tResult.Success = false;
                tResult.Message = "Failed to connect to the database. Contact the administrator to resolve the issue.";
                tResult.Error = ErrorTypeEnum.DatabaseConnectionFailed;
                Log.Error(ex, "Database connection failed.");
            }
            return tResult; 
        }
        public Result<int> EditOrder(List<int> pIds, List<int> pOrders)
        {
            Result<int> tResult = new Result<int>();
            tResult.Success = true;
            tResult.Error = ErrorTypeEnum.None;

            try
            {
                using (var tConnection = new SqlConnection(mConnectionString))
                {

                    tConnection.Open();

                    using (var tTransaction = tConnection.BeginTransaction())
                    {
                        try
                        {
                            //edit order of all questions based on indexes in local list .
                            using (var cmd = tConnection.CreateCommand())
                            {
                                var tStringBuilder = new StringBuilder();
                                tStringBuilder.Append($"UPDATE {DbConsts.QuestionsTableName} SET {DbConsts.QuestionsQuestionOrder} = CASE {DbConsts.QuestionsId} ");
                                for (int i = 0; i < pIds.Count; i++)
                                {
                                    tStringBuilder.Append($"WHEN '{pIds[i]}' THEN {pOrders[i]}\n");
                                }
                                tStringBuilder.Append($"\n END WHERE {DbConsts.QuestionsId} IN (");

                                for (int i = 0; i < pIds.Count - 1; i++)
                                    tStringBuilder.Append($"'{pIds[i]}',");
                                tStringBuilder.Append($"'{pIds[pIds.Count - 1]}'");

                                tStringBuilder.Append(");");
                                cmd.CommandText = tStringBuilder.ToString();
                                cmd.Transaction = tTransaction;
                                cmd.ExecuteNonQuery();
                                tTransaction.Commit();
                                tConnection.Close();
                            }

                        }

                        catch (SqlException ex)
                        {
                            tTransaction.Rollback();
                            tResult.Success = false;
                            tResult.Message = "We couldn't update order at the moment. Please try again later.";
                            tResult.Error = ErrorTypeEnum.SqlErrorEditOrder;
                            Log.Error(ex, "SQL error occurred while updating order. ");
                        }
                        catch (Exception ex)
                        {
                            tTransaction.Rollback();
                            tResult.Success = false;
                            tResult.Message = "Unexpected error occurred while update order.";
                            tResult.Error = ErrorTypeEnum.UnknownErrorEditOrder;
                            Log.Error(ex, "Unexpected error occurred while updating order ");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                tResult.Success = false;
                tResult.Message = "Failed to connect to the database. Contact the administrator to resolve the issue.";
                tResult.Error = ErrorTypeEnum.DatabaseConnectionFailed;
                Log.Error(ex, "Database connection failed.");
            }
            return tResult;
        }
        public Result<int> GetCount()
        {
            Result<int> tResult = new Result<int> { Success = true , Error = ErrorTypeEnum.None , Data = 0};
            int tQuestionCount;
            try
            {
                // Get count of question in database 
                using (var tConnection = new SqlConnection(mConnectionString))
                {
                    using (var tCommand = tConnection.CreateCommand())
                    {
                        tCommand.CommandText = $"SELECT COUNT({DbConsts.QuestionsId}) FROM Questions";



                        tConnection.Open();
                        var tReader = tCommand.ExecuteReader();
                        tReader.Read();
                        tQuestionCount = Convert.ToInt32(tReader[0]);
                        tResult.Data = tQuestionCount;


                    }


                }
            }
            catch (SqlException sqlEx)
            {

                tResult.Success = false;
                tResult.Message = "We couldn't retrieve the question count at the moment. Please try again later.";
                tResult.Error = ErrorTypeEnum.SqlErrorGetCount;
                Log.Error(sqlEx, "SQL error occurred while retrieving question count.");
            }
            catch (Exception ex)
            {
                tResult.Success = false;
                tResult.Message = "We couldn't retrieve the question count due to an unexpected error. Please contact support.";
                tResult.Error = ErrorTypeEnum.UnknownErrorGetCount;
                Log.Error(ex, "Unexpected error occurred while retrieving question count.");
            
            }
            return tResult;
        }
        public Result<Question> GetQuestion(int pId)
        {
            Result<Question> tResult = new Result<Question> { Success = true, Error = ErrorTypeEnum.None };
            
                //Get question object (general and specific type information ) based on Id 
                using (var tConnection = new SqlConnection(mConnectionString))
                {
                    using (var tCommand = tConnection.CreateCommand())
                    {
                    Question tQuestion = null;

                    try
                    {

                        tCommand.CommandText = $"SELECT * FROM {DbConsts.QuestionsTableName} WHERE {DbConsts.QuestionsId} =@{DbConsts.QuestionsId}";
                        tCommand.Parameters.Add($"@{DbConsts.QuestionsId}", System.Data.SqlDbType.Int).Value = pId;

                        tConnection.Open();
                        var tReader = tCommand.ExecuteReader();
                        tReader.Read();

                        switch ((TypeQuestionEnum)tReader[DbConsts.QuestionsQuestionType])
                        {
                            case TypeQuestionEnum.SliderQuestion:
                                tConnection.Close();
                                tCommand.CommandText = $"SELECT {DbConsts.QuestionsTableName}.*,{DbConsts.SliderTableName}.* " +
                                    $"FROM {DbConsts.QuestionsTableName} INNER JOIN {DbConsts.SliderTableName}  " +
                                    $"ON {DbConsts.QuestionsTableName}.{DbConsts.QuestionsId} = @{DbConsts.QuestionsId} " +
                                    $"WHERE {DbConsts.QuestionsTableName}.{DbConsts.QuestionsId} = @{DbConsts.QuestionsId};";
                                tConnection.Open();

                                tReader = tCommand.ExecuteReader();
                                tReader.Read();
                                tQuestion = new SliderQuestion(
                                    (int)tReader[DbConsts.QuestionsId],
                                    (string)tReader[DbConsts.QuestionsQuestionText],
                                    (int)tReader[DbConsts.QuestionsQuestionOrder],
                                    (int)tReader[DbConsts.SliderStartValue],
                                    (int)tReader[DbConsts.SliderEndValue],
                                    (string)tReader[DbConsts.SliderStartCaption],
                                    (string)tReader[DbConsts.SliderEndCaption]
                                    );
                                break;
                            case TypeQuestionEnum.SmileyFacesQuestion:
                                tConnection.Close();

                                tCommand.CommandText = $"SELECT {DbConsts.QuestionsTableName}.*,{DbConsts.SmileyTableName}.* FROM {DbConsts.QuestionsTableName} " +
                                    $"INNER JOIN {DbConsts.SmileyTableName}  ON {DbConsts.QuestionsTableName}.{DbConsts.QuestionsId}= @{DbConsts.QuestionsId} " +
                                    $"WHERE {DbConsts.QuestionsTableName}.{DbConsts.QuestionsId} = @{DbConsts.QuestionsId};";
                                tConnection.Open();

                                tReader = tCommand.ExecuteReader();
                                tReader.Read();
                                tQuestion = new Models.SmileyFacesQuestion(
                                    (int)tReader[DbConsts.QuestionsId],
                                    (string)tReader[DbConsts.QuestionsQuestionText],
                                    (int)tReader[DbConsts.QuestionsQuestionOrder],
                                    (int)tReader[DbConsts.SmileySmileyCount]
                                    );
                                break;
                            case TypeQuestionEnum.StarsQuestion:
                                tConnection.Close();

                                tCommand.CommandText = $"SELECT {DbConsts.QuestionsTableName}.*,{DbConsts.StarsTableName}.* FROM {DbConsts.QuestionsTableName} " +
                                    $"INNER JOIN {DbConsts.StarsTableName}  ON  {DbConsts.QuestionsTableName}.{DbConsts.QuestionsId}= @{DbConsts.QuestionsId}" +
                                    $"   WHERE {DbConsts.QuestionsTableName}.{DbConsts.QuestionsId} = @{DbConsts.QuestionsId};";
                                tConnection.Open();

                                tReader = tCommand.ExecuteReader();
                                tReader.Read();
                                tQuestion = new StarsQuestion(
                                    (int)tReader[DbConsts.QuestionsId],
                                    (string)tReader[DbConsts.QuestionsQuestionText],
                                    (int)tReader[DbConsts.QuestionsQuestionOrder],
                                    (int)tReader[DbConsts.StarsStarsCount]
                                    );
                                break;
                        }
                        tResult.Data = tQuestion; 
                        
                    }
                    catch (SqlException sqlEx)
                    {

                        tResult.Success = false;
                        tResult.Message = "We couldn't retrieve the question . Please try again later.";
                        tResult.Error = ErrorTypeEnum.SqlErrorGetQuestion;
                        Log.Error(sqlEx, "SQL error occurred while retrieving question with Id {id}." , tQuestion.Id);
                    }
                    catch (Exception ex)
                    {
                        tResult.Success = false;
                        tResult.Message = "We couldn't retrieve the question count due to an unexpected error. Please contact support.";
                        tResult.Error = ErrorTypeEnum.UnknownErrorGetQuestion;
                        Log.Error(ex, "Unexpected error occurred while retrieving question with Id {id}." , tQuestion.Id);

                    }
                    return tResult;

                }

        }
            
            
        }
        public Result<DateTime> GetLastModified()
        {
            Result<DateTime> tResult = new Result<DateTime>()
            {
                Success = true,
                Error = ErrorTypeEnum.None,
                
            };
            //Questions = new List<Question>();
           

            using (var tConnection = new SqlConnection(mConnectionString))
            {
                using (var tCommand = tConnection.CreateCommand())
                {


                    try
                    {
                        tCommand.CommandText = $"SELECT * FROM {DbConsts.DatabaseChangeTableName}";

                        tConnection.Open();
                        var tReader = tCommand.ExecuteReader();
                        tReader.Read();
                        DateTime tLastModified = (DateTime)tReader[0];
                        tResult.Data = tLastModified;
                        return tResult;
                    }
                    catch (SqlException sqlEx)
                    {

                        tResult.Success = false;
                        tResult.Message = "We couldn't retrieve Last Modified . Please try again later.";
                        tResult.Error = ErrorTypeEnum.SqlErrorGetLastModified;
                        Log.Error(sqlEx, "SQL error occurred while retrieving Last Modified .");
                    }
                    catch (Exception ex)
                    {
                        tResult.Success = false;
                        tResult.Message = "We couldn't retrieve Last Modified due to an unexpected error. Please contact support.";
                        tResult.Error = ErrorTypeEnum.UnknownErrorGetLastModified;
                        //Log.Error(ex, "Unexpected error occurred while retrieving Last Modified.");

                    }
                    return tResult; 
                }


            }
        }
        public Result<int> UpdateLastModified()
        {
            Questions = new List<Question>();
            Result<int> tResult = new Result<int>() 
            { 
                Success = true, 
                Error = ErrorTypeEnum.None,

            };  

            using (var tConnection = new SqlConnection(mConnectionString))
            {
                using (var tCommand = tConnection.CreateCommand())
                {
                    try
                    {
                        tCommand.CommandText = $"UPDATE {DbConsts.DatabaseChangeTableName} SET {DbConsts.DatabaseChangeLastModified}= SYSDATETIME();";
                        tConnection.Open();
                        tCommand.ExecuteNonQuery();
                        
                    }
                    catch (SqlException sqlEx)
                    {

                        tResult.Success = false;
                        tResult.Message = "We couldn't update Last Modified . Please try again later.";
                        tResult.Error = ErrorTypeEnum.SqlErrorUpdateLastModified;
                        Log.Error(sqlEx, "SQL error occurred while updating Last Modified .");
                    }
                    catch (Exception ex)
                    {
                        tResult.Success = false;
                        tResult.Message = "We couldn't update Last Modified due to an unexpected error. Please contact support.";
                        tResult.Error = ErrorTypeEnum.UnknownErrorUpdateLastModified;
                        Log.Error(ex, "Unexpected error occurred while updating Last Modified.");

                    }
                    return tResult;
                }
            }
        }
        public Result<bool> ChangeConnectionString(string pConnectionString)
        {
            var tResult = new Result<bool>
            {
                Success = true,
                Error = ErrorTypeEnum.None
            };

            try
            {
                Exception tExceptionError;
                var tTestResult = SqlConnectionTest.TestConnection(pConnectionString, out tExceptionError);
                if (!tTestResult.Success)
                {
                    Log.Error(tExceptionError, "Failed to set connection string.");
                    tResult.Success = false;
                    tResult.Error = ErrorTypeEnum.ConnectionStringInvalid;
                    tResult.Message = "Cannot connect to the database. Please check your server name, database name, username, and password.";
                    return tResult;
                }

                mConnectionString = pConnectionString;
                Configuration tConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                tConfig.ConnectionStrings.ConnectionStrings["DbConnectionString"].ConnectionString = pConnectionString;
                tConfig.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");

                tResult.Data = true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while changing the connection string.");
                tResult.Success = false;
                tResult.Message = "We couldn't change connection string due to an unexpected error. Please contact support.";
                tResult.Error = ErrorTypeEnum.UnknownErrorChangeConnectionString;
            }

            return tResult;
        }

        public Result<bool> ConnectoinTest(string pConnectionString)
        {
            var tResult = new Result<bool>
            {
                Success = true,
                Error = ErrorTypeEnum.None
            };

            try
            {
                Exception tExceptionError;
                var tTestResult = SqlConnectionTest.TestConnection(pConnectionString, out tExceptionError);
                if (!tTestResult.Success)
                {
                    Log.Error(tExceptionError, "Failed connection test.");
                    tResult.Success = false;
                    tResult.Error = ErrorTypeEnum.ConnectionStringInvalid;
                    tResult.Message = "Cannot connect to the database. Please check your server name, database name, username, and password.";
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while testing connection.");
                tResult.Success = false;
                tResult.Message = "We couldn't test connection  due to an unexpected error. Please contact support.";
                tResult.Error = ErrorTypeEnum.UnknownErrorConnectionTest;
            }

            return tResult;
        }

        public Result<string> GetConnectionString()
        {
            try
            {
                return new Result<string>
                {
                    Data = mConnectionString,
                    Success = true,
                    Error = ErrorTypeEnum.None
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unexpected error occurred while getting connection string.");
                return new Result<string>
                {
                    Success = false,
                    Error = ErrorTypeEnum.UnknownErrorGetConnectionString,
                    Message = "We couldn't retrieve the connection string due to an unexpected error. Please contact support."
                };
            }
        }


    }


}