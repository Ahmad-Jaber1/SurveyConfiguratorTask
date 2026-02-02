using Microsoft.Extensions.Logging;
using Models;
using Serilog;
using SurveyConfiguratorTask.Models;
using SurveyConfiguratorTask.Repo;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Text;

namespace Services
{
    public class QuestionService 
    {
        QuestionRepo repo = new();
        List<Question> questions = new();
        
        public QuestionService()
        {
            questions = QuestionsLoadService();
        }

        public List<Question> QuestionsLoadService()
        {
            try
            {
                questions = repo.QuestionsLoad();
                if (questions is not null & questions.Count > 0)
                    questions.Sort();
                
                return questions;
            }
            catch (Exception ex) 
            {
                Log.Error(ex, "Error occurred while loading the question list.");
                throw; 
            }
        
        }
        public void AddQuestionService(TypeQuestionEnum type , AddQuestionDto questionDto)
        {
            try
            {
                if (questionDto is null)
                    throw new ArgumentNullException("Question data cannot be null.");
                int questionCount = repo.GetCount();


                Question question = null;
                //Create new question in local variable .
                //becasue each type of question has different fields
                //, we try to determine what type of question the user trying to add .
                switch ((int)type)
                {

                    case 0:
                        question = new SliderQuestion(questionDto.Text, questionDto.Order, questionDto.StartValue
                            , questionDto.EndValue, questionDto.StartCaption, questionDto.EndCaption);
                        break;
                    case 1:
                        question = new SmileyFacesQuestion(questionDto.Text, questionDto.Order, questionDto.SmileyCount);
                        break;
                    case 2:
                        question = new StarsQuestion(questionDto.Text, questionDto.Order, questionDto.StarsCount);
                        break;
                    _:
                        throw new ArgumentOutOfRangeException(nameof(type), "The selected question type is not supported.");
                        break;

                }
                // Validate that the user-selected order does not exceed the total number of questions

                if (questionDto.Order > GetCountService()+1 || questionDto.Order < 0)
                {
                    throw new IndexOutOfRangeException("Order value is invalid.");
                }

                
                questions.Insert(questionDto.Order - 1, question);

                if (questionDto.Order != questionCount+1 )
                {
                    EditOrder();
                }

                
                //Add new question to database.
                repo.AddQuestion(question);
                repo.UpdateLastModified();
               
            }
            
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while adding a question of type {Type}", (TypeQuestionEnum)type);
                throw;
            }
        }
        
        public void DeleteQuestionService(Guid id)
        {
            try
            {
                Question deletedQuestion = null; 
                foreach ( var question in questions)
                {
                    if (question.Id == id)
                    {
                        questions.Remove(question);
                        repo.DeleteQuestion(id);
                        // Reorder questions to maintain consistent ordering after deletion
                        EditOrder();
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
                Log.Error(ex, "Attempted to delete a question that does not exist. Id: {Id}", id);
                
                throw;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while deleting a question with Id {Id}", id);
                
                throw;
            }
        }
        public void EditQuestionService(Guid id ,EditContext editContext)
        {

            try
            {
                if (editContext is null)
                    throw new ArgumentNullException("Question data cannot be null.");

                Question question = null;
                foreach (var item in questions)
                {
                    if (item.Id == id)
                    {
                        question = item;
                    }
                }
                if (question is null)
                    throw new KeyNotFoundException("Question not found.");

                Question questionEdit = null;
                switch ((int)question.TypeQuestion)
                {

                    case 0:

                        questionEdit = new SliderQuestion(question.Id, editContext.Text, editContext.Order == 0 ? question.Order : editContext.Order, editContext.StartValue
                            , editContext.EndValue, editContext.StartCaption, editContext.EndCaption);
                        break;
                    case 1:
                        questionEdit = new SmileyFacesQuestion(question.Id, editContext.Text, editContext.Order == 0 ? question.Order : editContext.Order, editContext.SmileyCount);
                        break;
                    case 2:
                        questionEdit = new StarsQuestion(question.Id, editContext.Text, editContext.Order == 0 ? question.Order : editContext.Order, editContext.StarsCount);
                        break;
                     

                }
                // Validate that the user-selected order does not exceed the total number of questions

                if (questionEdit.Order > GetCountService() || questionEdit.Order <0)
                {
                    throw new IndexOutOfRangeException("Order value is invalid.");
                }
                 
                questions.Remove(question);
                questions.Insert(questionEdit.Order - 1, questionEdit);

                repo.EditQuestion(questionEdit);
                // Reorder all questions only when the question's order has been changed
                if (editContext.Order != 0)
                {
                    EditOrder();
                }
                repo.UpdateLastModified();


            }
            catch (KeyNotFoundException ex)
            {
                Log.Error(ex, "Attempted to edit a question that does not exist. Id: {0}", id);
                throw; 
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while editing a question with Id {Id}", id);
                throw; 
            }

        }

        public void EditOrder()
        {
            try
            {
                questions.Sort();
                var ids = new List<Guid>();
                var orders = new List<int>();

                for (int i = 0; i < questions.Count; i++)
                {
                    ids.Add(questions[i].Id);
                    orders.Add(i + 1);
                    questions[i].Order = i + 1;
                }
                if (repo.GetCount() > 0)
                {
                    repo.EditOrder(ids, orders);
                    repo.UpdateLastModified();

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while editing the order of questions.");
                throw;
            }
        }
        public List<Question> GetQuestionsList()
        {
            return questions; 
        }
        public Question GetQuestionService(Guid id)
        {
            try
            {
                foreach (var question in questions)
                {
                    if (question.Id == id)
                        return question;
                }
                throw new KeyNotFoundException("Question not found.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while retrieving the question with Id {Id}", id);
                throw;
            }
        }

        public int GetCountService()
        {
            try
            {
                return repo.GetCount();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while retrieving the question count from the repository.");
                throw;
            }
        }

        public DateTime GetLastModifiedService()
        {
            try
            {
                return repo.GetLastModified();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while retrieving the last modified from the repository.");
                throw;
            }
        }

        
    }
}
