using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyConfiguratorTask.Models
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

        public override void  EditQuestion(EditContext context, List<Question> questions)
        {
            base.SetText(context.Text);
            SetStarsCount(context.StarsCount);
            this.ChangeQuestionOrder(questions, context.Order);
        }
        public override void Show(Question question)
        {
            var temp = (StarsQuestion)question;
            Console.WriteLine($"{temp.Text}- Order : {temp.Order}\nCount ={temp.StarsCount}");
        }

    }
}
