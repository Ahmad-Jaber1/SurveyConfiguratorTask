using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class Result
    {
        public bool Success { get; set; }
        public ErrorTypeEnum Erorr { get; set; }
        public string Message { get; set; }
    }
}
