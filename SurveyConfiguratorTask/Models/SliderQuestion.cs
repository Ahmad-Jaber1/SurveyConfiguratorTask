using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyConfiguratorTask.Models
{
    public class SliderQuestion : Question
    {
        public int StartValue { get;  set; } = 0;
        public int EndValue { get;  set; } = 100;
        public string StartCaption { get;  set; }
        public string EndCaption { get;  set; }

        public SliderQuestion(string text  , int startValue, int endValue, string startCaption, string endCaption) 
            :base(text , TypeQuestionEnum.SliderQuestion)
        { 
            
            SetStartCaption(startCaption);
            SetEndCaption(endCaption);
            SetStartValue(startValue);
            SetEndValue(endValue);
            
        }
        
        public SliderQuestion(string text , int order , int startValue , int endValue 
            , string startCaption , string endCaption) : base(text ,  order )
        {
            
            SetText(text);
            SetOrder(order);
            
            TypeQuestion = TypeQuestionEnum.SliderQuestion;
            
            SetStartCaption(startCaption);
            SetEndCaption(endCaption);
            SetStartValue(startValue);
            SetEndValue(endValue);
            
            
        }

        public void SetStartValue(int value)
        {
            if (value < 0 || value >= EndValue)
            {
                throw new ArgumentOutOfRangeException(nameof(value) , $"{nameof(StartValue)} must be between 0 and {EndValue-1}.");
            }
            StartValue = value;

        }

        public void SetEndValue(int value)
        {
            
            if (value <= StartValue || value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(EndValue)} must be between {StartValue+1} and 100.");
            }
            
            EndValue = value;

        }

        public void SetStartCaption(string caption)
        {
            
            if (caption is null)
                throw new ArgumentNullException(nameof(caption), $"Parameter {nameof(caption)} must not be null. Please provide a valid value.");
            if (caption == string.Empty)
                throw new ArgumentException($"Parameter {nameof(caption)} can't be empty.", nameof(caption));
            StartCaption = caption;

        }

        public void SetEndCaption(string caption)
        {
            if (caption is null)
                throw new ArgumentNullException(nameof(caption), $"Parameter {nameof(caption)} must not be null. Please provide a valid value.");
            if (caption == string.Empty)
                throw new ArgumentException($"Parameter {nameof(caption)} can't be empty.", nameof(caption));

            EndCaption = caption;
            
        }

        public override void EditQuestion(EditContext context, List<Question> questions)
        {
            base.SetText(context.Text);
            SetStartValue(context.StartValue);
            SetEndValue(context.EndValue);

            SetStartCaption(context.StartCaption);
            SetEndCaption(context.EndCaption);

            this.ChangeQuestionOrder(questions, context.Order);
        }

        public override void Show( Question question)
        {
            var temp = (SliderQuestion)question;
            Console.WriteLine($"{temp.Text}- Order : {temp.Order}\n{temp.StartCaption}-{temp.StartValue}------------{temp.EndValue}-{temp.EndCaption}");
        }
    }
}
