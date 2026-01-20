using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyConfiguratorTask
{
    public class StarsQuestion : Question
    {
        public int StarsCount { get; private set; }
        public StarsQuestion(string text, int count):base(text )
        {
            SetStarsCount(count);
        }

        public void SetStarsCount(int count)
        {
            if (count <= 0 || count > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(count), $"Value must be between 1 and 10.");
            }
            StarsCount = count;
        }

    }
}
