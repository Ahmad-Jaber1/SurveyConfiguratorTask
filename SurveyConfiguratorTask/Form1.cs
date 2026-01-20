using SurveyConfiguratorTask.Models;

namespace SurveyConfiguratorTask
{
    public partial class Form1 : Form
    {
        List<Question> list = new List<Question>();

        public Form1()
        {

            InitializeComponent();



            var q1 = new SliderQuestion("first slider", 20, 85, "start", "end");
            var q2 = new SmileyFacesQuestion("first smiley", 3);
            var q3 = new StarsQuestion("first stars", 7);

            var q4 = new SliderQuestion("second slider", 30, 75, "start2", "end2");
            var q5 = new SmileyFacesQuestion("second smiley", 4);
            var q6 = new StarsQuestion("second stars", 5);

            list.Add(q1);
            list.Add(q2);
            list.Add(q3);
            list.Add(q4);
            list.Add(q5);
            list.Add(q6);

            foreach (var item in list)
                QuestionListBox.Items.Add(item.Text);

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var addDialogForm = new AddDialog();
            addDialogForm.ShowDialog();
        }
    }
}
