using Microsoft.Data.SqlClient;
using Shared;
using SurveyConfiguratorTask.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using Serilog;
using Repository;

namespace SurveyConfiguratorTask.Repo
{
    public class QuestionRepo
    {
        private  string? _connectionString;
        public List<Question> Questions { get; set; }
        public QuestionRepo()
        {
            Questions = new List<Question>();
        }


        

        public Result<List<Question>> QuestionsLoad()
        {
            var savedConnection = ConfigurationManager.ConnectionStrings["DbConnectionString"]?.ConnectionString;
            var result = new Result<List<Question>>() {Success = true , Erorr = ErrorTypeEnum.None ,Data = Questions };
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                Log.Error("Attempted to load questions but the database connection string is not set. ");
                return new Result<List<Question>>
                {
                    Success = false,
                    Erorr = ErrorTypeEnum.ConnectionStringError,
                    Message = "Database connection string is not set. \n Go to Settings → Database Connection to set it up."
                };
            }

            try
            {
                Questions.Clear();

                // Load Slider Questions
                var sliderResult = SliderQuestionsLoad(_connectionString);
                if (!sliderResult.Success)
                {
                    Log.Error("Failed to load slider questions: {Message}", sliderResult.Message);
                    return new Result<List<Question>>
                    {
                        Success = false,
                        Erorr = sliderResult.Erorr,
                        Message = sliderResult.Message
                    };
                }
                Questions.AddRange(sliderResult.Data);
                

                // Load Smiley Questions
                var smileyResult = SmileyQuestionsLoad(_connectionString);
                if (!smileyResult.Success)
                {
                    Log.Error("Failed to load smiley questions: {Message}", smileyResult.Message);
                    return new Result<List<Question>>
                    {
                        Success = false,
                        Erorr = smileyResult.Erorr,
                        Message = smileyResult.Message
                    };
                }
                Questions.AddRange(smileyResult.Data);


                // Load Stars Questions
                var starsResult = StarsQuestionsLoad(_connectionString);
                if (!starsResult.Success)
                {
                    Log.Error("Failed to load star questions: {Message}", starsResult.Message);
                    return new Result<List<Question>>
                    {
                        Success = false,
                        Erorr = starsResult.Erorr,
                        Message = starsResult.Message
                    };
                }
                Questions.AddRange(starsResult.Data);

            }
            catch (Exception ex)
            {
                return new Result<List<Question>>
                {
                    Success = false,
                    Erorr = ErrorTypeEnum.UnknownError,
                    Message = ex.Message
                };
            }
            return result; 
        }
        public Result<List<Question>> SliderQuestionsLoad(string connectionString)
        {
            var result = new Result<List<Question>> { Success = true, Erorr = ErrorTypeEnum.None };
            var questions = new List<Question>();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = $"SELECT {QuestionsTable.SelectColumns}, {SliderTable.SelectColumns} " +
                                      $"FROM {QuestionsTable.TableName} " +
                                      $"INNER JOIN {SliderTable.TableName} " +
                                      $"ON {QuestionsTable.TableName}.{QuestionsTable.Id} = {SliderTable.TableName}.{SliderTable.Id}";

                    connection.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            questions.Add(new SliderQuestion(
                                new Guid(rdr[QuestionsTable.Id].ToString()),
                                rdr[QuestionsTable.QuestionText].ToString(),
                                Convert.ToInt32(rdr[QuestionsTable.QuestionOrder]),
                                Convert.ToInt32(rdr[SliderTable.StartValue]),
                                Convert.ToInt32(rdr[SliderTable.EndValue]),
                                rdr[SliderTable.StartCaption].ToString(),
                                rdr[SliderTable.EndCaption].ToString()
                            ));
                        }
                    }
                    connection.Close();
                }

                result.Data = questions;
            }
            catch (SqlException sqlEx)
            {
                result.Success = false;
                result.Message = "SQL error occurred while loading slider questions.";
                result.Erorr = ErrorTypeEnum.SqlError;
                Log.Error(sqlEx, "SQL error while loading slider questions.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Unexpected error occurred while loading slider questions.";
                result.Erorr = ErrorTypeEnum.UnknownError;
                Log.Error(ex, "Unexpected error while loading slider questions.");
            }

            return result;
        }

        public Result<List<Question>> SmileyQuestionsLoad(string connectionString)
        {
            var result = new Result<List<Question>> { Success = true, Erorr = ErrorTypeEnum.None };
            var questions = new List<Question>();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = $"SELECT {QuestionsTable.SelectColumns}, {SmileyFacesTable.SelectColumns} " +
                                      $"FROM {QuestionsTable.TableName} " +
                                      $"INNER JOIN {SmileyFacesTable.TableName} " +
                                      $"ON {QuestionsTable.TableName}.{QuestionsTable.Id} = {SmileyFacesTable.TableName}.{SmileyFacesTable.Id}";

                    connection.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            questions.Add(new SmileyFacesQuestion(
                                new Guid(rdr[QuestionsTable.Id].ToString()),
                                rdr[QuestionsTable.QuestionText].ToString(),
                                Convert.ToInt32(rdr[QuestionsTable.QuestionOrder]),
                                Convert.ToInt32(rdr[SmileyFacesTable.SmileyCount])
                            ));
                        }
                    }
                    connection.Close();
                }

                result.Data = questions;
            }
            catch (SqlException sqlEx)
            {
                result.Success = false;
                result.Message = "SQL error occurred while loading smiley questions.";
                result.Erorr = ErrorTypeEnum.SqlError;
                Log.Error(sqlEx, "SQL error while loading smiley questions.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Unexpected error occurred while loading smiley questions.";
                result.Erorr = ErrorTypeEnum.UnknownError;
                Log.Error(ex, "Unexpected error while loading smiley questions.");
            }

            return result;
        }

        public Result<List<Question>> StarsQuestionsLoad(string connectionString)
        {
            var result = new Result<List<Question>> { Success = true, Erorr = ErrorTypeEnum.None };
            var questions = new List<Question>();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = $"SELECT {QuestionsTable.SelectColumns}, {StarsTable.SelectColumns} " +
                                      $"FROM {QuestionsTable.TableName} " +
                                      $"INNER JOIN {StarsTable.TableName} " +
                                      $"ON {QuestionsTable.TableName}.{QuestionsTable.Id} = {StarsTable.TableName}.{StarsTable.Id}";

                    connection.Open();
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            questions.Add(new StarsQuestion(
                                new Guid(rdr[QuestionsTable.Id].ToString()),
                                rdr[QuestionsTable.QuestionText].ToString(),
                                Convert.ToInt32(rdr[QuestionsTable.QuestionOrder]),
                                Convert.ToInt32(rdr[StarsTable.StarsCount])
                            ));
                        }
                    }
                    connection.Close();
                }

                result.Data = questions;
            }
            catch (SqlException sqlEx)
            {
                result.Success = false;
                result.Message = "SQL error occurred while loading star questions.";
                result.Erorr = ErrorTypeEnum.SqlError;
                Log.Error(sqlEx, "SQL error while loading star questions.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Unexpected error occurred while loading star questions.";
                result.Erorr = ErrorTypeEnum.UnknownError;
                Log.Error(ex, "Unexpected error while loading star questions.");
            }

            return result;
        }



        public Result<int> AddQuestion(Question question)
        {
            Result<int> result = new Result<int>();
            result.Success = true;
            result.Erorr = ErrorTypeEnum.None;
            try
            {
                //Create and manage conneciton with database .
                using (var connection = new SqlConnection(_connectionString))
                {

                    connection.Open();

                    using (var trans = connection.BeginTransaction())
                    {
                        try
                        {
                            using (var cmd = connection.CreateCommand())
                            {
                                //Add object as general question in database
                                cmd.CommandText = $"INSERT INTO {QuestionsTable.TableName} ({QuestionsTable.Id} " +
                                    $", {QuestionsTable.QuestionText} " +
                                    $", {QuestionsTable.QuestionOrder} " +
                                    $", {QuestionsTable.QuestionType})" +
                                    $" values(@{QuestionsTable.Id} , @{QuestionsTable.QuestionText} , @{QuestionsTable.QuestionOrder} , @{QuestionsTable.QuestionType})";
                                cmd.Parameters.Add($"@{QuestionsTable.Id}", System.Data.SqlDbType.UniqueIdentifier).Value = question.Id;
                                cmd.Parameters.Add($"@{QuestionsTable.QuestionText}", System.Data.SqlDbType.VarChar).Value = question.Text;
                                cmd.Parameters.Add($"@{QuestionsTable.QuestionOrder}", System.Data.SqlDbType.Int).Value = question.Order;
                                cmd.Parameters.Add($"@{QuestionsTable.QuestionType}", System.Data.SqlDbType.Int).Value = (int)question.TypeQuestion;
                                cmd.Transaction = trans;



                                cmd.ExecuteNonQuery();

                                //Add object as specific type question in database .
                                switch (question.TypeQuestion)
                                {
                                    case TypeQuestionEnum.SliderQuestion:
                                        var sliderQuestion = (SliderQuestion)question;
                                        cmd.CommandText = $"INSERT INTO {SliderTable.TableName} " +
                                            $"({SliderTable.Id} " +
                                            $", {SliderTable.StartValue} " +
                                            $", {SliderTable.EndValue} " +
                                            $", {SliderTable.StartCaption} " +
                                            $", {SliderTable.EndCaption})" +
                                            $"values (@{SliderTable.Id} " +
                                            $", @{SliderTable.StartValue} " +
                                            $", @{SliderTable.EndValue} " +
                                            $", @{SliderTable.StartCaption} " +
                                            $", @{SliderTable.EndCaption})";
                                        cmd.Parameters.Add($"@{SliderTable.StartValue}", System.Data.SqlDbType.Int).Value = sliderQuestion.StartValue;
                                        cmd.Parameters.Add($"@{SliderTable.EndValue}", System.Data.SqlDbType.Int).Value = sliderQuestion.EndValue;
                                        cmd.Parameters.Add($"@{SliderTable.StartCaption}", System.Data.SqlDbType.VarChar).Value = sliderQuestion.StartCaption;
                                        cmd.Parameters.Add($"@{SliderTable.EndCaption}", System.Data.SqlDbType.VarChar).Value = sliderQuestion.EndCaption;



                                        break;

                                    case TypeQuestionEnum.SmileyFacesQuestion:
                                        var smileyFaceQuestion = (SmileyFacesQuestion)question;
                                        cmd.CommandText = $"INSERT INTO {SmileyFacesTable.TableName}" +
                                            $"({SmileyFacesTable.Id} , {SmileyFacesTable.SmileyCount}) values" +
                                            $"(@{SmileyFacesTable.Id} , @{SmileyFacesTable.SmileyCount})";
                                        cmd.Parameters.Add($"@{SmileyFacesTable.SmileyCount}", System.Data.SqlDbType.Int).Value = smileyFaceQuestion.SmileyCount;
                                        break;

                                    case TypeQuestionEnum.StarsQuestion:
                                        var starsQuestion = (StarsQuestion)question;
                                        cmd.CommandText = $"INSERT INTO {StarsTable.TableName}" +
                                            $"({StarsTable.Id} , {StarsTable.StarsCount}) values" +
                                            $"(@{StarsTable.Id} , @{StarsTable.StarsCount})";
                                        cmd.Parameters.Add($"@{StarsTable.StarsCount}", System.Data.SqlDbType.Int).Value = starsQuestion.StarsCount;
                                        break;

                                }

                                cmd.ExecuteNonQuery();
                                trans.Commit();

                                connection.Close();




                            }
                        }
                        
                        catch (SqlException sqlEx)
                        {
                            trans.Rollback();
                            result.Success = false;
                            result.Message = "We couldn't save your question at the moment. Please try again later.";
                            result.Erorr = ErrorTypeEnum.SqlError;
                            Log.Error(sqlEx, "SQL error occurred while inserting question of type {Type}", question.TypeQuestion);
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            result.Success = false;
                            result.Message = "Unexpected error occurred while adding question.";
                            result.Erorr = ErrorTypeEnum.UnknownError;
                            Log.Error(ex, "Unexpected error occurred while inserting question of type {Type}", question.TypeQuestion);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Failed to connect to the database. Contact the administrator to resolve the issue.";
                result.Erorr = ErrorTypeEnum.DatabaseError;
                Log.Error(ex, "Database connection failed.");
                
            }
                        return result;


        }

        public Result<object> DeleteQuestion(Guid Id)
        {
            Result<object> result = new Result<object>();
            result.Success = true;
            result.Erorr = ErrorTypeEnum.None;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = $"DELETE FROM {QuestionsTable.TableName} WHERE {QuestionsTable.Id} = @{QuestionsTable.Id}";
                        cmd.Parameters.Add($"@{QuestionsTable.Id}", System.Data.SqlDbType.UniqueIdentifier).Value = Id;


                        connection.Open();
                        cmd.ExecuteNonQuery();



                    }


                }
            }
            catch (SqlException sqlEx)
            {
                
                result.Success = false;
                result.Message = "We couldn't delete your question at the moment. Please try again later.";
                result.Erorr = ErrorTypeEnum.SqlError;
                Log.Error(sqlEx, "SQL error occurred while deleting question ,Id: {Id}", Id);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "We couldn't delete your question due to an unexpected error. Please try again or contact support.";
                result.Erorr = ErrorTypeEnum.UnknownError;
                Log.Error(ex, "Unexpected error occurred while deleting question. QuestionId: {Id}", Id);

            }
            return result; 
        }

        public Result<int> EditQuestion(Question question)
        {
           Result<int> result = new Result<int>() ;
            result.Success= true ;
            result.Erorr = ErrorTypeEnum.None;
            result.Data = 0;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var trans = connection.BeginTransaction())
                    {


                        try
                        {
                            using (var cmd = connection.CreateCommand())
                            {
                                //edit object data in general question table in database 
                                cmd.CommandText = $"UPDATE {QuestionsTable.TableName} " +
                                    $"SET {QuestionsTable.QuestionText} = @{QuestionsTable.QuestionText} " +
                                    $"WHERE {QuestionsTable.TableName}.{QuestionsTable.Id} = @{QuestionsTable.Id}";
                                cmd.Parameters.Add($"@{QuestionsTable.Id}", System.Data.SqlDbType.UniqueIdentifier).Value = question.Id;
                                cmd.Parameters.Add($"@{QuestionsTable.QuestionText}", System.Data.SqlDbType.VarChar).Value = question.Text;
                                cmd.Transaction = trans;
                                cmd.ExecuteNonQuery();

                                //edit object data in specific question type 
                                switch (question.TypeQuestion)
                                {
                                    case TypeQuestionEnum.SliderQuestion:
                                        cmd.CommandText = $"UPDATE {SliderTable.TableName} " +
                                            $"SET {SliderTable.StartValue} = @{SliderTable.StartValue} ," +
                                            $"{SliderTable.EndValue} = @{SliderTable.EndValue} " +
                                            $", {SliderTable.StartCaption} =@{SliderTable.StartCaption} " +
                                            $", {SliderTable.EndCaption} = @{SliderTable.EndCaption}" +
                                            $" WHERE {SliderTable.TableName}.{SliderTable.Id} = @{SliderTable.Id} ";

                                        var sliderQuestion = (SliderQuestion)question;
                                        cmd.Parameters.Add($"@{SliderTable.StartValue}", System.Data.SqlDbType.Int).Value = sliderQuestion.StartValue;
                                        cmd.Parameters.Add($"@{SliderTable.EndValue}", System.Data.SqlDbType.Int).Value = sliderQuestion.EndValue;
                                        cmd.Parameters.Add($"@{SliderTable.StartCaption}", System.Data.SqlDbType.VarChar).Value = sliderQuestion.StartCaption;
                                        cmd.Parameters.Add($"@{SliderTable.EndCaption}", System.Data.SqlDbType.VarChar).Value = sliderQuestion.EndCaption;



                                        break;
                                    case TypeQuestionEnum.SmileyFacesQuestion:
                                        cmd.CommandText = $"UPDATE {SmileyFacesTable.TableName} " +
                                            $"SET {SmileyFacesTable.SmileyCount} = @{SmileyFacesTable.SmileyCount} " +
                                            $"WHERE {SmileyFacesTable.TableName}.{SmileyFacesTable.Id} = @{SmileyFacesTable.Id} ";
                                        var smileyFaceQuestion = (Models.SmileyFacesQuestion)question;
                                        cmd.Parameters.Add($"@{SmileyFacesTable.SmileyCount}", System.Data.SqlDbType.Int).Value = smileyFaceQuestion.SmileyCount;

                                        break;
                                    case TypeQuestionEnum.StarsQuestion:
                                        cmd.CommandText = $"UPDATE {StarsTable.TableName} " +
                                            $"SET {StarsTable.StarsCount} = @{StarsTable.StarsCount} " +
                                            $"WHERE {StarsTable.TableName}.{StarsTable.Id} = @{StarsTable.Id} ";
                                        var starsQuestion = (StarsQuestion)question;
                                        cmd.Parameters.Add($"@{StarsTable.StarsCount}", System.Data.SqlDbType.Int).Value = starsQuestion.StarsCount;

                                        break;

                                }
                                cmd.ExecuteNonQuery();


                            }
                            trans.Commit();
                            connection.Close();

                        }
                        catch (SqlException ex)
                        {
                            trans.Rollback();
                            result.Success = false;
                            result.Message = "We couldn't update your question at the moment. Please try again later.";
                            result.Erorr = ErrorTypeEnum.SqlError;
                            Log.Error(ex, "SQL error occurred while updating question. QuestionId: {Id}", question.Id);
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            result.Success = false;
                            result.Message = "Unexpected error occurred while adding question.";
                            result.Erorr = ErrorTypeEnum.UnknownError;
                            Log.Error(ex, "Unexpected error occurred while inserting question of type {Type}", question.TypeQuestion);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Failed to connect to the database. Contact the administrator to resolve the issue.";
                result.Erorr = ErrorTypeEnum.DatabaseError;
                Log.Error(ex, "Database connection failed.");
            }
            return result; 
        }
        public Result<int> EditOrder(List<Guid> ids, List<int> orders)
        {
            Result<int> result = new Result<int>();
            result.Success = true;
            result.Erorr = ErrorTypeEnum.None;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {

                    connection.Open();

                    using (var trans = connection.BeginTransaction())
                    {
                        try
                        {
                            //edit order of all questions based on indexes in local list .
                            using (var cmd = connection.CreateCommand())
                            {
                                var stb = new StringBuilder();
                                stb.Append($"UPDATE {QuestionsTable.TableName} SET {QuestionsTable.QuestionOrder} = CASE {QuestionsTable.Id} ");
                                for (int i = 0; i < ids.Count; i++)
                                {
                                    stb.Append($"WHEN '{ids[i]}' THEN {orders[i]}\n");
                                }
                                stb.Append($"\n END WHERE {QuestionsTable.Id} IN (");

                                for (int i = 0; i < ids.Count - 1; i++)
                                    stb.Append($"'{ids[i]}',");
                                stb.Append($"'{ids[ids.Count - 1]}'");

                                stb.Append(");");
                                cmd.CommandText = stb.ToString();
                                cmd.Transaction = trans;
                                cmd.ExecuteNonQuery();
                                trans.Commit();
                                connection.Close();
                            }

                        }

                        catch (SqlException ex)
                        {
                            trans.Rollback();
                            result.Success = false;
                            result.Message = "We couldn't update order at the moment. Please try again later.";
                            result.Erorr = ErrorTypeEnum.SqlError;
                            Log.Error(ex, "SQL error occurred while updating order. ");
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            result.Success = false;
                            result.Message = "Unexpected error occurred while update order.";
                            result.Erorr = ErrorTypeEnum.UnknownError;
                            Log.Error(ex, "Unexpected error occurred while updating order ");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Failed to connect to the database. Contact the administrator to resolve the issue.";
                result.Erorr = ErrorTypeEnum.DatabaseError;
                Log.Error(ex, "Database connection failed.");
            }
            return result;
        }
        public Result<int> GetCount()
        {
            Result<int> result = new Result<int> { Success = true , Erorr = ErrorTypeEnum.None , Data = 0};
            int questionCount;
            try
            {
                // Get count of question in database 
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = $"SELECT COUNT({QuestionsTable.Id}) FROM Questions";



                        connection.Open();
                        var rdr = cmd.ExecuteReader();
                        rdr.Read();
                        questionCount = Convert.ToInt32(rdr[0]);
                        result.Data = questionCount;


                    }


                }
            }
            catch (SqlException sqlEx)
            {

                result.Success = false;
                result.Message = "We couldn't retrieve the question count at the moment. Please try again later.";
                result.Erorr = ErrorTypeEnum.SqlError;
                Log.Error(sqlEx, "SQL error occurred while retrieving question count.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "We couldn't retrieve the question count due to an unexpected error. Please contact support.";
                result.Erorr = ErrorTypeEnum.UnknownError;
                Log.Error(ex, "Unexpected error occurred while retrieving question count.");
            
            }
            return result;
        }
        public Result<Question> GetQuestion(Guid id)
        {
            Result<Question> result = new Result<Question> { Success = true, Erorr = ErrorTypeEnum.None };
            
                //Get question object (general and specific type information ) based on Id 
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var cmd = connection.CreateCommand())
                    {
                    Question question = null;

                    try
                    {

                        cmd.CommandText = $"SELECT * FROM {QuestionsTable.TableName} WHERE {QuestionsTable.Id} =@{QuestionsTable.Id}";
                        cmd.Parameters.Add($"@{QuestionsTable.Id}", System.Data.SqlDbType.UniqueIdentifier).Value = id;

                        connection.Open();
                        var rdr = cmd.ExecuteReader();
                        rdr.Read();

                        switch ((TypeQuestionEnum)rdr[QuestionsTable.QuestionType])
                        {
                            case TypeQuestionEnum.SliderQuestion:
                                connection.Close();
                                cmd.CommandText = $"SELECT {QuestionsTable.TableName}.*,{SliderTable.TableName}.* " +
                                    $"FROM {QuestionsTable.TableName} INNER JOIN {SliderTable.TableName}  " +
                                    $"ON {QuestionsTable.TableName}.{QuestionsTable.Id} = @{QuestionsTable.Id} " +
                                    $"WHERE {QuestionsTable.TableName}.{QuestionsTable.Id} = @{QuestionsTable.Id};";
                                connection.Open();

                                rdr = cmd.ExecuteReader();
                                rdr.Read();
                                question = new SliderQuestion(
                                    (Guid)rdr[QuestionsTable.Id],
                                    (string)rdr[QuestionsTable.QuestionText],
                                    (int)rdr[QuestionsTable.QuestionOrder],
                                    (int)rdr[SliderTable.StartValue],
                                    (int)rdr[SliderTable.EndValue],
                                    (string)rdr[SliderTable.StartCaption],
                                    (string)rdr[SliderTable.EndCaption]
                                    );
                                break;
                            case TypeQuestionEnum.SmileyFacesQuestion:
                                connection.Close();

                                cmd.CommandText = $"SELECT {QuestionsTable.TableName}.*,{SmileyFacesTable.TableName}.* FROM {QuestionsTable.TableName} " +
                                    $"INNER JOIN {SmileyFacesTable.TableName}  ON {QuestionsTable.TableName}.{QuestionsTable.Id}= @{QuestionsTable.Id} " +
                                    $"WHERE {QuestionsTable.TableName}.{QuestionsTable.Id} = @{QuestionsTable.Id};";
                                connection.Open();

                                rdr = cmd.ExecuteReader();
                                rdr.Read();
                                question = new Models.SmileyFacesQuestion(
                                    (Guid)rdr[QuestionsTable.Id],
                                    (string)rdr[QuestionsTable.QuestionText],
                                    (int)rdr[QuestionsTable.QuestionOrder],
                                    (int)rdr[SmileyFacesTable.SmileyCount]
                                    );
                                break;
                            case TypeQuestionEnum.StarsQuestion:
                                connection.Close();

                                cmd.CommandText = $"SELECT {QuestionsTable.TableName}.*,{StarsTable.TableName}.* FROM {QuestionsTable.TableName} " +
                                    $"INNER JOIN {StarsTable.TableName}  ON  {QuestionsTable.TableName}.{QuestionsTable.Id}= @{QuestionsTable.Id}" +
                                    $"   WHERE {QuestionsTable.TableName}.{QuestionsTable.Id} = @{QuestionsTable.Id};";
                                connection.Open();

                                rdr = cmd.ExecuteReader();
                                rdr.Read();
                                question = new StarsQuestion(
                                    (Guid)rdr[QuestionsTable.Id],
                                    (string)rdr[QuestionsTable.QuestionText],
                                    (int)rdr[QuestionsTable.QuestionOrder],
                                    (int)rdr[StarsTable.StarsCount]
                                    );
                                break;
                        }
                        result.Data = question; 
                        
                    }
                    catch (SqlException sqlEx)
                    {

                        result.Success = false;
                        result.Message = "We couldn't retrieve the question . Please try again later.";
                        result.Erorr = ErrorTypeEnum.SqlError;
                        Log.Error(sqlEx, "SQL error occurred while retrieving question with Id {id}." , question.Id);
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Message = "We couldn't retrieve the question count due to an unexpected error. Please contact support.";
                        result.Erorr = ErrorTypeEnum.UnknownError;
                        Log.Error(ex, "Unexpected error occurred while retrieving question with Id {id}." , question.Id);

                    }
                    return result;

                }

                }
            
            
        }
        public Result<DateTime> GetLastModified()
        {
            Result<DateTime> result = new Result<DateTime>()
            {
                Success = true,
                Erorr = ErrorTypeEnum.None,
                
            };
            //Questions = new List<Question>();
           

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {


                    try
                    {
                        cmd.CommandText = $"SELECT * FROM {DatabaseChangeTrackerTable.TableName}";

                        connection.Open();
                        var rdr = cmd.ExecuteReader();
                        rdr.Read();
                        DateTime lastModified = (DateTime)rdr[0];
                        result.Data = lastModified;
                        return result;
                    }
                    catch (SqlException sqlEx)
                    {

                        result.Success = false;
                        result.Message = "We couldn't retrieve Last Modified . Please try again later.";
                        result.Erorr = ErrorTypeEnum.SqlError;
                        Log.Error(sqlEx, "SQL error occurred while retrieving Last Modified .");
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Message = "We couldn't retrieve Last Modified due to an unexpected error. Please contact support.";
                        result.Erorr = ErrorTypeEnum.UnknownError;
                        //Log.Error(ex, "Unexpected error occurred while retrieving Last Modified.");

                    }
                    return result; 
                }


            }
        }
        public Result<int> UpdateLastModified()
        {
            Questions = new List<Question>();
            Result<int> result = new Result<int>() 
            { 
                Success = true, 
                Erorr = ErrorTypeEnum.None,

            };  

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = $"UPDATE {DatabaseChangeTrackerTable.TableName} SET {DatabaseChangeTrackerTable.LastModified}= SYSDATETIME();";
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        
                    }
                    catch (SqlException sqlEx)
                    {

                        result.Success = false;
                        result.Message = "We couldn't update Last Modified . Please try again later.";
                        result.Erorr = ErrorTypeEnum.SqlError;
                        Log.Error(sqlEx, "SQL error occurred while updating Last Modified .");
                    }
                    catch (Exception ex)
                    {
                        result.Success = false;
                        result.Message = "We couldn't update Last Modified due to an unexpected error. Please contact support.";
                        result.Erorr = ErrorTypeEnum.UnknownError;
                        Log.Error(ex, "Unexpected error occurred while updating Last Modified.");

                    }
                    return result;
                }
            }
        }
        public Result<bool> ChangeConnectionString(string connectionString)
        {
            Exception exErorr;
            var testResult = SqlConnectionTest.TestConnection(connectionString , out exErorr);
            if (!testResult.Success)
            {
                Log.Error(exErorr ,"Failed to set connection string.");

                return new Result<bool>
                {
                    Success = false,
                    Erorr = ErrorTypeEnum.ConnectionStringError,
                    Message = "Cannot connect to the database. Please check your server name, database name, username, and password."
                };
            }
            _connectionString = connectionString;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["DbConnectionString"].ConnectionString = connectionString;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");


            return new Result<bool>
            {
                Success = true,
                Data = true,
                Erorr = ErrorTypeEnum.None
            };
        }


    }


}