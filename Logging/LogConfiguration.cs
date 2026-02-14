using Serilog;
using System;
using System.Collections.Generic;
using System.Text;


namespace Shared
{
    public  class LogConfiguration
    {
        public static void Configure()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.File(
                    "logs\\app_log.txt",
                    outputTemplate:
                        "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} | {Level} | {SourceContext}{NewLine}" +
                        "Message    : {Message:lj}{NewLine}" +
                        "Exception  :{NewLine}{Exception}{NewLine}" +
                        "============================================================{NewLine}"
                )
                .CreateLogger();
        }
    }
}
