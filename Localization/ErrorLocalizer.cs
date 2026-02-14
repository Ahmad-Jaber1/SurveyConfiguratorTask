using Localization;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Text;

namespace Shared
{
    public static class ErrorLocalizer
    {
        

        public static string GetMessage(ErrorTypeEnum pErrorCode )
        {
            return Errors.ResourceManager.GetString(
                pErrorCode.ToString() , Thread.CurrentThread.CurrentUICulture
                );
        }
        public static string GetMessage(string pVariable)
        {
            return Errors.ResourceManager.GetString(
                pVariable.ToString(), Thread.CurrentThread.CurrentUICulture
                );
        }

        public static string GetMessage(string pVariable , int pParam)
        {
            var message = Errors.ResourceManager.GetString(
                pVariable.ToString(), Thread.CurrentThread.CurrentUICulture
                );

            return string.Format(message , pParam);
        }
        public static string GetMessage(string pVariable, int pParam1 , int pParam2)
        {
            var message = Errors.ResourceManager.GetString(
                pVariable.ToString(), Thread.CurrentThread.CurrentUICulture
                );

            return string.Format(message, pParam1 , pParam2);
        }
        
    }
}
