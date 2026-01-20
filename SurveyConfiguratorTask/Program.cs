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

            var q1 = new StarsQuestion("q1", 5);
            var q2 = new StarsQuestion("q2", 5);
            var q3 = new StarsQuestion("q3", 5);
            var q4 = new SmileyFacesQuestion("q4", 5);
            var q5 = new SmileyFacesQuestion("q5", 5);
            var q6 = new SmileyFacesQuestion("q6", 5);

            var list = new List<Question>();
            list.Add(q1);
            list.Add(q2);
            list.Add(q3);
            list.Add(q4);
            list.Add(q5);
            list.Add(q6);

            foreach(var item in list)
            {
                Console.WriteLine($"{item.Text}-{item.Order}");
            }
            Console.WriteLine("*********************");
            Question.ReorderList(list, q4, 3);

            foreach (var item in list)
            {
                Console.WriteLine($"{item.Text}-{item.Order}");
            }


        }
    }
}