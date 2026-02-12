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
        public SmileyFacesQuestion(string pText,int pOrder,int pCount) 
            : base(pText, pOrder,TypeQuestionEnum.SmileyFacesQuestion )
        {
            SetSmileyCount(pCount);
        }
        //Initializes a SmileyFacesQuestion object from an existing data source.
        public SmileyFacesQuestion(int pId, string pText , int pOrder , int pCount) 
            : base(pId, pText , pOrder )
        {
            
            SetSmileyCount(pCount);
           
            TypeQuestion = TypeQuestionEnum.SmileyFacesQuestion;
        }

        public void SetSmileyCount(int pCount)
        {
            
            //SmileyCount must not be less than 2 or greater than 5 
            if (pCount < 2 || pCount > 5)
            {
                throw new ArgumentOutOfRangeException( "Smiley faces  must be between 2 and 5.");

            }
            SmileyCount = pCount;


        }

        

        

    }
}
