using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyConfiguratorTask.Models
{
    public class SmileyFacesQuestion : Question
    {
        public int SmileyCount { get; private set; }
        public SmileyFacesQuestion(string text,int order,int count) : base(text, order,TypeQuestionEnum.SmileyFacesQuestion )
        {
            SetSmileyCount(count);
        }
        public SmileyFacesQuestion(Guid id, string text , int order , int count) : base(id, text , order )
        {
            
            SetSmileyCount(count);
           
            TypeQuestion = TypeQuestionEnum.SmileyFacesQuestion;
        }

        public void SetSmileyCount(int count)
        {
            

            if (count < 2 || count > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(count), $"Value must be between 2 and 5.");
            }
            SmileyCount = count;


        }

        public override void EditQuestion(EditContext context, List<Question> questions)
        {
            base.SetText(context.Text);
            SetSmileyCount(context.SmileyCount);
            this.ChangeQuestionOrder(questions, context.Order);
        }

        public override void Show(Question question)
        {
            var temp = (SmileyFacesQuestion)question;
            Console.WriteLine("***************");
            Console.WriteLine($"Id:{temp.Id}");
            Console.WriteLine($"Order:{temp.Order}");
            Console.WriteLine($"Type:{temp.TypeQuestion}");
            Console.WriteLine($"Text:{temp.Text}");
            Console.WriteLine($"Count:{temp.SmileyCount}");
            Console.WriteLine("***************");

        }

    }
}
