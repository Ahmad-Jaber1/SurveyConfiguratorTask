using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyConfiguratorTask.Models
{
    public static class QuestionExtensions
    {
        public static void ChangeQuestionOrder(this Question questionToMove , List<Question> questions , int newLocation)
        {
            if (newLocation > Question.OrderCount || newLocation < 1)
                throw new ArgumentOutOfRangeException(nameof(newLocation), $"{nameof(newLocation)} must be between 1 and {Question.OrderCount}.");

            var question = questions.ElementAt(questionToMove.Order - 1);
            questions.Remove(question);
            questions.Insert(newLocation - 1, question);
            Question.ReorderQuestions(questions);


        }
        public static void DeleteQuestion(this Question questionToDelete , List<Question> questions)
        {
            questions.Remove(questionToDelete);
            Question.ReorderQuestions(questions);

        }

        
        
    }
}
