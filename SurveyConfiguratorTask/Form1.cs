using SurveyConfiguratorTask.Models;

namespace SurveyConfiguratorTask
{
    public partial class Form1 : Form
    {
        List<Question> list = new List<Question>();

        public Form1()
        {

            InitializeComponent();



            

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var addDialogForm = new AddDialog();
            addDialogForm.ShowDialog();
        }
    }
}
