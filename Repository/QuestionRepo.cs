using Microsoft.Data.SqlClient;
using Shared;
using SurveyConfiguratorTask.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace SurveyConfiguratorTask.Repo
{
    public class QuestionRepo
    {
        private readonly string _connectionString;
        public List<Question> Questions { get; set; }
        public QuestionRepo()
        {
             _connectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        }


        public List<Question> QuestionsLoad()
        {
            
            Questions = new List<Question>();
            
            //Load questions
            SliderQuestionsLoad(_connectionString);
            SmileyQuestionsLoad(_connectionString);
            StarsQuestionsLoad(_connectionString);

            return Questions;
        }

        public void SliderQuestionsLoad (string connectionString){
            
            //Create and manage connection with database . 
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    //Load slider questions from database .
                    cmd.CommandText = $"SELECT {QuestionsTable.SelectColumns}" +
                        $" ,{SliderTable.SelectColumns} " +
                        $"FROM {QuestionsTable.TableName} " +
                        $"INNER JOIN {SliderTable.TableName} ON " +
                        $"{QuestionsTable.TableName}.{QuestionsTable.Id} = {SliderTable.TableName}.{SliderTable.Id} ";



                    connection.Open();
                    var rdr = cmd.ExecuteReader();
                    // Representing loaded data onto a local variable 
                    while (rdr.Read())
                    {
                        Questions.Add(
                            new SliderQuestion
                            (
                                 new Guid(rdr[QuestionsTable.Id].ToString()),
                                 rdr[QuestionsTable.QuestionText].ToString(),
                                 Convert.ToInt32(rdr[QuestionsTable.QuestionOrder]),
                                  Convert.ToInt32(rdr[SliderTable.StartValue]),
                                 Convert.ToInt32(rdr[SliderTable.EndValue]),
                                 rdr[SliderTable.StartCaption].ToString(),
                                 rdr[SliderTable.EndValue].ToString()
                            )
                            );

                    }
                    connection.Close();
                }
            }
        }

        public void SmileyQuestionsLoad(string connectionString)
        {
        
            //Create and manage connection with database . 
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    //Load smiley faces questions from database .

                    cmd.CommandText = $"SELECT {QuestionsTable.SelectColumns}" +
                        $",{SmileyFacesTable.SelectColumns}" +
                        $" FROM {QuestionsTable.TableName} " +
                        $"INNER JOIN {SmileyFacesTable.TableName} ON" +
                        $" {QuestionsTable.TableName}.{QuestionsTable.Id} = {SmileyFacesTable.TableName}.{SmileyFacesTable.Id} ";

                    connection.Open();

                    var rdr = cmd.ExecuteReader();
                    // Representing loaded data onto a local variable 

                    while (rdr.Read())
                    {
                        Questions.Add(new Models.SmileyFacesQuestion(
                            new Guid(rdr[QuestionsTable.Id].ToString()),
                            rdr[QuestionsTable.QuestionText].ToString(),
                            Convert.ToInt32(rdr[QuestionsTable.QuestionOrder]),
                            Convert.ToInt32(rdr[SmileyFacesTable.SmileyCount])

                            ));
                    }
                    connection.Close();
                }
            }
        }

        public void StarsQuestionsLoad(string connectionString)
        {
            //Create and manage connection with database . 
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    //Load  stars questions from database .
                    cmd.CommandText = $"SELECT {QuestionsTable.SelectColumns} " +
                    $", {StarsTable.SelectColumns} " +
                    $" FROM {QuestionsTable.TableName} " +
                    $"INNER JOIN StarsQuestion ON " +
                    $"{QuestionsTable.TableName}.{QuestionsTable.Id} = {StarsTable.TableName}.{StarsTable.Id} ";

                    connection.Open();

                    var rdr = cmd.ExecuteReader();
                    // Representing loaded data onto a local variable 

                    while (rdr.Read())
                    {
                        Questions.Add(new StarsQuestion(
                            new Guid(rdr[QuestionsTable.Id].ToString()),
                            rdr[QuestionsTable.QuestionText].ToString(),
                            Convert.ToInt32(rdr[QuestionsTable.QuestionOrder]),
                            Convert.ToInt32(rdr[StarsTable.StarsCount])

                            ));
                    }
                    connection.Close();
                }
            }
        }

        public void AddQuestion(Question question)
        {
            
            //Create and manage conneciton with database .
            using (var connection = new SqlConnection(_connectionString))
            {

                connection.Open();

                using (var trans = connection.BeginTransaction())
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
                        try
                        {


                            cmd.ExecuteNonQuery();

                            //Add object as specific type question in database .
                            switch ((int)question.TypeQuestion)
                            {
                                case 0:
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

                                case 1:
                                    var smileyFaceQuestion = (Models.SmileyFacesQuestion)question;
                                    cmd.CommandText = $"INSERT INTO {SmileyFacesTable.TableName}" +
                                        $"({SmileyFacesTable.Id} , {SmileyFacesTable.SmileyCount}) values" +
                                        $"(@{SmileyFacesTable.Id} , @{SmileyFacesTable.SmileyCount})";
                                    cmd.Parameters.Add($"@{SmileyFacesTable.SmileyCount}", System.Data.SqlDbType.Int).Value = smileyFaceQuestion.SmileyCount;
                                    break;

                                case 2:
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
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw;
                        }

                    }
                }
            }
        }

        public void DeleteQuestion(Guid Id)
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

        public void EditQuestion(Question question)
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
                            switch ((int)question.TypeQuestion)
                            {
                                case 0:
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
                                case 1:
                                    cmd.CommandText = $"UPDATE {SmileyFacesTable.TableName} " +
                                        $"SET {SmileyFacesTable.SmileyCount} = @{SmileyFacesTable.SmileyCount} " +
                                        $"WHERE {SmileyFacesTable.TableName}.{SmileyFacesTable.Id} = @{SmileyFacesTable.Id} ";
                                    var smileyFaceQuestion = (Models.SmileyFacesQuestion)question;
                                    cmd.Parameters.Add($"@{SmileyFacesTable.SmileyCount}", System.Data.SqlDbType.Int).Value = smileyFaceQuestion.SmileyCount;

                                    break;
                                case 2:
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
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw;
                    }
                }

            }
        }
        public void EditOrder(List<Guid> ids, List<int> orders)
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

                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        public int GetCount()
        {

            int questionCount; 
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


                }


            }
            return questionCount;
        }
        public Question GetQuestion(Guid id)
        {

            
            

            //Get question object (general and specific type information ) based on Id 
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {


                    cmd.CommandText = $"SELECT * FROM {QuestionsTable.TableName} WHERE {QuestionsTable.Id} =@{QuestionsTable.Id}";
                    cmd.Parameters.Add($"@{QuestionsTable.Id}", System.Data.SqlDbType.UniqueIdentifier).Value = id;

                    connection.Open();
                    var rdr = cmd.ExecuteReader();
                    rdr.Read();
                    Question question = null;

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
                    return question;

                }

            }
        }

        public DateTime GetLastModified()
        {
            Questions = new List<Question>();
           

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {


                    cmd.CommandText = $"SELECT * FROM {DatabaseChangeTrackerTable.TableName}";

                    connection.Open();
                    var rdr =cmd.ExecuteReader();
                    rdr.Read();
                    DateTime lastModified = (DateTime)rdr[0];

                    return lastModified;
                }


            }
        }

        public void UpdateLastModified()
        {
            Questions = new List<Question>();
            

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = $"UPDATE {DatabaseChangeTrackerTable.TableName} SET {DatabaseChangeTrackerTable.LastModified}= SYSDATETIME();";
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
    } 

    
}