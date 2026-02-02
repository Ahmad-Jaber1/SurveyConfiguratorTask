using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public static class SmileyFacesTable
    {
        public const string TableName = "SmileyFacesQuestion";
        public const string Id = "Id";
        public const string SmileyCount = "SmileyCount";
        public const string SelectColumns = $"{TableName}.{SmileyCount}";



    }
}
