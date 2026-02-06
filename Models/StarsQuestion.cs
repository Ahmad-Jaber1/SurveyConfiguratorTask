using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyConfiguratorTask.Models
{
    /// <summary>
    /// Represent information type of question : Stars .
    /// </summary>
    public class StarsQuestion : Question
    {
        public int StarsCount { get; private set; }

        //Create StarsQuestion object with new unique identifier.
        public StarsQuestion(string text, int order,int count)
            :base(text ,  order,TypeQuestionEnum.StarsQuestion )
        {
            SetStarsCount(count);
        }
        //Initializes a StarsQuestion object from an existing data source.
        public StarsQuestion(int id,string text , int order , int starsCount)
            :base(id , text , order)
        {
            TypeQuestion = TypeQuestionEnum.StarsQuestion;
            SetStarsCount(starsCount);
        }

        public void SetStarsCount(int count)
        {
            //StarsCount must not be less than 1 or greater than 10
            if (count <= 0 || count > 10)
            {
                throw new ArgumentOutOfRangeException( "Stars  must be between 1 and 10.");
            }
            StarsCount = count;
        }

        
        public override void Show(Question question)
        {
            var temp = (StarsQuestion)question;
            Console.WriteLine("***************");
            Console.WriteLine($"Id:{temp.Id}");
            Console.WriteLine($"Order:{temp.Order}");
            Console.WriteLine($"Type:{temp.TypeQuestion}");
            Console.WriteLine($"Text:{temp.Text}");
            Console.WriteLine($"Count:{temp.StarsCount}");
            Console.WriteLine("***************");

        }

    }
}
