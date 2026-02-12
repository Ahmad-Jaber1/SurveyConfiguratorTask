using Serilog;
using Services;
using Shared;
using SurveyConfiguratorTask.Models;
using System;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace SurveyConfiguratorTask
{
    public partial class MainForm : Form
    {
        private QuestionService mService = new();
        //private DateTime dateTime = DateTime.Now;
        //private bool isRunning = true;
        //private Thread checkForUpdate;
        public static string Language = "en";
        public const string UI_ERROR_MESSAGE =
            "An unexpected error occurred. Please contact support or the system administrator.";

        public MainForm()
        {
            InitializeComponent();
            InitializeDataGridView();
            mService.CheckUpdateEvent += ReloadMainForm;

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
                MessageBox.Show(UI_ERROR_MESSAGE, "Error",
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
                var tConnResult = mService.CheckConnection();
                if (!tConnResult.Success)
                {
                    addButton.Enabled = false;
                    QuestionGridView.DataSource = null;
                    MessageBox.Show(tConnResult.Message, "Connection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var tResult = mService.QuestionsLoad();
                if (!tResult.Success)
                {
                    addButton.Enabled = false;
                    QuestionGridView.DataSource = null;
                    MessageBox.Show(tResult.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                addButton.Enabled = true;


                //var bindingList = new BindingList<Question>(tResult.Data.ToList());
                //QuestionGridView.DataSource = bindingList;
                var tDataTable = new DataTable();
                tDataTable.Columns.Add("Id", typeof(int));
                tDataTable.Columns.Add("Text", typeof(string));
                tDataTable.Columns.Add("Order", typeof(int));
                tDataTable.Columns.Add("Question Type", typeof(string));

                foreach (var question in tResult.Data)
                {
                    tDataTable.Rows.Add(question.Id, question.Text, question.Order, question.TypeQuestion.ToString());
                }

                QuestionGridView.DataSource = tDataTable;


                QuestionGridView.Columns["Id"].Visible = false;


                foreach (DataGridViewColumn column in QuestionGridView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(UI_ERROR_MESSAGE, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private Question GetSelectedQuestion()
        {
            if (QuestionGridView.SelectedRows.Count == 0)
                return null;

            var tRow = QuestionGridView.SelectedRows[0];
            var tResult = mService.GetQuestion((int)tRow.Cells["Id"].Value);
            if (!tResult.Success)
            {
                MessageBox.Show(tResult.Message, "Error",
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
            return tResult.Data;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                var tQuestion = GetSelectedQuestion();
                if (tQuestion == null) return;

                var tConfirm = MessageBox.Show(
                    "Are you sure you want to delete the selected question?",
                    "Confirm Delete",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (tConfirm != DialogResult.OK) return;

                var tResultDeleted = mService.DeleteQuestion(tQuestion.Id);

                if (!tResultDeleted.Success)
                {
                    MessageBox.Show(tResultDeleted.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ReloadMainForm();
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(UI_ERROR_MESSAGE, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                var tAddDialog = new AddDialog(mService);
                if (tAddDialog.ShowDialog() == DialogResult.OK)
                {
                    ReloadMainForm();
                }
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(UI_ERROR_MESSAGE, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                var tQuestion = GetSelectedQuestion();
                if (tQuestion == null) return;

                var tEditDialog = new EditDialog(mService, tQuestion);
                if (tEditDialog.ShowDialog() == DialogResult.OK)
                {
                    ReloadMainForm();
                }
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(UI_ERROR_MESSAGE, "Error",
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

                var tQuestion = GetSelectedQuestion();
                if (tQuestion == null) return;

                questionTextValue.Text = tQuestion.Text;
                questionOrderValue.Text = tQuestion.Order.ToString();

                var tResult = mService.GetQuestion(tQuestion.Id);
                if (!tResult.Success)
                {
                    MessageBox.Show(tResult.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                switch (tQuestion.TypeQuestion)
                {
                    case TypeQuestionEnum.SliderQuestion:
                        var tSlider = (SliderQuestion)tResult.Data;
                        startValueValue.Text = tSlider.StartValue.ToString();
                        endValueValue.Text = tSlider.EndValue.ToString();
                        startCaptionValue.Text = tSlider.StartCaption;
                        endCaptionValue.Text = tSlider.EndCaption;
                        questionTypeValue.Text = "Slider Question";
                        generalPanel.Visible = true;
                        sliderPanel.Visible = true;
                        break;

                    case TypeQuestionEnum.SmileyFacesQuestion:
                        var tSmiley = (SmileyFacesQuestion)tResult.Data;
                        smileyCountValue.Text = tSmiley.SmileyCount.ToString();
                        questionTypeValue.Text = "Smiley Faces Question";
                        generalPanel.Visible = true;
                        smileyPanel.Visible = true;
                        break;

                    case TypeQuestionEnum.StarsQuestion:
                        var tStars = (StarsQuestion)tResult.Data;
                        starsCountValue.Text = tStars.StarsCount.ToString();
                        questionTypeValue.Text = "Stars Question";
                        generalPanel.Visible = true;
                        starsPanel.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(UI_ERROR_MESSAGE, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                mService.FormClosing();

            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(UI_ERROR_MESSAGE, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void databaseConToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var tChangeConnectionForm = new setConnectionString(mService);
                if (tChangeConnectionForm.ShowDialog() == DialogResult.OK)
                {
                    ReloadMainForm();
                }
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(UI_ERROR_MESSAGE, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            Language = "en";
            this.Controls.Clear();
            RightToLeftLayout = false;

            InitializeComponent();
            RightToLeft = RightToLeft.No;
            QuestionGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            InitializeDataGridView();
            ReloadMainForm();


        }

        private void arabicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ar");
            Language = "ar";

            this.Controls.Clear();
            InitializeComponent();
            QuestionGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            InitializeDataGridView();

            ReloadMainForm();
        }

        
    }
}
