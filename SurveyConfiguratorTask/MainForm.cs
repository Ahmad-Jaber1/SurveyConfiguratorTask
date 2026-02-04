using Services;
using Shared;
using SurveyConfiguratorTask.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SurveyConfiguratorTask
{
    public partial class MainForm : Form
    {
        QuestionService service = new();
        DateTime dateTime = DateTime.Now;
        bool isRunning = true;
        Thread checkForUpdate;

        public MainForm()
        {

            InitializeComponent();

        }
        private void CreateCheckThread()
        {
            checkForUpdate = new Thread(CheckForUpdates);
            checkForUpdate.IsBackground = true;
            checkForUpdate.Start();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (checkForUpdate == null)
            {
                CreateCheckThread();
            }
            ReloadMainForm();

        }
        private void ReloadMainForm()
        {

            var list = service.GetQuestionsList();
            QuestionList.DataSource = null;
            QuestionList.DataSource = list;
            QuestionList.DisplayMember = "Text";
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (QuestionList.SelectedItem != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete the selected question?"
                    , "Confirm Delete",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);

                if (DialogResult.OK == result)
                {
                    Question question = (Question)QuestionList.SelectedItem;
                    
                     var resultDeleted = service.DeleteQuestionService(question.Id);
                    if (!resultDeleted.Success)
                    {
                        MessageBox.Show(resultDeleted.Message, nameof(resultDeleted.Erorr), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    //Force UI rebinding so the latest question data is displayed
                    ReloadMainForm();
                }
            }


        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddDialog addDialog = new AddDialog(service);

            if (DialogResult.OK == addDialog.ShowDialog())
            {
                //Force UI rebinding so the latest question data is displayed

                ReloadMainForm();

            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {

            Question question = (Question)QuestionList.SelectedItem;
            if (question is not null)
            {
                EditDialog editDialog = new EditDialog(service, question);
                if (DialogResult.OK == editDialog.ShowDialog())
                {
                    //Force UI rebinding so the latest question data is displayed
                    ReloadMainForm();

                }
            }
        }

        private void QuestionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            starsPanel.Visible = false;
            sliderPanel.Visible = false;
            smileyPanel.Visible = false;
            generalPanel.Visible = false;



            
                Question question = (Question)QuestionList.SelectedItem;
                if (question is null) return;
                TypeQuestionEnum type = question.TypeQuestion;
                questionTextValue.Text = question.Text;
                questionOrderValue.Text = question.Order.ToString();
                var result = service.GetQuestionService(question.Id);
            if (!result.Success)
            {
                MessageBox.Show(result.Message,nameof(result.Erorr),MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
                switch (type)
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
                        smileyPanel.Visible = true;
                        generalPanel.Visible = true;





                        break;
                    case TypeQuestionEnum.StarsQuestion:
                        var stars = (StarsQuestion)result.Data;
                        starsCountValue.Text = stars.StarsCount.ToString();
                        questionTypeValue.Text = "Stars Question";
                        starsPanel.Visible = true;
                        generalPanel.Visible = true;



                        break;
                }
            
            


        }

        private void CheckForUpdates()
        {
            DateTime lastModifyOnDatabase;
            var result = service.GetLastModifiedService();
            if(!result.Success)
            {
                MessageBox.Show(result.Message, nameof(result.Erorr), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            while (isRunning)
            {
                lastModifyOnDatabase = result.Data;
                if (lastModifyOnDatabase != dateTime)
                {
                    dateTime = lastModifyOnDatabase;

                    service.QuestionsLoadService();

                    Invoke(() =>
                    {
                        ReloadMainForm();
                    });
                }
                Thread.Sleep(3000);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRunning = false;
        }

        private void databaseConToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var changeConnectionForm = new setConnectionString(service);
            if (DialogResult.OK == changeConnectionForm.ShowDialog())
            {
                //Force UI rebinding so the latest question data is displayed
                ReloadMainForm();

            }

        }
    }
}
