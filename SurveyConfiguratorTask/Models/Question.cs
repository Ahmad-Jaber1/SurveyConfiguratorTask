using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SurveyConfiguratorTask.Models
{
    public  abstract class Question
    {
        public Guid Id { get;  }
        public string Text { get;  set; }
        public int Order { get;  set;  }
        public TypeQuestionEnum TypeQuestion { get;  set; }
        public static int OrderCount { get;  set; } = 0; 


        public Question(string text , TypeQuestionEnum type)
        {
            Id = Guid.NewGuid();
            SetText(text);
            Order = ++OrderCount;
            TypeQuestion = type; 


        }
        public Question(string text, int order)
        {
            Id = Guid.NewGuid();
            SetText(text);
            Order = order;
            

        }
        public void SetText(string text)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text), $"Parameter {nameof(text)} must not be null. Please provide a valid value.");
            if (text == string.Empty)
                throw new ArgumentException($"Parameter {nameof(text)} can't be empty.", nameof(text));

            Text = text; 
        }
        protected void SetOrder(int order)
        {
            Order = order; 
        }
        public static void ReorderQuestions(List<Question> questions)
        {
            foreach (var iteam in questions)
            {
                iteam.Order = questions.IndexOf(iteam) + 1;
            }
        }

        public abstract void EditQuestion(EditContext context, List<Question> questions);
        public abstract void Show( Question question);

        


    }
}
