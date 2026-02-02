using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public static class StarsTable
    {
        public const string TableName = "StarsQuestion";
        public const string Id = "Id";
        public const string StarsCount = "StarsCount";
        public const string SelectColumns = $"{TableName}.{StarsCount}";

    }
}
