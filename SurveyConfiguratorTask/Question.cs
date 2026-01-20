using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace SurveyConfiguratorTask
{
    public abstract class Question
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }
        public static int OrderCount { get; private set; } = 0; 


        public Question(string text )
        {
            Id = Guid.NewGuid();
            if (text is null)
                throw new ArgumentNullException(nameof(text), $"Parameter {nameof(text)} must not be null. Please provide a valid value.");
            if (text == string.Empty)
                throw new ArgumentException($"Parameter {nameof(text)} can't be empty.", nameof(text));
            Text = text;
            Order = ++OrderCount ;
            

        }

        public static void ReorderList(List<Question> questions , Question questionNeedOrder , int newLocation)
        {
            if (newLocation > OrderCount)
                throw new ArgumentOutOfRangeException(nameof(newLocation), $"{newLocation} must be between 1 and {OrderCount}.");
            var question = questions.ElementAt(questionNeedOrder.Order - 1);
            questions.Remove(question);
            questions.Insert(newLocation-1 , question);

            foreach(var iteam in questions)
            {
                iteam.Order = questions.IndexOf(iteam) + 1;
            }

        }
        
        


    }
}
