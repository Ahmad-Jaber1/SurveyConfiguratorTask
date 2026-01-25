using SurveyConfiguratorTask.Models;
using SurveyConfiguratorTask.Repo;


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
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());

            var questionRepo = new QuestionRepo();
            var list = questionRepo.QuestionsLoad();

            foreach (var item in list) {
                Console.WriteLine(item.Text + " " + item.Order + " " + item.TypeQuestion);
                }

            //var question = new StarsQuestion("forteen", 14, 3);
            //questionRepo.AddQuestion(question);
            questionRepo.DeleteQuestion(new("A898DE72-34DB-4AF5-A1C1-1073B269D549"));
            Console.WriteLine("********************* \n ********************************");
            list = questionRepo.QuestionsLoad();
            foreach (var item in list)
            {
                Console.WriteLine(item.Text + " " + item.Order + " " + item.TypeQuestion);
            }
            


        }
    }
}