using Microsoft.Data.SqlClient;
using SurveyConfiguratorTask.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace SurveyConfiguratorTask.Repo
{
    public class QuestionRepo 
    {
        public List<Question> Questions { get; set; }
        public List<Question> QuestionsLoad()
        {
            Questions = new List<Question>();
            var connectionString = ConfigurationManager.
                ConnectionStrings["DbConnectionString"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT Questions.Id,Questions.QuestionText , Questions.QuestionOrder " +

                        ", SliderQuestion.StartValue , SliderQuestion.EndValue , SliderQuestion.StartCaption " +
                        ", SliderQuestion.EndCaption FROM Questions " +
                        "INNER JOIN SliderQuestion ON Questions.Id = SliderQuestion.Id ";

                    try
                    {

                        connection.Open();
                        var rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Questions.Add(
                                new SliderQuestion
                                (
                                     new Guid(rdr["Id"].ToString()),
                                     rdr["QuestionText"].ToString(),
                                     Convert.ToInt32(rdr["QuestionOrder"]),
                                      Convert.ToInt32(rdr["StartValue"]),
                                     Convert.ToInt32(rdr["EndValue"]),
                                     rdr["StartCaption"].ToString(),
                                     rdr["EndCaption"].ToString()
                                )
                                );

                        }
                        connection.Close();


                        cmd.CommandText = "SELECT Questions.Id,Questions.QuestionText , Questions.QuestionOrder " +

                        ", SmileyFacesQuestion.SmileyCount " +
                        " FROM Questions " +
                        "INNER JOIN SmileyFacesQuestion ON Questions.Id = SmileyFacesQuestion.Id ";

                        connection.Open();

                        rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            Questions.Add(new SmileyFacesQuestion(
                                new Guid(rdr["Id"].ToString()),
                                rdr["QuestionText"].ToString(),
                                Convert.ToInt32(rdr["QuestionOrder"]),
                                Convert.ToInt32(rdr["SmileyCount"])

                                ));
                        }
                        connection.Close();

                        cmd.CommandText = "SELECT Questions.Id,Questions.QuestionText , Questions.QuestionOrder " +

                        ", StarsQuestion.StarsCount " +
                        " FROM Questions " +
                        "INNER JOIN StarsQuestion ON Questions.Id = StarsQuestion.Id ";

                        connection.Open();

                        rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            Questions.Add(new StarsQuestion(
                                new Guid(rdr["Id"].ToString()),
                                rdr["QuestionText"].ToString(),
                                Convert.ToInt32(rdr["QuestionOrder"]),
                                Convert.ToInt32(rdr["StarsCount"])

                                ));
                        }
                        connection.Close();


                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }

                    return Questions;
                }

            }
        }

        public void AddQuestion(Question question)
        {
            var connectionString = ConfigurationManager.
                ConnectionStrings["DbConnectionString"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {

                connection.Open();

                using (var trans = connection.BeginTransaction())
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        //Add it to list from service , not from here 
                        cmd.CommandText = "INSERT INTO Questions (Id , QuestionText , QuestionOrder , QuestionType)" +
                            " values(@Id , @QuestionText , @QuestionOrder , @QuestionType)";
                        cmd.Parameters.Add("@Id", System.Data.SqlDbType.UniqueIdentifier).Value = question.Id;
                        cmd.Parameters.Add("@QuestionText", System.Data.SqlDbType.VarChar).Value = question.Text;
                        cmd.Parameters.Add("@QuestionOrder", System.Data.SqlDbType.Int).Value = question.Order;
                        cmd.Parameters.Add("@QuestionType", System.Data.SqlDbType.Int).Value = (int)question.TypeQuestion;
                        cmd.Transaction = trans;
                        try
                        {


                            cmd.ExecuteNonQuery();


                            switch ((int)question.TypeQuestion)
                            {
                                case 0:
                                    var sliderQuestion = (SliderQuestion)question;
                                    cmd.CommandText = "INSERT INTO SliderQuestion " +
                                        "(Id , StartValue , EndValue , StartCaption , EndCaption)" +
                                        "values (@Id , @StartValue , @EndValue , @StartCaption , @EndCaption)";
                                    cmd.Parameters.Add("@StartValue", System.Data.SqlDbType.Int).Value = sliderQuestion.StartValue;
                                    cmd.Parameters.Add("@EndValue", System.Data.SqlDbType.Int).Value = sliderQuestion.EndValue;
                                    cmd.Parameters.Add("@StartCaption", System.Data.SqlDbType.VarChar).Value = sliderQuestion.StartCaption;
                                    cmd.Parameters.Add("@EndCaption", System.Data.SqlDbType.VarChar).Value = sliderQuestion.EndCaption;



                                    break;

                                case 1:
                                    var smileyFaceQuestion = (SmileyFacesQuestion)question;
                                    cmd.CommandText = "INSERT INTO SmileyFacesQuestion" +
                                        "(Id , SmileyCount) values" +
                                        "(@Id , @SmileCount)";
                                    cmd.Parameters.Add("@SmileCount", System.Data.SqlDbType.Int).Value = smileyFaceQuestion.SmileyCount;
                                    break;

                                case 2:
                                    var starsQuestion = (StarsQuestion)question;
                                    cmd.CommandText = "INSERT INTO StarsQuestion" +
                                        "(Id , StarsCount) values" +
                                        "(@Id , @StarsCount)";
                                    cmd.Parameters.Add("@StarsCount", System.Data.SqlDbType.Int).Value = starsQuestion.StarsCount;
                                    break;

                            }

                            cmd.ExecuteNonQuery();
                            trans.Commit();

                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw new Exception(ex.Message);
                        }





                    }
                }
            }
        }

        public void DeleteQuestion(Guid Id)
        {
            var connectionString = ConfigurationManager.
                ConnectionStrings["DbConnectionString"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Questions WHERE Id = @Id";
                    cmd.Parameters.Add("@Id", System.Data.SqlDbType.UniqueIdentifier).Value = Id;

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }


            }
        }

        public void EditQuestion(Question question)
        {
            var connectionString = ConfigurationManager.
                ConnectionStrings["DbConnectionString"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var trans = connection.BeginTransaction())
                {
                    try
                    {

                        using (var cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "UPDATE Questions SET QuestionText = @Text WHERE Questions.Id = @Id";
                            cmd.Parameters.Add("@Id", System.Data.SqlDbType.UniqueIdentifier).Value = question.Id;
                            cmd.Parameters.Add("@Text", System.Data.SqlDbType.VarChar).Value = question.Text;
                            cmd.Transaction = trans;
                            cmd.ExecuteNonQuery();

                            switch ((int)question.TypeQuestion)
                            {
                                case 0:
                                    cmd.CommandText = "UPDATE SliderQuestion SET StartValue = @StartValue ," +
                                        "EndValue = @EndValue , StartCaption =@StartCaption , EndCaption =EndCaption" +
                                        "WHERE SliderQuestion.Id = @Id ";
                                    var sliderQuestion = (SliderQuestion)question;
                                    cmd.Parameters.Add("@StartValue", System.Data.SqlDbType.Int).Value = sliderQuestion.StartValue;
                                    cmd.Parameters.Add("@EndValue", System.Data.SqlDbType.Int).Value = sliderQuestion.EndValue;
                                    cmd.Parameters.Add("@StartCaption", System.Data.SqlDbType.VarChar).Value = sliderQuestion.StartCaption;
                                    cmd.Parameters.Add("@EndCaption", System.Data.SqlDbType.VarChar).Value = sliderQuestion.EndCaption;



                                    break;
                                case 1:
                                    cmd.CommandText = "UPDATE SmileyFacesQuestion SET SmileyCount = @SmileyCount " +
                                        "WHERE SmileyFacesQuestion.Id = @Id ";
                                    var smileyFaceQuestion = (SmileyFacesQuestion)question;
                                    cmd.Parameters.Add("@SmileyCount", System.Data.SqlDbType.Int).Value = smileyFaceQuestion.SmileyCount;

                                    break;
                                case 2:
                                    cmd.CommandText = "UPDATE StarsQuestion SET StarsCount = @StarsCount " +
                                        "WHERE StarsQuestion.Id = @Id ";
                                    var starsQuestion = (StarsQuestion)question;
                                    cmd.Parameters.Add("@StarsCount", System.Data.SqlDbType.Int).Value = starsQuestion.StarsCount;

                                    break;

                            }
                            cmd.ExecuteNonQuery();


                        }
                        trans.Commit();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }

            }
        }
        public void EditOrder(List<Guid> ids, List<int> orders)
        {
            var connectionString = ConfigurationManager.
                ConnectionStrings["DbConnectionString"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (var trans = connection.BeginTransaction())
                    {
                        using (var cmd = connection.CreateCommand())
                        {
                            var stb = new StringBuilder();
                            stb.Append("UPDATE Questions SET QuestionOrder = CASE Id ");
                            for (int i = 0; i < ids.Count; i++)
                            {
                                stb.Append($"WHEN '{ids[i]}' THEN {orders[i]}\n");
                            }
                            stb.Append("\n END WHERE Id IN (");

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
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        }

        public int GetCount()
        {
            var connectionString = ConfigurationManager.
                ConnectionStrings["DbConnectionString"].ConnectionString;
            int questionCount;
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(Id) FROM Questions";


                    try
                    {
                        connection.Open();
                        var rdr = cmd.ExecuteReader();
                        rdr.Read();
                        questionCount = Convert.ToInt32(rdr[0]);

                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }


            }
            return questionCount;
        }

    }
}