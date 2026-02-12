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
        public SliderQuestion(string pText  , int pOrder,int pStartValue, int pEndValue, string pStartCaption, string pEndCaption) 
            :base(pText , pOrder,TypeQuestionEnum.SliderQuestion)
        { 
            
            SetStartCaption(pStartCaption);
            SetEndCaption(pEndCaption);
            SetStartValue(pStartValue);
            SetEndValue(pEndValue);
            
        }
        //Initializes a SliderQuestion object from an existing data source.
        public SliderQuestion(int pId,string pText , int pOrder , int pStartValue , int pEndValue 
            , string pStartCaption , string pEndCaption) : base(pId, pText ,  pOrder )
        {
            TypeQuestion = TypeQuestionEnum.SliderQuestion;
            SetStartCaption(pStartCaption);
            SetEndCaption(pEndCaption);
            SetStartValue(pStartValue);
            SetEndValue(pEndValue); 
        }

        public void SetStartValue(int pValue)
        {
            //Start pValue must not be negative or greater than end pValue.
            if (pValue < 0 || pValue >= EndValue)
            {
                throw new ArgumentOutOfRangeException(null, $"{nameof(StartValue)} must be between 0 and {EndValue-1}.");
            }
            StartValue = pValue;

        }

        public void SetEndValue(int pValue)
        {
            //End pValue must not be grater than 100 or less than start pValue.
            if (pValue <= StartValue || pValue > 100)
            {
                throw new ArgumentOutOfRangeException( null , $"End pValue must be between {StartValue + 1} and 100. Please enter a valid number.");
            }

            EndValue = pValue;

        }

        public void SetStartCaption(string pCaption)
        {
            //Caption must not be null or empty.
            if (pCaption is null)
                throw new ArgumentNullException( null , "Please enter a pCaption. It cannot be empty.");

            if (pCaption == string.Empty)
                throw new ArgumentException( "Please enter a pCaption. It cannot be empty."  );
            StartCaption = pCaption;

        }

        public void SetEndCaption(string pCaption)
        {
            //Caption must not be null or empty.
            if (pCaption is null)
                throw new ArgumentNullException( "Please enter a pCaption. It cannot be empty.");
            if (pCaption == string.Empty)
                throw new ArgumentException( "Please enter a pCaption. It cannot be empty.");

            EndCaption = pCaption;
            
        }

        

        
    }
}
