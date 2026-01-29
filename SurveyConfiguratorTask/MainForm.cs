using Services;
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
                    try
                    {
                        service.DeleteQuestionService(question.Id);
                    }
                    catch (KeyNotFoundException ex)
                    {
                        MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                        "An unexpected error occurred. Please try again.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                        );
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



            try
            {
                Question question = (Question)QuestionList.SelectedItem;
                if (question is null) return;
                TypeQuestionEnum type = question.TypeQuestion;
                questionTextValue.Text = question.Text;
                questionOrderValue.Text = question.Order.ToString();
                switch (type)
                {
                    case TypeQuestionEnum.SliderQuestion:
                        var slider = (SliderQuestion)service.GetQuestionService(question.Id);
                        startValueValue.Text = slider.StartValue.ToString();
                        endValueValue.Text = slider.EndValue.ToString();
                        startCaptionValue.Text = slider.StartCaption;
                        endCaptionValue.Text = slider.EndCaption;

                        questionTypeValue.Text = "Slider Question";
                        generalPanel.Visible = true;

                        sliderPanel.Visible = true;


                        break;
                    case TypeQuestionEnum.SmileyFacesQuestion:
                        var smiley = (SmileyFacesQuestion)service.GetQuestionService(question.Id);
                        smileyCountValue.Text = smiley.SmileyCount.ToString();
                        questionTypeValue.Text = "Smiley Faces Question";
                        smileyPanel.Visible = true;
                        generalPanel.Visible = true;





                        break;
                    case TypeQuestionEnum.StarsQuestion:
                        var stars = (StarsQuestion)service.GetQuestionService(question.Id);
                        starsCountValue.Text = stars.StarsCount.ToString();
                        questionTypeValue.Text = "Stars Question";
                        starsPanel.Visible = true;
                        generalPanel.Visible = true;



                        break;
                }
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );

            }

            catch (Exception ex)
            {
                MessageBox.Show(
                "An unexpected error occurred. Please try again.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
            }


        }

        private void CheckForUpdates()
        {
            DateTime lastModifyOnDatabase;

            while (isRunning)
            {
                lastModifyOnDatabase = service.GetLastModifiedService();
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

        
    }
}
