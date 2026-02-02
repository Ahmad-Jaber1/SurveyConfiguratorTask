using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public static class QuestionsTable
    {
        public const string TableName = "Questions";
        public const string Id = "Id";
        public const string QuestionText = "QuestionText";
        public const string QuestionOrder = "QuestionOrder";
        public const string QuestionType = "QuestionType";
        public const string SelectColumns = $"{TableName}.{Id}," +
            $"{TableName}.{QuestionText}," +
            $"{TableName}.{QuestionOrder} ";
    }
}
