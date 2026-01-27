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

        public MainForm()
        {

            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e)
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
                    service.DeleteQuestionService(question.Id);

                    MainForm_Load(sender, e);
                }
            }


        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddDialog addDialog = new AddDialog(service);

            if (DialogResult.OK == addDialog.ShowDialog())
            {
                MainForm_Load(sender, e);
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
                    MainForm_Load(sender, e);
                }
            }
        }

        private void QuestionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            starsPanel.Visible = false;
            sliderPanel.Visible = false;
            smileyPanel.Visible = false;
            generalPanel.Visible = true;


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
                    sliderPanel.Visible = true;


                    break;
                case TypeQuestionEnum.SmileyFacesQuestion:
                    var smiley = (SmileyFacesQuestion)service.GetQuestionService(question.Id);
                    smileyCountValue.Text = smiley.SmileyCount.ToString();
                    questionTypeValue.Text = "Smiley Faces Question";
                    smileyPanel.Visible = true;




                    break;
                case TypeQuestionEnum.StarsQuestion:
                    var stars = (StarsQuestion)service.GetQuestionService(question.Id);
                    starsCountValue.Text = stars.StarsCount.ToString();
                    questionTypeValue.Text = "Stars Question";
                    starsPanel.Visible = true;


                    break;
            }

        }

        
    }
}
