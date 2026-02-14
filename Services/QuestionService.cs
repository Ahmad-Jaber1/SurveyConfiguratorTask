using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Models;
using Serilog;
using Shared;
using SurveyConfiguratorTask.Models;
using SurveyConfiguratorTask.Repo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;

namespace Services
{
    public class QuestionService 
    {
        QuestionRepo mRepo = new();
        List<Question> mQuestions;
        private bool mConnectionValid;
        public event Action CheckUpdateEvent;
        private DateTime mDateTime = DateTime.Now;
        Thread mCheckForUpdate;
        bool mIsRunning = true; 
        



        public QuestionService()
        {
            mQuestions = new List<Question>();
            CreateCheckThread();

        }

        public Result<List<Question>> QuestionsLoad()
        {
            Result<List<Question>> tResult = new Result<List<Question>> { Success = true , Error = ErrorTypeEnum.None };
            try
            {
                tResult = mRepo.QuestionsLoad();
                if (!tResult.Success)
                {
                     
                    return tResult;

                }
                mQuestions = mRepo.QuestionsLoad().Data;
                

                if (mQuestions is not null & mQuestions.Count > 0)
                    mQuestions.Sort();
                tResult.Data = mQuestions; 
                return tResult;
            }
            catch (Exception ex) 
            {
                tResult.Success = false;
                tResult.Error = ErrorTypeEnum.UnknownErrorQuestionsLoad;
                tResult.Message = "Unexpected error occurred while loading questions.";
                Log.Error(ex, "Error occurred while loading the question list.");
                 
            }
            return tResult; 
        
        }
        public Result<int> AddQuestion(TypeQuestionEnum pType , AddQuestionDto pQuestionDto)
        {
            Result<int> tResult = new Result<int> { Error = ErrorTypeEnum.None , Success = true , Data = 0};
            try
            {
                if (pQuestionDto is null)
                    throw new ArgumentNullException(null , "Question data cannot be empty. Please provide a valid question.");

                int tQuestionCount = mRepo.GetCount().Data;


                Question tQuestion = null;
                //Create new question in local variable .
                //becasue each type of question has different fields
                //, we try to determine what type of question the user trying to add .
                switch (pType)
                {

                    case TypeQuestionEnum.SliderQuestion:
                        tQuestion = new SliderQuestion(pQuestionDto.Text, pQuestionDto.Order, pQuestionDto.StartValue
                            , pQuestionDto.EndValue, pQuestionDto.StartCaption, pQuestionDto.EndCaption);
                        break;
                    case TypeQuestionEnum.SmileyFacesQuestion:
                        tQuestion = new SmileyFacesQuestion(pQuestionDto.Text, pQuestionDto.Order, pQuestionDto.SmileyCount);
                        break;
                    case TypeQuestionEnum.StarsQuestion:
                        tQuestion = new StarsQuestion(pQuestionDto.Text, pQuestionDto.Order, pQuestionDto.StarsCount);
                        break;
                    _:
                        throw new ArgumentOutOfRangeException(null , "The selected question type is not valid. Please choose a supported type.");
                        break;

                }
                // Validate that the user-selected order does not exceed the total number of mQuestions
                var tCountResult = GetCount();
                if (!tCountResult.Success)
                    return tCountResult;
                if (pQuestionDto.Order > tCountResult.Data+1 || pQuestionDto.Order <= 0)
                {
                    throw new ArgumentOutOfRangeException(null,$"Order value must be between 1 and {tCountResult.Data + 1}. Please enter a valid number.");
                }
                
                
                mQuestions.Insert(pQuestionDto.Order - 1, tQuestion);

                //Add new question to database.

                tResult = mRepo.AddQuestion(tQuestion);
                if (!tResult.Success)
                    return tResult;

                if (pQuestionDto.Order != tQuestionCount + 1 )
                {
                    tResult = EditOrder();
                    if (!tResult.Success)
                        return tResult; 
                }

                
                

                
                    mRepo.UpdateLastModified();
               
            }
            
            catch (ArgumentNullException ex)
            {
                
                tResult.Success = false;
                tResult.Message = ex.Message;
                tResult.Error = ErrorTypeEnum.Validation_QuestionDataNull;
                Log.Error(ex, "Validation failed: null value.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                
                tResult.Success = false;
                tResult.Message = ex.Message;
                tResult.Error = ErrorTypeEnum.Validation_OrderOutOfRangeAdd;
                Log.Error(ex, "Validation failed: value out of range.");
            }
            catch (ArgumentException ex)
            {
                
                tResult.Success = false;
                tResult.Message = ex.Message;
                tResult.Error = ErrorTypeEnum.Validation_QuestionTypeInvalid;
                Log.Error(ex, "Validation failed: invalid argument.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while adding a question of type {Type}", (TypeQuestionEnum)pType);
                tResult.Success=false;
                tResult.Error=ErrorTypeEnum.UnknownErrorAddQuestion;
                tResult.Message = "An unexpected error occurred while adding your question. Please try again or contact support.";
            }
            return tResult;
        }
        
        public Result<int> DeleteQuestion(int pId)
        {
            Result<int> tResult = new Result<int>();
            tResult.Success = true;
            tResult.Error = ErrorTypeEnum.None;
            tResult.Data = 0;
            try
            {
                Question deletedQuestion = null; 
                foreach ( var question in mQuestions)
                {
                    if (question.Id == pId)
                    {
                        
                            mRepo.DeleteQuestion(pId); 
                        if(!tResult.Success)
                            return tResult;
                        mQuestions.Remove(question);


                        // Reorder mQuestions to maintain consistent ordering after deletion
                        tResult = EditOrder();
                        if (!tResult.Success)
                            return tResult; 
                        deletedQuestion = question;
                        mRepo.UpdateLastModified();

                        break;
                    }
                   
                }
                if (deletedQuestion is null)
                    throw new KeyNotFoundException("Question not found.");
                
            }
            catch (KeyNotFoundException ex)
            {
                tResult.Success = false;
                tResult.Message = ex.Message;
                tResult.Error = ErrorTypeEnum.NotFound_DeleteQuestion;
                Log.Error(ex, "Attempted to delete a question that does not exist. Id: {Id}", pId);
                
                
            }
            catch (Exception ex)
            {
                tResult.Success = false;
                tResult.Message = ex.Message;
                tResult.Error = ErrorTypeEnum.UnknownErrorDeleteQuestion;
                Log.Error(ex, "Error occurred while deleting a question with Id {Id}", pId);
                
                
            }
            return tResult; 
        }
        public Result<int> EditQuestion(int pId , EditQuestionDto pEditQuestionDto)
        {
            Result<int> tResult = new Result<int> { Success = true , Error = ErrorTypeEnum.None , Data = 0};
            try
            {
                if (pEditQuestionDto is null)
                    throw new ArgumentNullException( null , "Please provide a question. This field cannot be empty.");


                Question question = null;
                //var getQuestionResult  = mRepo.GetQuestion(id);
                //if (!getQuestionResult.Success)
                //{
                //    tResult.Error = ErrorTypeEnum.UnknownError;
                //    tResult.Message = getQuestionResult.Message;
                //    tResult.Success = false; 
                //    return tResult;
                //}
                
                foreach (var item in mQuestions)
                {
                    if (item.Id == pId)
                    {
                        question = item;
                    }
                }
                if (question is null)
                    throw new KeyNotFoundException( "The specified question was not found. Please check your selection.");


                Question questionEdit = null;
                switch (question.TypeQuestion)
                {

                    case TypeQuestionEnum.SliderQuestion:

                        questionEdit = new SliderQuestion(question.Id, pEditQuestionDto.Text, pEditQuestionDto.Order == 0 ? question.Order : pEditQuestionDto.Order, pEditQuestionDto.StartValue
                            , pEditQuestionDto.EndValue, pEditQuestionDto.StartCaption, pEditQuestionDto.EndCaption);
                        break;
                    case TypeQuestionEnum.SmileyFacesQuestion:
                        questionEdit = new SmileyFacesQuestion(question.Id, pEditQuestionDto.Text, pEditQuestionDto.Order == 0 ? question.Order : pEditQuestionDto.Order, pEditQuestionDto.SmileyCount);
                        break;
                    case TypeQuestionEnum.StarsQuestion:
                        questionEdit = new StarsQuestion(question.Id, pEditQuestionDto.Text, pEditQuestionDto.Order == 0 ? question.Order : pEditQuestionDto.Order, pEditQuestionDto.StarsCount);
                        break;
                     

                }
                tResult = GetCount();
                if (!tResult.Success)
                    return tResult; 
                // Validate that the user-selected order does not exceed the total number of mQuestions

                if (questionEdit.Order > tResult.Data || questionEdit.Order <= 0)
                {
                    throw new ArgumentOutOfRangeException(null , $"Order value must be between 1 and {tResult.Data}. Please enter a valid number.");

                }

                
                tResult  = mRepo.EditQuestion(questionEdit);
                if (!tResult.Success)
                    return tResult;

                mQuestions.Remove(question);
                mQuestions.Insert(questionEdit.Order - 1, questionEdit);

                // Reorder all mQuestions only when the question's order has been changed
                if (pEditQuestionDto.Order != 0)
                {
                    tResult = EditOrder();
                    if(!tResult.Success)
                            return tResult;
                }
                mRepo.UpdateLastModified();


            }
            catch (KeyNotFoundException ex)
            {
                tResult.Success = false;
                tResult.Message = ex.Message;
                tResult.Error = ErrorTypeEnum.NotFound_EditQuestion;
                Log.Error(ex, "Attempted to edit a question a question with Id {Id}", pId);
                
            }
            catch (ArgumentNullException ex)
            {

                tResult.Success = false;
                tResult.Message = ex.Message;
                tResult.Error = ErrorTypeEnum.Validation_EditQuestionDataNull;
                Log.Error(ex, "Validation failed: null value.");
            }
            catch (ArgumentOutOfRangeException ex)
            {

                tResult.Success = false;
                tResult.Message = ex.Message;
                tResult.Error = ErrorTypeEnum.Validation_OrderOutOfRangeEdit;
                Log.Error(ex, "Validation failed: value out of range.");
            }
            catch (ArgumentException ex)
            {

                tResult.Success = false;
                tResult.Message = ex.Message;
                tResult.Error = ErrorTypeEnum.Validation_QuestionTypeInvalid;
                Log.Error(ex, "Validation failed: invalid argument.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while edit a question a question with Id {Id}", pId);
                tResult.Success = false;
                tResult.Error = ErrorTypeEnum.UnknownErrorEditQuestion;
                tResult.Message = "An unexpected error occurred while edit your question. Please try again or contact support.";
            }
            
            
            return tResult;
        }
        public Result<int> EditOrder()
        {
            Result<int> tResult = new Result<int>();
            tResult.Success = true;
            tResult.Error = ErrorTypeEnum.None; 
            try
            {
                mQuestions.Sort();
                var tIds = new List<int>();
                var tOrders = new List<int>();

                for (int i = 0; i < mQuestions.Count; i++)
                {
                    tIds.Add(mQuestions[i].Id);
                    tOrders.Add(i + 1);
                    mQuestions[i].Order = i + 1;
                }
                if (mRepo.GetCount().Data > 0)
                {
                    tResult = mRepo.EditOrder(tIds, tOrders);
                    if (!tResult.Success)
                        return tResult; 
                    mRepo.UpdateLastModified();

                }
            }
            catch (Exception ex)
            {
                tResult.Success = false;
                tResult.Message = ex.Message;
                tResult.Error = ErrorTypeEnum.UnknownErrorEditOrder; 
                Log.Error(ex, "Error occurred while editing the order of mQuestions.");
                
            }
            return tResult; 
        }
        public List<Question> GetQuestionsList()
        {

            return mQuestions; 
        }
        
        public Result<Question> GetQuestion(int pId)
        {
            Result<Question> tResult = new Result<Question> { Success = true , Error=ErrorTypeEnum.None };
            try
            {
                foreach (var question in mQuestions)
                {
                    if (question.Id == pId) 
                    {
                        tResult.Data = question;
                        return tResult; 
                    
                    }
                }
                throw new KeyNotFoundException("The specified question was not found. Please check your selection.");

            }
            catch(KeyNotFoundException ex)
            {
                tResult.Success = false;
                tResult.Message = ex.Message;
                tResult.Error =ErrorTypeEnum.NotFound_GetQuestion;
            }
            catch (Exception ex)
            {
                tResult.Success = false;
                tResult.Message = ex.Message;
                tResult.Error = ErrorTypeEnum.UnknownErrorGetQuestion;
                Log.Error(ex, "Error occurred while retrieving the question with Id {Id}", pId);
                
            }
            return tResult;
        }

        public Result<int> GetCount()
        {
            Result<int> tResult = new Result<int> { Success =true , Error = ErrorTypeEnum.None , Data = 0 };
            try
            {
                tResult = mRepo.GetCount();
                
            }
            catch (Exception ex)
            {
                tResult.Success = false;
                tResult.Message = ex.Message;
                tResult.Error = ErrorTypeEnum.UnknownErrorGetCount;
                Log.Error(ex, "Error occurred while retrieving the question count from the repository.");
                
            }
            return tResult;
        }

        public Result<DateTime> GetLastModified()
        {
            Result<DateTime> tResult = new Result<DateTime>
            {
                Success = true,
                Error = ErrorTypeEnum.None,

            };
            try
            {
                tResult = mRepo.GetLastModified();
                return tResult;
                
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while retrieving the last modified .");
                tResult.Success = false;
                tResult.Message= ex.Message;
                tResult.Error= ErrorTypeEnum.UnknownErrorGetLastModified;
            }
            return tResult;
        }

        public Result<bool> ChangeConnectionString(string pConnectionString)
        {
            var tResult = new Result<bool>()
            {
                Success = true,
            };

            try
            {
                tResult = mRepo.ChangeConnectionString(pConnectionString);
                mConnectionValid = tResult.Success;
                return tResult;
            }
            catch (Exception ex)
            {

                Log.Error(ex, "Error occurred while Change Connection String  .");
                tResult.Success = false;
                tResult.Message = ex.Message;
                tResult.Error = ErrorTypeEnum.UnknownErrorChangeConnectionString;
            }
            return tResult;
        }
        public Result<bool> CheckConnection()
        {
            var tResult = new Result<bool>()
            {
                Success = true,
            };

            try
            {
                var tSavedConnection = ConfigurationManager.ConnectionStrings["DbConnectionString"]?.ConnectionString;

                if (!string.IsNullOrWhiteSpace(tSavedConnection))
                {
                    ChangeConnectionString(tSavedConnection);
                }
                tResult = new Result<bool>();
                if (mConnectionValid)
                {
                    tResult.Success = true;
                    tResult.Error = ErrorTypeEnum.None;
                }
                else
                {
                    tResult.Success = false;
                    tResult.Message = "Database connection is not set or invalid.\n Go to Settings → Database Connection to set it up.";
                    tResult.Error = ErrorTypeEnum.ConnectionStringNotSet;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while Check Connection  .");
                tResult.Success = false;
                tResult.Message = ex.Message;
                tResult.Error = ErrorTypeEnum.UnknownErrorConnectionTest;

            }
            return tResult; 
        }

        public void CheckForUpdates()
        {
            
                while (mIsRunning)
                {
                    var tResult = GetLastModified();
                    if (tResult.Success && tResult.Data != mDateTime)
                    {
                        mDateTime = tResult.Data;
                    //Invoke(ReloadMainForm);
                    CheckUpdateEvent?.Invoke();
                    }

                    Thread.Sleep(3000);
                }
            
        }
        private void CreateCheckThread()
        {

                mCheckForUpdate = new Thread(CheckForUpdates)
                {
                    IsBackground = true
                };
                mCheckForUpdate.Start();
            
        }
        public void FormClosing()
        {
            mIsRunning = false;
        }
        public Result<bool> ConnectionTest(string connectionString)
        {
            var tResult = new Result<bool>()
            {
                Success = true,
                Error = ErrorTypeEnum.None
            };

            try
            {
                tResult = mRepo.ConnectoinTest(connectionString);
                return tResult;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while testing connection.");
                tResult.Success = false;
                tResult.Message = ex.Message;
                tResult.Error = ErrorTypeEnum.UnknownErrorConnectionTest;
            }

            return tResult;
        }

        public Result<SqlConnectionStringBuilder> GetConnectionString()
        {
            var tResult = new Result<SqlConnectionStringBuilder>()
            {
                Success = true,
                Error = ErrorTypeEnum.None
            };

            try
            {
                var tConnectionString = mRepo.GetConnectionString();

                if (!tConnectionString.Success || string.IsNullOrEmpty(tConnectionString.Data))
                {
                    tResult.Success = false;
                    tResult.Message = tConnectionString.Message;
                    tResult.Error = tConnectionString.Error ;
                    return tResult;
                }

                var tSqlConnectionStringBuilder = new SqlConnectionStringBuilder(tConnectionString.Data);

                tResult.Data = tSqlConnectionStringBuilder;
                return tResult;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while retrieving the connection string.");
                tResult.Success = false;
                tResult.Message = ex.Message;
                tResult.Error = ErrorTypeEnum.UnknownErrorGetConnectionString;
            }

            return tResult;
        }



    }
}
