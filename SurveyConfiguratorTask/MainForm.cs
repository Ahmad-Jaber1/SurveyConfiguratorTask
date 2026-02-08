using Serilog;
using Services;
using Shared;
using SurveyConfiguratorTask.Models;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SurveyConfiguratorTask
{
    public partial class MainForm : Form
    {
        private QuestionService service = new();
        //private DateTime dateTime = DateTime.Now;
        //private bool isRunning = true;
        //private Thread checkForUpdate;

        private const string UiErrorMessage =
            "An unexpected error occurred. Please contact support or the system administrator.";

        public MainForm()
        {
            InitializeComponent();
            InitializeDataGridView();
            service.CheckUpdateEvent += ReloadMainForm;
        }



        private void InitializeDataGridView()
        {

            QuestionGridView.Columns.Clear();
            QuestionGridView.AutoGenerateColumns = true;
            QuestionGridView.RowHeadersVisible = false;
            QuestionGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            QuestionGridView.MultiSelect = false;
            QuestionGridView.AllowUserToAddRows = false;
            QuestionGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            QuestionGridView.SelectionChanged += QuestionGridView_SelectionChanged;
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                ReloadMainForm();
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(UiErrorMessage, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ReloadMainForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => ReloadMainForm()));
                return;
            }
            try
            {
                var connResult = service.CheckConnection();
                if (!connResult.Success)
                {
                    addButton.Enabled = false;
                    QuestionGridView.DataSource = null;
                    MessageBox.Show(connResult.Message, "Connection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var result = service.QuestionsLoad();
                if (!result.Success)
                {
                    addButton.Enabled = false;
                    QuestionGridView.DataSource = null;
                    MessageBox.Show(result.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                addButton.Enabled = true;


                //var bindingList = new BindingList<Question>(result.Data.ToList());
                //QuestionGridView.DataSource = bindingList;
                var dt = new DataTable();
                dt.Columns.Add("Id", typeof(int)); // keep Id for selection
                dt.Columns.Add("Text", typeof(string));
                dt.Columns.Add("Order", typeof(int));
                dt.Columns.Add("Question Type", typeof(string));

                foreach (var q in result.Data)
                {
                    dt.Rows.Add(q.Id, q.Text, q.Order, q.TypeQuestion.ToString());
                }

                QuestionGridView.DataSource = dt;

                
                QuestionGridView.Columns["Id"].Visible = false;

                
                foreach (DataGridViewColumn col in QuestionGridView.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.Automatic;
                }
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(UiErrorMessage, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private Question GetSelectedQuestion()
        {
            if (QuestionGridView.SelectedRows.Count == 0)
                return null;

            var row = QuestionGridView.SelectedRows[0];
            var result = service.GetQuestion((int)row.Cells["Id"].Value);
            if (!result.Success)
            {
                MessageBox.Show(result.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            //var question =  new Question
            //{
            //    Id = (int)row.Cells["Id"].Value,
            //    Text = row.Cells["Text"].Value.ToString(),
            //    Order = (int)row.Cells["Order"].Value,
            //    TypeQuestion = Enum.Parse<TypeQuestionEnum>(row.Cells["Question Type"].Value.ToString())
            //};
            return result.Data;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                var question = GetSelectedQuestion();
                if (question == null) return;

                var confirm = MessageBox.Show(
                    "Are you sure you want to delete the selected question?",
                    "Confirm Delete",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.OK) return;

                var resultDeleted = service.DeleteQuestion(question.Id);

                if (!resultDeleted.Success)
                {
                    MessageBox.Show(resultDeleted.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ReloadMainForm();
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(UiErrorMessage, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                var addDialog = new AddDialog(service);
                if (addDialog.ShowDialog() == DialogResult.OK)
                {
                    ReloadMainForm();
                }
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(UiErrorMessage, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                var question = GetSelectedQuestion();
                if (question == null) return;

                var editDialog = new EditDialog(service, question);
                if (editDialog.ShowDialog() == DialogResult.OK)
                {
                    ReloadMainForm();
                }
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(UiErrorMessage, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void QuestionGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                starsPanel.Visible = false;
                sliderPanel.Visible = false;
                smileyPanel.Visible = false;
                generalPanel.Visible = false;

                var question = GetSelectedQuestion();
                if (question == null) return;

                questionTextValue.Text = question.Text;
                questionOrderValue.Text = question.Order.ToString();

                var result = service.GetQuestion(question.Id);
                if (!result.Success)
                {
                    MessageBox.Show(result.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                switch (question.TypeQuestion)
                {
                    case TypeQuestionEnum.SliderQuestion:
                        var slider = (SliderQuestion)result.Data;
                        startValueValue.Text = slider.StartValue.ToString();
                        endValueValue.Text = slider.EndValue.ToString();
                        startCaptionValue.Text = slider.StartCaption;
                        endCaptionValue.Text = slider.EndCaption;
                        questionTypeValue.Text = "Slider Question";
                        generalPanel.Visible = true;
                        sliderPanel.Visible = true;
                        break;

                    case TypeQuestionEnum.SmileyFacesQuestion:
                        var smiley = (SmileyFacesQuestion)result.Data;
                        smileyCountValue.Text = smiley.SmileyCount.ToString();
                        questionTypeValue.Text = "Smiley Faces Question";
                        generalPanel.Visible = true;
                        smileyPanel.Visible = true;
                        break;

                    case TypeQuestionEnum.StarsQuestion:
                        var stars = (StarsQuestion)result.Data;
                        starsCountValue.Text = stars.StarsCount.ToString();
                        questionTypeValue.Text = "Stars Question";
                        generalPanel.Visible = true;
                        starsPanel.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(UiErrorMessage, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                service.FormClosing();
                
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(UiErrorMessage, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void databaseConToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var changeConnectionForm = new setConnectionString(service);
                if (changeConnectionForm.ShowDialog() == DialogResult.OK)
                {
                    ReloadMainForm();
                }
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(UiErrorMessage, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
