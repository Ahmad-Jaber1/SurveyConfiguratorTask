using Microsoft.Extensions.Logging;
using Models;
using Repository;
using Serilog;
using Services;
using SurveyConfiguratorTask.Models;
using SurveyConfiguratorTask.Repo;
using System.Configuration;
using System.Configuration;


namespace SurveyConfiguratorTask
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.File("logs\\app_log.txt"
                , outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} " +
                "| {Level} | {SourceContext}{NewLine}" +
                "Message    : {Message:lj}{NewLine}" +
                "Exception  :{NewLine}" +
                "{Exception}{NewLine}" +
                "============================================================{NewLine}")
                .CreateLogger();

            

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());

        }
    }
    
}