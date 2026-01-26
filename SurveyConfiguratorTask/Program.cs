using Models;
using Services;
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

            //var repo = new QuestionRepo();
            //var list = repo.QuestionsLoad();
            //foreach (var item in list)
            //{
            //    item.Show(item);
            //}
            //Console.WriteLine("-*-*-*-*-*-*-*-*-*-*--*-*--*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            //var ids = new List<Guid>();
            //var orders = new List<int>{10,20,30};
            //for (int i = 0; i < list.Count; i++)
            //    ids.Add(list[i].Id);
            //repo.EditOrder(ids, orders);
            //list = repo.QuestionsLoad();
            //foreach (var item in list)
            //{
            //    item.Show(item);
            //}
            //Console.WriteLine(repo.GetCount());

            //Question question = new StarsQuestion("one", 1, 3);
            //repo.AddQuestion(question);
            //question = new SmileyFacesQuestion("two", 2, 3);
            //repo.AddQuestion(question);
            //question = new SliderQuestion("three", 3, 10, 80, "start -three-", "end -three-");
            //repo.AddQuestion(question);

            //foreach (var item in list)
            //{
            //    item.Show(item);
            //}
            //Console.WriteLine("-*-*-*-*-*-*-*-*-*-*--*-*--*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            //var question = new StarsQuestion(new("2C395F07-EA2C-465A-B40D-13DE6399766D"), "EDIT one", 1, 7);
            //repo.EditQuestion(question);
            // list = repo.QuestionsLoad();
            //foreach (var item in list)
            //{
            //    item.Show(item);
            //}
            //var x = new Guid();
            //x= Guid.NewGuid();
            //Console.WriteLine(x.ToString());
            //var y =new Guid(x.ToString());
            //Console.WriteLine(y);

            QuestionService service = new QuestionService();
            //var temp = new AddQuestionDto { Text ="YES I EDIT IT" , SmileyCount = 3 };
            var temp = new EditContext { Text = "YES I EDIT IT", SmileyCount = 3  , Order = 3};
            //service.AddQuestionService(TypeQuestionEnum.SmileyFacesQuestion,temp);
            //service.DeleteQuestionService(new("DCD02F8C-90B5-48F5-81D4-AE7947AB4220"));
            service.EditQuestionService(new("74EA93DE-377D-4F39-934D-291CBF2641BE"), temp);
            //service.EditOrder();
            foreach (var question in service.GetQuestionsList())
            {
                question.Show(question);
            }

        }
    }
}