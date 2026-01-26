using Models;
using SurveyConfiguratorTask.Models;
using SurveyConfiguratorTask.Repo;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            questions = repo.QuestionsLoad();
            questions.Sort();
            return questions;
        }
        public void AddQuestionService(TypeQuestionEnum type , AddQuestionDto questionDto)
        {
            var questionCount = repo.GetCount();
            Question question =null;
            switch ((int)type)
            {
                 
                case 0:
                    question = new SliderQuestion(questionDto.Text, questionCount + 1, questionDto.StartValue
                        , questionDto.EndValue, questionDto.StartCaption, questionDto.EndCaption);
                    break;
                case 1:
                    question = new SmileyFacesQuestion(questionDto.Text, questionCount + 1, questionDto.SmileyCount);
                    break;
                case 2:
                    question = new StarsQuestion(questionDto.Text, questionCount + 1, questionDto.StarsCount);
                    break;

            }
            questions.Add(question);
            repo.AddQuestion(question);
            

        }

        public void DeleteQuestionService(Guid id)
        {
            repo.DeleteQuestion(id);
            foreach(var question in questions)
            {
                if(question.Id == id)
                {
                    questions.Remove(question);
                    break; 
                }
            }
            questions.Sort();
            var ids = new List<Guid>();
            var orders = new List<int>();
            foreach(var question in questions)
            {
                ids.Add(question.Id);
                orders.Add(question.Order);
            }
            repo.EditOrder(ids , orders);
        }
        public void EditQuestionService(Guid id ,EditContext editContext)
        {
            Question question = null; 
            foreach (var item in questions)
            {
                if (item.Id == id)
                {
                    question = item;
                }
            }
            Question questionEdit = null; 
            switch ((int)question.TypeQuestion)
            {

                case 0:
                     
                    questionEdit = new SliderQuestion(question.Id , editContext.Text , editContext.Order == 0 ? question.Order : editContext.Order , editContext.StartValue
                        ,editContext.EndValue ,editContext.StartCaption , editContext.EndCaption );
                    break;
                case 1:
                    questionEdit = new SmileyFacesQuestion(question.Id, editContext.Text, editContext.Order == 0 ? question.Order : editContext.Order, editContext.SmileyCount);
                    break;
                case 2:
                    questionEdit = new StarsQuestion(question.Id,editContext.Text, editContext.Order == 0 ? question.Order : editContext.Order, editContext.StarsCount);
                    break;

            }
            questions.Remove(question);
            questions.Insert(questionEdit.Order -1 , questionEdit);
            repo.EditQuestion(questionEdit);
            if(editContext.Order != 0)
            {
                var ids = new List<Guid>();
                var orders = new List<int>();
                
                for(int i = 0; i < questions.Count; i++)
                {
                    ids.Add(questions[i].Id);
                    orders.Add(i+1);
                    questions[i].Order = i+1;
                }
                repo.EditOrder(ids, orders);
            }
            questions.Sort();
            
        }

        public void EditOrder()
        {
            questions.Sort();
            var ids = new List<Guid>();
            var orders = new List<int>();

            for (int i = 0; i < questions.Count; i++)
            {
                ids.Add(questions[i].Id);
                orders.Add(i + 1);
                questions[i].Order = i+1;
            }
            repo.EditOrder(ids , orders);
            //QuestionsLoadService();
        }
        public List<Question> GetQuestionsList()
        {
            return questions; 
        }

    }
}
