using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public static class SliderTable
    {
        public const string TableName = "SliderQuestion";
        public const string Id = "Id";
        public const string StartValue = "StartValue";
        public const string EndValue = "EndValue";
        public const string StartCaption = "StartCaption";
        public const string EndCaption = "EndCaption";
        public const string SelectColumns = $"{TableName}.{StartValue}, " +
            $"{TableName}.{EndValue}, " +
            $"{TableName}.{StartCaption}, " +
            $"{TableName}.{EndCaption} ";




    }
}
