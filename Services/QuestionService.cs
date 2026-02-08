using Microsoft.Extensions.Logging;
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
using System.Text;

namespace Services
{
    public class QuestionService 
    {
        QuestionRepo repo = new();
        List<Question> questions;
        private bool _connectionValid;
        public event Action CheckUpdateEvent;
        private DateTime dateTime = DateTime.Now;
        Thread checkForUpdate;
        bool isRunning = true; 



        public QuestionService()
        {
            questions = new List<Question>();
            CreateCheckThread();

        }

        public Result<List<Question>> QuestionsLoad()
        {
            Result<List<Question>> result = new Result<List<Question>> { Success = true , Erorr = ErrorTypeEnum.None };
            try
            {
                result = repo.QuestionsLoad();
                if (!result.Success)
                {
                     
                    return result;

                }
                questions = repo.QuestionsLoad().Data;
                

                if (questions is not null & questions.Count > 0)
                    questions.Sort();
                result.Data = questions; 
                return result;
            }
            catch (Exception ex) 
            {
                result.Success = false;
                result.Erorr = ErrorTypeEnum.UnknownError;
                result.Message = ex.Message;
                Log.Error(ex, "Error occurred while loading the question list.");
                 
            }
            return result; 
        
        }
        public Result<int> AddQuestion(TypeQuestionEnum type , AddQuestionDto questionDto)
        {
            Result<int> result = new Result<int> { Erorr = ErrorTypeEnum.None , Success = true , Data = 0};
            try
            {
                if (questionDto is null)
                    throw new ArgumentNullException(null , "Question data cannot be empty. Please provide a valid question.");

                int questionCount = repo.GetCount().Data;


                Question question = null;
                //Create new question in local variable .
                //becasue each type of question has different fields
                //, we try to determine what type of question the user trying to add .
                switch (type)
                {

                    case TypeQuestionEnum.SliderQuestion:
                        question = new SliderQuestion(questionDto.Text, questionDto.Order, questionDto.StartValue
                            , questionDto.EndValue, questionDto.StartCaption, questionDto.EndCaption);
                        break;
                    case TypeQuestionEnum.SmileyFacesQuestion:
                        question = new SmileyFacesQuestion(questionDto.Text, questionDto.Order, questionDto.SmileyCount);
                        break;
                    case TypeQuestionEnum.StarsQuestion:
                        question = new StarsQuestion(questionDto.Text, questionDto.Order, questionDto.StarsCount);
                        break;
                    _:
                        throw new ArgumentOutOfRangeException(null , "The selected question type is not valid. Please choose a supported type.");
                        break;

                }
                // Validate that the user-selected order does not exceed the total number of questions
                var countResult = GetCount();
                if (!countResult.Success)
                    return countResult;
                if (questionDto.Order > countResult.Data+1 || questionDto.Order <= 0)
                {
                    throw new ArgumentOutOfRangeException(null,$"Order value must be between 1 and {countResult.Data + 1}. Please enter a valid number.");
                }
                
                
                questions.Insert(questionDto.Order - 1, question);

                //Add new question to database.

                result = repo.AddQuestion(question);
                if (!result.Success)
                    return result;

                if (questionDto.Order != questionCount+1 )
                {
                    result = EditOrder();
                    if (!result.Success)
                        return result; 
                }

                
                

                
                    repo.UpdateLastModified();
               
            }
            
            catch (ArgumentNullException ex)
            {
                
                result.Success = false;
                result.Message = ex.Message;
                result.Erorr = ErrorTypeEnum.ValidationError;
                Log.Error(ex, "Validation failed: null value.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                
                result.Success = false;
                result.Message = ex.Message;
                result.Erorr = ErrorTypeEnum.ValidationError;
                Log.Error(ex, "Validation failed: value out of range.");
            }
            catch (ArgumentException ex)
            {
                
                result.Success = false;
                result.Message = ex.Message;
                result.Erorr = ErrorTypeEnum.ValidationError;
                Log.Error(ex, "Validation failed: invalid argument.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while adding a question of type {Type}", (TypeQuestionEnum)type);
                result.Success=false;
                result.Erorr=ErrorTypeEnum.UnknownError;
                result.Message = "An unexpected error occurred while adding your question. Please try again or contact support.";
            }
            return result;
        }
        
        public Result<int> DeleteQuestion(int id)
        {
            Result<int> result = new Result<int>();
            result.Success = true;
            result.Erorr = ErrorTypeEnum.None;
            result.Data = 0;
            try
            {
                Question deletedQuestion = null; 
                foreach ( var question in questions)
                {
                    if (question.Id == id)
                    {
                        
                            repo.DeleteQuestion(id); 
                        if(!result.Success)
                            return result;
                        questions.Remove(question);


                        // Reorder questions to maintain consistent ordering after deletion
                        result = EditOrder();
                        if (!result.Success)
                            return result; 
                        deletedQuestion = question;
                        repo.UpdateLastModified();

                        break;
                    }
                   
                }
                if (deletedQuestion is null)
                    throw new KeyNotFoundException("Question not found.");
                
            }
            catch (KeyNotFoundException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                result.Erorr = ErrorTypeEnum.NotFoundError;
                Log.Error(ex, "Attempted to delete a question that does not exist. Id: {Id}", id);
                
                
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                result.Erorr = ErrorTypeEnum.UnknownError;
                Log.Error(ex, "Error occurred while deleting a question with Id {Id}", id);
                
                
            }
            return result; 
        }
        public Result<int> EditQuestion(int id , EditQuestionDto editContext)
        {
            Result<int> result = new Result<int> { Success = true , Erorr = ErrorTypeEnum.None , Data = 0};
            try
            {
                if (editContext is null)
                    throw new ArgumentNullException( null , "Please provide a question. This field cannot be empty.");


                Question question = null;
                //var getQuestionResult  = repo.GetQuestion(id);
                //if (!getQuestionResult.Success)
                //{
                //    result.Erorr = ErrorTypeEnum.UnknownError;
                //    result.Message = getQuestionResult.Message;
                //    result.Success = false; 
                //    return result;
                //}
                
                foreach (var item in questions)
                {
                    if (item.Id == id)
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

                        questionEdit = new SliderQuestion(question.Id, editContext.Text, editContext.Order == 0 ? question.Order : editContext.Order, editContext.StartValue
                            , editContext.EndValue, editContext.StartCaption, editContext.EndCaption);
                        break;
                    case TypeQuestionEnum.SmileyFacesQuestion:
                        questionEdit = new SmileyFacesQuestion(question.Id, editContext.Text, editContext.Order == 0 ? question.Order : editContext.Order, editContext.SmileyCount);
                        break;
                    case TypeQuestionEnum.StarsQuestion:
                        questionEdit = new StarsQuestion(question.Id, editContext.Text, editContext.Order == 0 ? question.Order : editContext.Order, editContext.StarsCount);
                        break;
                     

                }
                result = GetCount();
                if (!result.Success)
                    return result; 
                // Validate that the user-selected order does not exceed the total number of questions

                if (questionEdit.Order > result.Data || questionEdit.Order <= 0)
                {
                    throw new ArgumentOutOfRangeException(null , $"Order value must be between 1 and {result.Data}. Please enter a valid number.");

                }

                
                result  = repo.EditQuestion(questionEdit);
                if (!result.Success)
                    return result;

                questions.Remove(question);
                questions.Insert(questionEdit.Order - 1, questionEdit);

                // Reorder all questions only when the question's order has been changed
                if (editContext.Order != 0)
                {
                    result = EditOrder();
                    if(!result.Success)
                            return result;
                }
                repo.UpdateLastModified();


            }
            catch (KeyNotFoundException ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                result.Erorr = ErrorTypeEnum.NotFoundError;
                Log.Error(ex, "Attempted to edit a question a question with Id {Id}", id);
                
            }
            catch (ArgumentNullException ex)
            {

                result.Success = false;
                result.Message = ex.Message;
                result.Erorr = ErrorTypeEnum.ValidationError;
                Log.Error(ex, "Validation failed: null value.");
            }
            catch (ArgumentOutOfRangeException ex)
            {

                result.Success = false;
                result.Message = ex.Message;
                result.Erorr = ErrorTypeEnum.ValidationError;
                Log.Error(ex, "Validation failed: value out of range.");
            }
            catch (ArgumentException ex)
            {

                result.Success = false;
                result.Message = ex.Message;
                result.Erorr = ErrorTypeEnum.ValidationError;
                Log.Error(ex, "Validation failed: invalid argument.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while edit a question a question with Id {Id}", id);
                result.Success = false;
                result.Erorr = ErrorTypeEnum.UnknownError;
                result.Message = "An unexpected error occurred while edit your question. Please try again or contact support.";
            }
            
            
            return result;
        }
        public Result<int> EditOrder()
        {
            Result<int> result = new Result<int>();
            result.Success = true;
            result.Erorr = ErrorTypeEnum.None; 
            try
            {
                questions.Sort();
                var ids = new List<int>();
                var orders = new List<int>();

                for (int i = 0; i < questions.Count; i++)
                {
                    ids.Add(questions[i].Id);
                    orders.Add(i + 1);
                    questions[i].Order = i + 1;
                }
                if (repo.GetCount().Data > 0)
                {
                    result = repo.EditOrder(ids, orders);
                    if (!result.Success)
                        return result; 
                    repo.UpdateLastModified();

                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                result.Erorr = ErrorTypeEnum.UnknownError; 
                Log.Error(ex, "Error occurred while editing the order of questions.");
                
            }
            return result; 
        }
        public List<Question> GetQuestionsList()
        {

            return questions; 
        }
        
        public Result<Question> GetQuestion(int id)
        {
            Result<Question> result = new Result<Question> { Success = true , Erorr=ErrorTypeEnum.None };
            try
            {
                foreach (var question in questions)
                {
                    if (question.Id == id) 
                    {
                        result.Data = question;
                        return result; 
                    
                    }
                }
                throw new KeyNotFoundException("The specified question was not found. Please check your selection.");

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                result.Erorr = ErrorTypeEnum.NotFoundError;
                Log.Error(ex, "Error occurred while retrieving the question with Id {Id}", id);
                
            }
            return result;
        }

        public Result<int> GetCount()
        {
            Result<int> result = new Result<int> { Success =true , Erorr = ErrorTypeEnum.None , Data = 0 };
            try
            {
                result = repo.GetCount();
                
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
                result.Erorr = ErrorTypeEnum.UnknownError;
                Log.Error(ex, "Error occurred while retrieving the question count from the repository.");
                
            }
            return result;
        }

        public Result<DateTime> GetLastModified()
        {
            Result<DateTime> result = new Result<DateTime>
            {
                Success = true,
                Erorr = ErrorTypeEnum.None,

            };
            try
            {
                result = repo.GetLastModified();
                return result;
                
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while retrieving the last modified .");
                result.Success = false;
                result.Message= ex.Message;
                result.Erorr= ErrorTypeEnum.UnknownError;
            }
            return result;
        }

        public Result<bool> ChangeConnectionString(string connectionString)
        {
            var result = repo.ChangeConnectionString(connectionString);
            _connectionValid = result.Success;
            return result;
        }
        public Result<bool> CheckConnection()
        {
            var savedConnection = ConfigurationManager.ConnectionStrings["DbConnectionString"]?.ConnectionString;

            if (!string.IsNullOrWhiteSpace(savedConnection))
            {
                ChangeConnectionString(savedConnection);
            }
            var result = new Result<bool>();
            if( _connectionValid)
            {
                result.Success = true;
                result.Erorr = ErrorTypeEnum.None;
            }
            else
            {
                result.Success = false;
                result.Message = "Database connection is not set or invalid.\n Go to Settings → Database Connection to set it up.";
                result.Erorr = ErrorTypeEnum.ConnectionStringError; 
            }
            return result; 
        }

        public void CheckForUpdates()
        {
            
                while (isRunning)
                {
                    var result = GetLastModified();
                    if (result.Success && result.Data != dateTime)
                    {
                        dateTime = result.Data;
                    //Invoke(ReloadMainForm);
                    CheckUpdateEvent?.Invoke();
                    }

                    Thread.Sleep(3000);
                }
            
        }
        private void CreateCheckThread()
        {
            
                checkForUpdate = new Thread(CheckForUpdates)
                {
                    IsBackground = true
                };
                checkForUpdate.Start();
            
        }
        public void FormClosing()
        {
            isRunning = false;
        }


    }
}
