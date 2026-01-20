using SurveyConfiguratorTask.Models;

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
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            //var q1 = new SliderQuestion("first slider", 20, 85, "start", "end");
            //var q2 = new SmileyFacesQuestion("first smiley", 3);
            //var q3 = new StarsQuestion("first stars", 7);

            //var q4 = new SliderQuestion("second slider", 30, 75, "start2", "end2");
            //var q5 = new SmileyFacesQuestion("second smiley", 4);
            //var q6 = new StarsQuestion("second stars", 5);

            //List<Question> list = new List<Question>();
            //list.Add(q1);
            //list.Add(q2);
            //list.Add(q3);
            //list.Add(q4);
            //list.Add(q5);
            //list.Add(q6);
            
            //foreach(var item in list)
            //{
            //    item.Show(item);
            //    Console.WriteLine("*******************");
            //}
            //Console.WriteLine("***********************************************");
            //Console.WriteLine("***********************************************");
            //Console.WriteLine("***********************************************");

            ////q1.ChangeQuestionOrder(list, 5);
            ////q3.DeleteQuestion(list);
            //var context = new EditContext();
            //context.StartValue = 50; 
            //context.EndValue = 99;
            //context.StartCaption = "changeStart";
            //context.EndCaption = "changeEnd";
            //context.Order = 3;
            //context.Text = q1.Text;
            //q1.EditQuestion(context,list);
            //foreach (var item in list)
            //{
            //    item.Show(item);
            //    Console.WriteLine("*******************");
            //}


        }
    }
}