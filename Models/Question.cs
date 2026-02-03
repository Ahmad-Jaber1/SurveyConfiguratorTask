using System;
using System.Collections.Generic;
using System.Text;


namespace SurveyConfiguratorTask.Models
{
    /// <summary>
    /// Represent general info about question object .
    /// </summary>

    public  abstract class Question : IComparable<Question>
    {
        public Guid Id { get;  }
        public string Text { get;  set; }
        public int Order { get;  set;  }
        public TypeQuestionEnum TypeQuestion { get;  set; }


        //Create question object with new unique identifier.
        public Question(string text , int order,TypeQuestionEnum type)
        {
            Id = Guid.NewGuid();
            SetText(text);
            Order = order;
            TypeQuestion = type; 
        }
        //Initializes a Question object from an existing data source.
        public Question(Guid id, string text, int order)
        {
            Id = id; 
            SetText(text);
            Order = order;
           
        }
        public void SetText(string text)
        {
            //Text must not be null or empty.
            if (text is null)
                throw new ArgumentNullException( "The text cannot be empty. Please enter a valid value." );
            if (text == string.Empty)
                throw new ArgumentException( "The text cannot be empty. Please enter a valid value.");
            
            Text = text; 
        }
        protected void SetOrder(int order)
        { 
            Order = order; 
        }
        
        
        public abstract void Show( Question question);

        //For sort question list based on order.
        int IComparable<Question>.CompareTo(Question other)
        {
            return Order.CompareTo(other.Order);
        }
    }
}
