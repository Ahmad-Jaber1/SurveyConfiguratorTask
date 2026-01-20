using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyConfiguratorTask
{
    public class SmileyFacesQuestion : Question
    {
        public int SmileyCount { get; private set; }
        public SmileyFacesQuestion(string text, int count) : base(text )
        {
            SetSmileyCount(count);
        }

        public void SetSmileyCount(int count)
        {
            

            if (count < 2 || count > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(count), $"Value must be between 2 and 5.");
            }
            SmileyCount = count;


        }
    }
}
