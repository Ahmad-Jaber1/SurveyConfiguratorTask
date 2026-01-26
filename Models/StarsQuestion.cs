using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyConfiguratorTask.Models
{
    public class StarsQuestion : Question
    {
        public int StarsCount { get; private set; }
        public StarsQuestion(string text, int order,int count):base(text ,  order,TypeQuestionEnum.StarsQuestion )
        {
            SetStarsCount(count);
        }
        public StarsQuestion(Guid id,string text , int order , int starsCount):base(id , text , order)
        {
            TypeQuestion = TypeQuestionEnum.StarsQuestion;
            SetStarsCount(starsCount);
        }

        public void SetStarsCount(int count)
        {
            if (count <= 0 || count > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(count), $"Value must be between 1 and 10.");
            }
            StarsCount = count;
        }

        public override void  EditQuestion(EditContext context, List<Question> questions)
        {
            base.SetText(context.Text);
            SetStarsCount(context.StarsCount);
            this.ChangeQuestionOrder(questions, context.Order);
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
