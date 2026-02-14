using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public static class DbConsts
    {
        public const string SliderTableName = "SliderQuestion";
        public const string SliderId = "Id";
        public const string SliderStartValue = "StartValue";
        public const string SliderEndValue = "EndValue";
        public const string SliderStartCaption = "StartCaption";
        public const string SliderEndCaption = "EndCaption";
        public const string SliderSelectColumns = $"{SliderTableName}.{SliderStartValue}, " +
            $"{SliderTableName}.{SliderEndValue}, " +
            $"{SliderTableName}.{SliderStartCaption}, " +
            $"{SliderTableName}.{SliderEndCaption} ";
        public const string SmileyTableName = "SmileyFacesQuestion";
        public const string SmileyId = "Id";
        public const string SmileySmileyCount = "SmileyCount";
        public const string SmileySelectColumns = $"{SmileyTableName}.{SmileySmileyCount}";

        public const string StarsTableName = "StarsQuestion";
        public const string StarsId = "Id";
        public const string StarsStarsCount = "StarsCount";
        public const string StarsSelectColumns = $"{StarsTableName}.{StarsStarsCount}";
        
        public const string DatabaseChangeTableName = "DatabaseChangeTracker";
        public const string DatabaseChangeLastModified = "LastModified";

        public const string QuestionsTableName = "Questions";
        public const string QuestionsId = "Id";
        public const string QuestionsQuestionText = "QuestionText";
        public const string QuestionsQuestionOrder = "QuestionOrder";
        public const string QuestionsQuestionType = "QuestionType";
        public const string QuestionsSelectColumns = $"{QuestionsTableName}.{QuestionsId}," +
            $"{QuestionsTableName}.{QuestionsQuestionText}," +
            $"{QuestionsTableName}.{QuestionsQuestionOrder} ";
    }
}
