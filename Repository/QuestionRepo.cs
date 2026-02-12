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
                    Error = ErrorTypeEnum.ConnectionStringError,
                    Message = "Database connection string is not set. \n Go to Settings → Database Connection to set it up."
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
                    Error = ErrorTypeEnum.UnknownError,
                    Message = ex.Message
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
                    tCommand.CommandText = $"SELECT {QuestionsTable.SelectColumns}, {SliderTable.SelectColumns} " +
                                      $"FROM {QuestionsTable.TableName} " +
                                      $"INNER JOIN {SliderTable.TableName} " +
                                      $"ON {QuestionsTable.TableName}.{QuestionsTable.Id} = {SliderTable.TableName}.{SliderTable.Id}";

                    tConnection.Open();
                    using (var tReader = tCommand.ExecuteReader())
                    {
                        while (tReader.Read())
                        {
                            tQuestions.Add(new SliderQuestion(
                                Convert.ToInt32(tReader[QuestionsTable.Id]),
                                tReader[QuestionsTable.QuestionText].ToString(),
                                Convert.ToInt32(tReader[QuestionsTable.QuestionOrder]),
                                Convert.ToInt32(tReader[SliderTable.StartValue]),
                                Convert.ToInt32(tReader[SliderTable.EndValue]),
                                tReader[SliderTable.StartCaption].ToString(),
                                tReader[SliderTable.EndCaption].ToString()
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
                tResult.Error = ErrorTypeEnum.SqlError;
                Log.Error(sqlEx, "SQL error while loading slider questions.");
            }
            catch (Exception ex)
            {
                tResult.Success = false;
                tResult.Message = "Unexpected error occurred while loading slider questions.";
                tResult.Error = ErrorTypeEnum.UnknownError;
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
                    tCommand.CommandText = $"SELECT {QuestionsTable.SelectColumns}, {SmileyFacesTable.SelectColumns} " +
                                      $"FROM {QuestionsTable.TableName} " +
                                      $"INNER JOIN {SmileyFacesTable.TableName} " +
                                      $"ON {QuestionsTable.TableName}.{QuestionsTable.Id} = {SmileyFacesTable.TableName}.{SmileyFacesTable.Id}";

                    tConnection.Open();
                    using (var tReader = tCommand.ExecuteReader())
                    {
                        while (tReader.Read())
                        {
                            tQuestions.Add(new SmileyFacesQuestion(
                                Convert.ToInt32(tReader[QuestionsTable.Id]),
                                tReader[QuestionsTable.QuestionText].ToString(),
                                Convert.ToInt32(tReader[QuestionsTable.QuestionOrder]),
                                Convert.ToInt32(tReader[SmileyFacesTable.SmileyCount])
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
                tResult.Error = ErrorTypeEnum.SqlError;
                Log.Error(sqlEx, "SQL error while loading smiley questions.");
            }
            catch (Exception ex)
            {
                tResult.Success = false;
                tResult.Message = "Unexpected error occurred while loading smiley questions.";
                tResult.Error = ErrorTypeEnum.UnknownError;
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
                    tCommand.CommandText = $"SELECT {QuestionsTable.SelectColumns}, {StarsTable.SelectColumns} " +
                                      $"FROM {QuestionsTable.TableName} " +
                                      $"INNER JOIN {StarsTable.TableName} " +
                                      $"ON {QuestionsTable.TableName}.{QuestionsTable.Id} = {StarsTable.TableName}.{StarsTable.Id}";

                    tConnection.Open();
                    using (var tReader = tCommand.ExecuteReader())
                    {
                        while (tReader.Read())
                        {
                            tQuestions.Add(new StarsQuestion(
                                Convert.ToInt32(tReader[QuestionsTable.Id]),
                                tReader[QuestionsTable.QuestionText].ToString(),
                                Convert.ToInt32(tReader[QuestionsTable.QuestionOrder]),
                                Convert.ToInt32(tReader[StarsTable.StarsCount])
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
                tResult.Error = ErrorTypeEnum.SqlError;
                Log.Error(sqlEx, "SQL error while loading star questions.");
            }
            catch (Exception ex)
            {
                tResult.Success = false;
                tResult.Message = "Unexpected error occurred while loading star questions.";
                tResult.Error = ErrorTypeEnum.UnknownError;
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
                                tCommand.CommandText = $"INSERT INTO {QuestionsTable.TableName} " +
                                                  $"({QuestionsTable.QuestionText}, {QuestionsTable.QuestionOrder}, {QuestionsTable.QuestionType}) " +
                                                  $"VALUES (@{QuestionsTable.QuestionText}, @{QuestionsTable.QuestionOrder}, @{QuestionsTable.QuestionType}); " +
                                                  "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                                tCommand.Parameters.Add($"@{QuestionsTable.QuestionText}", SqlDbType.VarChar).Value = pQuestion.Text;
                                tCommand.Parameters.Add($"@{QuestionsTable.QuestionOrder}", SqlDbType.Int).Value = pQuestion.Order;
                                tCommand.Parameters.Add($"@{QuestionsTable.QuestionType}", SqlDbType.Int).Value = (int)pQuestion.TypeQuestion;

                                // Get the generated Question Id
                                int tQuestionId = (int)tCommand.ExecuteScalar();

                                // 2. Insert into the specific question type table
                                tCommand.Parameters.Clear(); 

                                switch (pQuestion.TypeQuestion)
                                {
                                    case TypeQuestionEnum.SliderQuestion:
                                        var tSliderQuestion = (SliderQuestion)pQuestion;
                                        tCommand.CommandText = $"INSERT INTO {SliderTable.TableName} " +
                                                          $"({SliderTable.Id}, {SliderTable.StartValue}, {SliderTable.EndValue}, {SliderTable.StartCaption}, {SliderTable.EndCaption}) " +
                                                          $"VALUES (@Id, @StartValue, @EndValue, @StartCaption, @EndCaption)";
                                        tCommand.Parameters.Add("@Id", SqlDbType.Int).Value = tQuestionId;
                                        tCommand.Parameters.Add("@StartValue", SqlDbType.Int).Value = tSliderQuestion.StartValue;
                                        tCommand.Parameters.Add("@EndValue", SqlDbType.Int).Value = tSliderQuestion.EndValue;
                                        tCommand.Parameters.Add("@StartCaption", SqlDbType.VarChar).Value = tSliderQuestion.StartCaption;
                                        tCommand.Parameters.Add("@EndCaption", SqlDbType.VarChar).Value = tSliderQuestion.EndCaption;
                                        break;

                                    case TypeQuestionEnum.SmileyFacesQuestion:
                                        var tSmileyFaceQuestion = (SmileyFacesQuestion)pQuestion;
                                        tCommand.CommandText = $"INSERT INTO {SmileyFacesTable.TableName} " +
                                                          $"({SmileyFacesTable.Id}, {SmileyFacesTable.SmileyCount}) " +
                                                          $"VALUES (@Id, @SmileyCount)";
                                        tCommand.Parameters.Add("@Id", SqlDbType.Int).Value = tQuestionId;
                                        tCommand.Parameters.Add("@SmileyCount", SqlDbType.Int).Value = tSmileyFaceQuestion.SmileyCount;
                                        break;

                                    case TypeQuestionEnum.StarsQuestion:
                                        var tStarsQuestion = (StarsQuestion)pQuestion;
                                        tCommand.CommandText = $"INSERT INTO {StarsTable.TableName} " +
                                                          $"({StarsTable.Id}, {StarsTable.StarsCount}) " +
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
                            tResult.Error = ErrorTypeEnum.SqlError;
                            Log.Error(sqlEx, "SQL error occurred while inserting question of type {Type}", pQuestion.TypeQuestion);
                        }
                        catch (Exception ex)
                        {
                            tTransaction.Rollback();
                            tResult.Success = false;
                            tResult.Message = "Unexpected error occurred while adding question.";
                            tResult.Error = ErrorTypeEnum.UnknownError;
                            Log.Error(ex, "Unexpected error occurred while inserting question of type {Type}", pQuestion.TypeQuestion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                tResult.Success = false;
                tResult.Message = "Failed to connect to the database. Contact the administrator to resolve the issue.";
                tResult.Error = ErrorTypeEnum.DatabaseError;
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
                        tCommand.CommandText = $"DELETE FROM {QuestionsTable.TableName} WHERE {QuestionsTable.Id} = @{QuestionsTable.Id}";
                        tCommand.Parameters.Add($"@{QuestionsTable.Id}", System.Data.SqlDbType.Int).Value = pId;


                        tConnection.Open();
                        tCommand.ExecuteNonQuery();



                    }


                }
            }
            catch (SqlException sqlEx)
            {

                tResult.Success = false;
                tResult.Message = "We couldn't delete your question at the moment. Please try again later.";
                tResult.Error = ErrorTypeEnum.SqlError;
                Log.Error(sqlEx, "SQL error occurred while deleting question ,Id: {Id}", pId);
            }
            catch (Exception ex)
            {
                tResult.Success = false;
                tResult.Message = "We couldn't delete your question due to an unexpected error. Please try again or contact support.";
                tResult.Error = ErrorTypeEnum.UnknownError;
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
                                tCommand.CommandText = $"UPDATE {QuestionsTable.TableName} " +
                                    $"SET {QuestionsTable.QuestionText} = @{QuestionsTable.QuestionText} " +
                                    $"WHERE {QuestionsTable.TableName}.{QuestionsTable.Id} = @{QuestionsTable.Id}";
                                tCommand.Parameters.Add($"@{QuestionsTable.Id}", System.Data.SqlDbType.Int).Value = pQuestion.Id;
                                tCommand.Parameters.Add($"@{QuestionsTable.QuestionText}", System.Data.SqlDbType.VarChar).Value = pQuestion.Text;
                                tCommand.Transaction = tTransaction;
                                tCommand.ExecuteNonQuery();

                                //edit object data in specific question type 
                                switch (pQuestion.TypeQuestion)
                                {
                                    case TypeQuestionEnum.SliderQuestion:
                                        tCommand.CommandText = $"UPDATE {SliderTable.TableName} " +
                                            $"SET {SliderTable.StartValue} = @{SliderTable.StartValue} ," +
                                            $"{SliderTable.EndValue} = @{SliderTable.EndValue} " +
                                            $", {SliderTable.StartCaption} =@{SliderTable.StartCaption} " +
                                            $", {SliderTable.EndCaption} = @{SliderTable.EndCaption}" +
                                            $" WHERE {SliderTable.TableName}.{SliderTable.Id} = @{SliderTable.Id} ";

                                        var tSliderQuestion = (SliderQuestion)pQuestion;
                                        tCommand.Parameters.Add($"@{SliderTable.StartValue}", System.Data.SqlDbType.Int).Value = tSliderQuestion.StartValue;
                                        tCommand.Parameters.Add($"@{SliderTable.EndValue}", System.Data.SqlDbType.Int).Value = tSliderQuestion.EndValue;
                                        tCommand.Parameters.Add($"@{SliderTable.StartCaption}", System.Data.SqlDbType.VarChar).Value = tSliderQuestion.StartCaption;
                                        tCommand.Parameters.Add($"@{SliderTable.EndCaption}", System.Data.SqlDbType.VarChar).Value = tSliderQuestion.EndCaption;



                                        break;
                                    case TypeQuestionEnum.SmileyFacesQuestion:
                                        tCommand.CommandText = $"UPDATE {SmileyFacesTable.TableName} " +
                                            $"SET {SmileyFacesTable.SmileyCount} = @{SmileyFacesTable.SmileyCount} " +
                                            $"WHERE {SmileyFacesTable.TableName}.{SmileyFacesTable.Id} = @{SmileyFacesTable.Id} ";
                                        var tSmileyFaceQuestion = (Models.SmileyFacesQuestion)pQuestion;
                                        tCommand.Parameters.Add($"@{SmileyFacesTable.SmileyCount}", System.Data.SqlDbType.Int).Value = tSmileyFaceQuestion.SmileyCount;

                                        break;
                                    case TypeQuestionEnum.StarsQuestion:
                                        tCommand.CommandText = $"UPDATE {StarsTable.TableName} " +
                                            $"SET {StarsTable.StarsCount} = @{StarsTable.StarsCount} " +
                                            $"WHERE {StarsTable.TableName}.{StarsTable.Id} = @{StarsTable.Id} ";
                                        var tStarsQuestion = (StarsQuestion)pQuestion;
                                        tCommand.Parameters.Add($"@{StarsTable.StarsCount}", System.Data.SqlDbType.Int).Value = tStarsQuestion.StarsCount;

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
                            tResult.Error = ErrorTypeEnum.SqlError;
                            Log.Error(ex, "SQL error occurred while updating question. QuestionId: {Id}", pQuestion.Id);
                        }
                        catch (Exception ex)
                        {
                            tTransaction.Rollback();
                            tResult.Success = false;
                            tResult.Message = "Unexpected error occurred while adding question.";
                            tResult.Error = ErrorTypeEnum.UnknownError;
                            Log.Error(ex, "Unexpected error occurred while inserting question of type {Type}", pQuestion.TypeQuestion);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                tResult.Success = false;
                tResult.Message = "Failed to connect to the database. Contact the administrator to resolve the issue.";
                tResult.Error = ErrorTypeEnum.DatabaseError;
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
                                tStringBuilder.Append($"UPDATE {QuestionsTable.TableName} SET {QuestionsTable.QuestionOrder} = CASE {QuestionsTable.Id} ");
                                for (int i = 0; i < pIds.Count; i++)
                                {
                                    tStringBuilder.Append($"WHEN '{pIds[i]}' THEN {pOrders[i]}\n");
                                }
                                tStringBuilder.Append($"\n END WHERE {QuestionsTable.Id} IN (");

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
                            tResult.Error = ErrorTypeEnum.SqlError;
                            Log.Error(ex, "SQL error occurred while updating order. ");
                        }
                        catch (Exception ex)
                        {
                            tTransaction.Rollback();
                            tResult.Success = false;
                            tResult.Message = "Unexpected error occurred while update order.";
                            tResult.Error = ErrorTypeEnum.UnknownError;
                            Log.Error(ex, "Unexpected error occurred while updating order ");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                tResult.Success = false;
                tResult.Message = "Failed to connect to the database. Contact the administrator to resolve the issue.";
                tResult.Error = ErrorTypeEnum.DatabaseError;
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
                        tCommand.CommandText = $"SELECT COUNT({QuestionsTable.Id}) FROM Questions";



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
                tResult.Error = ErrorTypeEnum.SqlError;
                Log.Error(sqlEx, "SQL error occurred while retrieving question count.");
            }
            catch (Exception ex)
            {
                tResult.Success = false;
                tResult.Message = "We couldn't retrieve the question count due to an unexpected error. Please contact support.";
                tResult.Error = ErrorTypeEnum.UnknownError;
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

                        tCommand.CommandText = $"SELECT * FROM {QuestionsTable.TableName} WHERE {QuestionsTable.Id} =@{QuestionsTable.Id}";
                        tCommand.Parameters.Add($"@{QuestionsTable.Id}", System.Data.SqlDbType.Int).Value = pId;

                        tConnection.Open();
                        var tReader = tCommand.ExecuteReader();
                        tReader.Read();

                        switch ((TypeQuestionEnum)tReader[QuestionsTable.QuestionType])
                        {
                            case TypeQuestionEnum.SliderQuestion:
                                tConnection.Close();
                                tCommand.CommandText = $"SELECT {QuestionsTable.TableName}.*,{SliderTable.TableName}.* " +
                                    $"FROM {QuestionsTable.TableName} INNER JOIN {SliderTable.TableName}  " +
                                    $"ON {QuestionsTable.TableName}.{QuestionsTable.Id} = @{QuestionsTable.Id} " +
                                    $"WHERE {QuestionsTable.TableName}.{QuestionsTable.Id} = @{QuestionsTable.Id};";
                                tConnection.Open();

                                tReader = tCommand.ExecuteReader();
                                tReader.Read();
                                tQuestion = new SliderQuestion(
                                    (int)tReader[QuestionsTable.Id],
                                    (string)tReader[QuestionsTable.QuestionText],
                                    (int)tReader[QuestionsTable.QuestionOrder],
                                    (int)tReader[SliderTable.StartValue],
                                    (int)tReader[SliderTable.EndValue],
                                    (string)tReader[SliderTable.StartCaption],
                                    (string)tReader[SliderTable.EndCaption]
                                    );
                                break;
                            case TypeQuestionEnum.SmileyFacesQuestion:
                                tConnection.Close();

                                tCommand.CommandText = $"SELECT {QuestionsTable.TableName}.*,{SmileyFacesTable.TableName}.* FROM {QuestionsTable.TableName} " +
                                    $"INNER JOIN {SmileyFacesTable.TableName}  ON {QuestionsTable.TableName}.{QuestionsTable.Id}= @{QuestionsTable.Id} " +
                                    $"WHERE {QuestionsTable.TableName}.{QuestionsTable.Id} = @{QuestionsTable.Id};";
                                tConnection.Open();

                                tReader = tCommand.ExecuteReader();
                                tReader.Read();
                                tQuestion = new Models.SmileyFacesQuestion(
                                    (int)tReader[QuestionsTable.Id],
                                    (string)tReader[QuestionsTable.QuestionText],
                                    (int)tReader[QuestionsTable.QuestionOrder],
                                    (int)tReader[SmileyFacesTable.SmileyCount]
                                    );
                                break;
                            case TypeQuestionEnum.StarsQuestion:
                                tConnection.Close();

                                tCommand.CommandText = $"SELECT {QuestionsTable.TableName}.*,{StarsTable.TableName}.* FROM {QuestionsTable.TableName} " +
                                    $"INNER JOIN {StarsTable.TableName}  ON  {QuestionsTable.TableName}.{QuestionsTable.Id}= @{QuestionsTable.Id}" +
                                    $"   WHERE {QuestionsTable.TableName}.{QuestionsTable.Id} = @{QuestionsTable.Id};";
                                tConnection.Open();

                                tReader = tCommand.ExecuteReader();
                                tReader.Read();
                                tQuestion = new StarsQuestion(
                                    (int)tReader[QuestionsTable.Id],
                                    (string)tReader[QuestionsTable.QuestionText],
                                    (int)tReader[QuestionsTable.QuestionOrder],
                                    (int)tReader[StarsTable.StarsCount]
                                    );
                                break;
                        }
                        tResult.Data = tQuestion; 
                        
                    }
                    catch (SqlException sqlEx)
                    {

                        tResult.Success = false;
                        tResult.Message = "We couldn't retrieve the question . Please try again later.";
                        tResult.Error = ErrorTypeEnum.SqlError;
                        Log.Error(sqlEx, "SQL error occurred while retrieving question with Id {id}." , tQuestion.Id);
                    }
                    catch (Exception ex)
                    {
                        tResult.Success = false;
                        tResult.Message = "We couldn't retrieve the question count due to an unexpected error. Please contact support.";
                        tResult.Error = ErrorTypeEnum.UnknownError;
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
                        tCommand.CommandText = $"SELECT * FROM {DatabaseChangeTrackerTable.TableName}";

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
                        tResult.Error = ErrorTypeEnum.SqlError;
                        Log.Error(sqlEx, "SQL error occurred while retrieving Last Modified .");
                    }
                    catch (Exception ex)
                    {
                        tResult.Success = false;
                        tResult.Message = "We couldn't retrieve Last Modified due to an unexpected error. Please contact support.";
                        tResult.Error = ErrorTypeEnum.UnknownError;
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
                        tCommand.CommandText = $"UPDATE {DatabaseChangeTrackerTable.TableName} SET {DatabaseChangeTrackerTable.LastModified}= SYSDATETIME();";
                        tConnection.Open();
                        tCommand.ExecuteNonQuery();
                        
                    }
                    catch (SqlException sqlEx)
                    {

                        tResult.Success = false;
                        tResult.Message = "We couldn't update Last Modified . Please try again later.";
                        tResult.Error = ErrorTypeEnum.SqlError;
                        Log.Error(sqlEx, "SQL error occurred while updating Last Modified .");
                    }
                    catch (Exception ex)
                    {
                        tResult.Success = false;
                        tResult.Message = "We couldn't update Last Modified due to an unexpected error. Please contact support.";
                        tResult.Error = ErrorTypeEnum.UnknownError;
                        Log.Error(ex, "Unexpected error occurred while updating Last Modified.");

                    }
                    return tResult;
                }
            }
        }
        public Result<bool> ChangeConnectionString(string pConnectionString)
        {
            Exception tExceptionError;
            var tTestResult = SqlConnectionTest.TestConnection(pConnectionString, out tExceptionError);
            if (!tTestResult.Success)
            {
                Log.Error(tExceptionError, "Failed to set connection string.");

                return new Result<bool>
                {
                    Success = false,
                    Error = ErrorTypeEnum.ConnectionStringError,
                    Message = "Cannot connect to the database. Please check your server name, database name, username, and password."
                };
            }
            mConnectionString = pConnectionString;
            Configuration tConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            tConfig.ConnectionStrings.ConnectionStrings["DbConnectionString"].ConnectionString = pConnectionString;
            tConfig.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");


            return new Result<bool>
            {
                Success = true,
                Data = true,
                Error = ErrorTypeEnum.None
            };
        }
        public Result<bool> ConnectoinTest(string pConnectionString)
        {
            Exception tExceptionError;
            var tTestResult = SqlConnectionTest.TestConnection(pConnectionString, out tExceptionError);
            if (!tTestResult.Success)
            {
                Log.Error(tExceptionError, "Failed to set connection string.");

                return new Result<bool>
                {
                    Success = false,
                    Error = ErrorTypeEnum.ConnectionStringError,
                    Message = "Cannot connect to the database. Please check your server name, database name, username, and password."
                };
            }
            return new Result<bool> { Error = ErrorTypeEnum.None, Success = true };
        }
        public Result<string> GetConnectionString()
        {
            return new Result<string>()
            {
                Data = mConnectionString
                ,
                Success = true
                ,
                Error = ErrorTypeEnum.None

            }; 
        }


    }


}