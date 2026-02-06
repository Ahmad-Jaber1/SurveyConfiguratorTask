using Serilog;
using Services;
using Shared;
using SurveyConfiguratorTask.Models;
using System;
using System.ComponentModel;
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
            
            
            QuestionGridView.AutoGenerateColumns = false;
            
            

            QuestionGridView.Columns.Clear();

            QuestionGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Text",
                HeaderText = "Question Text",
                DataPropertyName = "Text",
                SortMode = DataGridViewColumnSortMode.Automatic,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            QuestionGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Order",
                HeaderText = "Order",
                DataPropertyName = "Order",
                SortMode = DataGridViewColumnSortMode.Automatic,
                Width = 60
            });

            QuestionGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Type",
                HeaderText = "Type",
                DataPropertyName = "TypeQuestion",
                SortMode = DataGridViewColumnSortMode.Automatic,
                Width = 120
            });

            QuestionGridView.SelectionChanged += QuestionGridView_SelectionChanged;
        }

        

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                //if (checkForUpdate == null)
                //{
                //    CreateCheckThread();
                //}

                ReloadMainForm();
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(UiErrorMessage, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void CreateCheckThread()
        //{
        //    try
        //    {
        //        checkForUpdate = new Thread(CheckForUpdates)
        //        {
        //            IsBackground = true
        //        };
        //        checkForUpdate.Start();
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(null, ex);
        //        MessageBox.Show(UiErrorMessage, "Error",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

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

                var result = service.QuestionsLoadService();
                if (!result.Success)
                {
                    addButton.Enabled = false;
                    QuestionGridView.DataSource = null;
                    MessageBox.Show(result.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                addButton.Enabled = true;

                
                var bindingList = new BindingList<Question>(result.Data.ToList());
                QuestionGridView.DataSource = bindingList;
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(UiErrorMessage, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region CRUD Operations

        private Question GetSelectedQuestion()
        {
            if (QuestionGridView.SelectedRows.Count == 0)
                return null;

            return (Question)QuestionGridView.SelectedRows[0].DataBoundItem;
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

                var resultDeleted = service.DeleteQuestionService(question.Id);

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

        #endregion

        #region Selection Handling

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

                var result = service.GetQuestionService(question.Id);
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

        #endregion

        //private void CheckForUpdates()
        //{
        //    try
        //    {
        //        while (isRunning)
        //        {
        //            var result = service.GetLastModifiedService();
        //            if (result.Success && result.Data != dateTime)
        //            {
        //                dateTime = result.Data;
        //                Invoke(ReloadMainForm);
        //            }

        //            Thread.Sleep(3000);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(null, ex);
        //    }
        //}

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
