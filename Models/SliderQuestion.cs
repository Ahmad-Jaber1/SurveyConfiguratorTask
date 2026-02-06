using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SurveyConfiguratorTask.Models
{
    /// <summary>
    /// Represent information type of question : slider .
    /// </summary>
    public class SliderQuestion : Question
    {
        public int StartValue { get;  set; } = 0;
        public int EndValue { get;  set; } = 100;
        public string StartCaption { get;  set; }
        public string EndCaption { get;  set; }

        //Create SliderQuestion object with new unique identifier.
        public SliderQuestion(string text  , int order,int startValue, int endValue, string startCaption, string endCaption) 
            :base(text , order,TypeQuestionEnum.SliderQuestion)
        { 
            
            SetStartCaption(startCaption);
            SetEndCaption(endCaption);
            SetStartValue(startValue);
            SetEndValue(endValue);
            
        }
        //Initializes a SliderQuestion object from an existing data source.
        public SliderQuestion(int id,string text , int order , int startValue , int endValue 
            , string startCaption , string endCaption) : base(id, text ,  order )
        {
            TypeQuestion = TypeQuestionEnum.SliderQuestion;
            SetStartCaption(startCaption);
            SetEndCaption(endCaption);
            SetStartValue(startValue);
            SetEndValue(endValue); 
        }

        public void SetStartValue(int value)
        {
            //Start value must not be negative or greater than end value.
            if (value < 0 || value >= EndValue)
            {
                throw new ArgumentOutOfRangeException(null, $"{nameof(StartValue)} must be between 0 and {EndValue-1}.");
            }
            StartValue = value;

        }

        public void SetEndValue(int value)
        {
            //End value must not be grater than 100 or less than start value.
            if (value <= StartValue || value > 100)
            {
                throw new ArgumentOutOfRangeException( null , $"End value must be between {StartValue + 1} and 100. Please enter a valid number.");
            }

            EndValue = value;

        }

        public void SetStartCaption(string caption)
        {
            //Caption must not be null or empty.
            if (caption is null)
                throw new ArgumentNullException( null , "Please enter a caption. It cannot be empty.");

            if (caption == string.Empty)
                throw new ArgumentException( "Please enter a caption. It cannot be empty."  );
            StartCaption = caption;

        }

        public void SetEndCaption(string caption)
        {
            //Caption must not be null or empty.
            if (caption is null)
                throw new ArgumentNullException( "Please enter a caption. It cannot be empty.");
            if (caption == string.Empty)
                throw new ArgumentException( "Please enter a caption. It cannot be empty.");

            EndCaption = caption;
            
        }

        

        public override void Show(Question question)
        {
            var temp = (SliderQuestion)question;
            Console.WriteLine("***************");
            Console.WriteLine($"Id:{temp.Id}");
            Console.WriteLine($"Order:{temp.Order}");
            Console.WriteLine($"Type:{temp.TypeQuestion}");
            Console.WriteLine($"Text:{temp.Text}");
            Console.WriteLine($"StartValue:{temp.StartValue} And StartCaption: {temp.StartCaption}");
            Console.WriteLine($"StartValue:{temp.EndValue} And StartCaption: {temp.EndCaption}");
            Console.WriteLine("***************");

        }
    }
}
