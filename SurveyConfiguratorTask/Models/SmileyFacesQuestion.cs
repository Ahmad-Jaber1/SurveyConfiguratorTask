using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyConfiguratorTask.Models
{
    public class SmileyFacesQuestion : Question
    {
        public int SmileyCount { get; private set; }
        public SmileyFacesQuestion(string text,int count) : base(text,TypeQuestionEnum.SmileyFacesQuestion )
        {
            SetSmileyCount(count);
        }
        public SmileyFacesQuestion(string text , int order , int count) : base(text , order )
        {
            
            SetSmileyCount(count);
            SetOrder(order);
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
            Console.WriteLine($"{temp.Text} - Order : {temp.Order}\nCount = {temp.SmileyCount}");
        }

    }
}
