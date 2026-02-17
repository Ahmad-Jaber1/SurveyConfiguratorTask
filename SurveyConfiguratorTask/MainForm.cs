using Serilog;
using Services;
using Shared;
using SurveyConfiguratorTask.Models;
using SurveyConfiguratorTask.Properties;
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
        #region Constant Variables

        // Language Constants
        public const string LANGUAGE_ENGLISH = "en";
        public const string LANGUAGE_ARABIC = "ar";

        // UI Messages
        public const string UI_ERROR_MESSAGE =
            "An unexpected error occurred. Please contact support or the system administrator.";
        public const string ERROR = "Error";
        public const string CONFIRM_DELETE_MESSAGE = "Are you sure you want to delete the selected question?";
        public const string CONFIRM_DELETE_TITLE = "Confirm Delete";

        // Column Names
        private const string COLUMN_ID = "Id";
        private const string COLUMN_TEXT = "Text";
        private const string COLUMN_ORDER = "Order";
        private const string COLUMN_QUESTION_TYPE = "Question Type";

        // Question Type Display Names
        private const string QUESTION_TYPE_SLIDER = "Slider Question";
        private const string QUESTION_TYPE_SMILEY = "Smiley Faces Question";
        private const string QUESTION_TYPE_STARS = "Stars Question";

        #endregion

        private QuestionService mService = new();
        
        public static string Language = LANGUAGE_ENGLISH;

        public MainForm()
        {
            try
            {
                InitializeComponent();
                InitializeDataGridView();
                mService.CheckUpdateEvent += ReloadMainForm;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unexpected error occurred while create MainForm object.");
                MessageBox.Show(ErrorLocalizer.GetMessage(UI_ERROR_MESSAGE), ERROR,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                
            }

        }



        private void InitializeDataGridView()
        {

            try
            {
                QuestionGridView.Columns.Clear();
                QuestionGridView.AutoGenerateColumns = true;
                QuestionGridView.RowHeadersVisible = false;
                QuestionGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                QuestionGridView.MultiSelect = false;
                QuestionGridView.AllowUserToAddRows = false;
                QuestionGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                englishToolStripMenuItem.Checked = true;



                QuestionGridView.SelectionChanged += QuestionGridView_SelectionChanged;
            }
            catch (Exception ex)
            {

                Log.Error(null, ex);
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ReloadMainForm()
        {
            
            try
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => ReloadMainForm()));
                    return;
                }
                var tConnResult = mService.CheckConnection();
                if (!tConnResult.Success)
                {
                    addButton.Enabled = false;
                    editButton.Enabled = false;
                    deleteButton.Enabled = false;
                    QuestionGridView.DataSource = null;
                    MessageBox.Show(ErrorLocalizer.GetMessage(tConnResult.Error.ToString()), ERROR,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var tResult = mService.QuestionsLoad();
                if (!tResult.Success)
                {
                    addButton.Enabled = false;
                    editButton.Enabled = false;
                    deleteButton.Enabled = false;
                    QuestionGridView.DataSource = null;
                    MessageBox.Show(ErrorLocalizer.GetMessage(tResult.Error.ToString()), ERROR,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                addButton.Enabled = true;
                editButton.Enabled = true;
                deleteButton.Enabled = true;
                var tDataTable = new DataTable();
                tDataTable.Columns.Add(COLUMN_ID, typeof(int));
                tDataTable.Columns.Add(ErrorLocalizer.GetMessage(nameof(COLUMN_TEXT)), typeof(string));
                tDataTable.Columns.Add(ErrorLocalizer.GetMessage(nameof(COLUMN_ORDER)), typeof(int));
                tDataTable.Columns.Add(ErrorLocalizer.GetMessage(nameof(COLUMN_QUESTION_TYPE)), typeof(string));

                foreach (var tQuestion in tResult.Data)
                {
                    switch (tQuestion.TypeQuestion)
                    {
                        case TypeQuestionEnum.SliderQuestion:
                            tDataTable.Rows.Add(tQuestion.Id, tQuestion.Text, tQuestion.Order,
                                ErrorLocalizer.GetMessage(nameof(QUESTION_TYPE_SLIDER)));

                            break;
                        case TypeQuestionEnum.SmileyFacesQuestion:
                            tDataTable.Rows.Add(tQuestion.Id, tQuestion.Text, tQuestion.Order,
                               ErrorLocalizer.GetMessage(nameof(QUESTION_TYPE_SMILEY)));

                            break;
                        case TypeQuestionEnum.StarsQuestion:
                            tDataTable.Rows.Add(tQuestion.Id, tQuestion.Text, tQuestion.Order,
                               ErrorLocalizer.GetMessage(nameof(QUESTION_TYPE_STARS)));
                            break;
                    }
                }

                QuestionGridView.DataSource = tDataTable;


                QuestionGridView.Columns[COLUMN_ID].Visible = false;


                foreach (DataGridViewColumn column in QuestionGridView.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }

                if(tDataTable.Rows.Count == 0)
                {
                    editButton.Enabled = false;
                    deleteButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private Question GetSelectedQuestion()
        {
            try
            {
                if (QuestionGridView.SelectedRows.Count == 0)
                    return null;

                var tRow = QuestionGridView.SelectedRows[0];
                var tResult = mService.GetQuestion((int)tRow.Cells[COLUMN_ID].Value);
                if (!tResult.Success)
                {
                    MessageBox.Show(ErrorLocalizer.GetMessage(tResult.Error.ToString()), ERROR,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                
                return tResult.Data;
            }
            catch (Exception ex)
            {

                Log.Error(null, ex);
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                var tQuestion = GetSelectedQuestion();
                if (tQuestion == null) return;

                var tConfirm = MessageBox.Show(
                    ErrorLocalizer.GetMessage(nameof(CONFIRM_DELETE_MESSAGE)),
                    ErrorLocalizer.GetMessage(nameof(CONFIRM_DELETE_TITLE)),
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (tConfirm != DialogResult.OK) return;

                var tResultDeleted = mService.DeleteQuestion(tQuestion.Id);

                if (!tResultDeleted.Success)
                {
                    MessageBox.Show(ErrorLocalizer.GetMessage(tResultDeleted.Error.ToString()), ERROR,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ReloadMainForm();
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
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
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
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
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
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
                    MessageBox.Show(ErrorLocalizer.GetMessage(tResult.Error.ToString()), ERROR,
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
                        questionTypeValue.Text = ErrorLocalizer.GetMessage(nameof(QUESTION_TYPE_SLIDER));
                        generalPanel.Visible = true;
                        sliderPanel.Visible = true;
                        break;

                    case TypeQuestionEnum.SmileyFacesQuestion:
                        var tSmiley = (SmileyFacesQuestion)tResult.Data;
                        smileyCountValue.Text = tSmiley.SmileyCount.ToString();
                        questionTypeValue.Text = ErrorLocalizer.GetMessage(nameof(QUESTION_TYPE_SMILEY));
                        generalPanel.Visible = true;
                        smileyPanel.Visible = true;
                        break;

                    case TypeQuestionEnum.StarsQuestion:
                        var tStars = (StarsQuestion)tResult.Data;
                        starsCountValue.Text = tStars.StarsCount.ToString();
                        questionTypeValue.Text = ErrorLocalizer.GetMessage(nameof(QUESTION_TYPE_STARS));
                        generalPanel.Visible = true;
                        starsPanel.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
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
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
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
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LANGUAGE_ENGLISH);
                Language = LANGUAGE_ENGLISH;
                this.Controls.Clear();
                RightToLeftLayout = false;

                InitializeComponent();
                RightToLeft = RightToLeft.No;
                QuestionGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                InitializeDataGridView();
                englishToolStripMenuItem.Checked = true;
                arabicToolStripMenuItem.Checked = false;
                ReloadMainForm();
            }
            catch (Exception ex)
            {

                Log.Error(null, ex);
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void arabicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LANGUAGE_ARABIC);
                Language = LANGUAGE_ARABIC;

                this.Controls.Clear();
                InitializeComponent();
                QuestionGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                InitializeDataGridView();
                englishToolStripMenuItem.Checked = false;
                arabicToolStripMenuItem.Checked = true;

                ReloadMainForm();
            }
            catch (Exception ex)
            {

                Log.Error(null, ex);
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}