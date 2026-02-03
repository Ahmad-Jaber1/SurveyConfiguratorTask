using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public enum ErrorTypeEnum
    {
        None = 0,
        DatabaseError,
        ValidationError,
        UnknownError = 100
    }
}
