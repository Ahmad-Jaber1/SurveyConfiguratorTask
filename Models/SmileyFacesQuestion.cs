using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyConfiguratorTask.Models
{
    /// <summary>
    /// Represent information type of question : Smiley Faces .
    /// </summary>
    public class SmileyFacesQuestion : Question
    {
        public int SmileyCount { get; private set; }

        //Create SmileyFacesQuestion object with new unique identifier.
        public SmileyFacesQuestion(string text,int order,int count) 
            : base(text, order,TypeQuestionEnum.SmileyFacesQuestion )
        {
            SetSmileyCount(count);
        }
        //Initializes a SmileyFacesQuestion object from an existing data source.
        public SmileyFacesQuestion(int id, string text , int order , int count) 
            : base(id, text , order )
        {
            
            SetSmileyCount(count);
           
            TypeQuestion = TypeQuestionEnum.SmileyFacesQuestion;
        }

        public void SetSmileyCount(int count)
        {
            
            //SmileyCount must not be less than 2 or greater than 5 
            if (count < 2 || count > 5)
            {
                throw new ArgumentOutOfRangeException( "Smiley faces  must be between 2 and 5.");

            }
            SmileyCount = count;


        }

        

        

    }
}
