using Serilog;
using Services;
using SurveyConfiguratorTask.Models;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace SurveyConfiguratorTask
{
    public partial class EditDialog : Form
    {
        QuestionService service;
        Question question;

        private const string UI_ERROR_MESSAGE =
            "An unexpected error occurred. Please contact support or the system administrator.";

        public EditDialog(QuestionService service, Question question)
        {
            this.question = question;
            this.service = service;
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(MainForm.Language);
            //if(MainForm.Language == "en")
            //{
            //    RightToLeft = RightToLeft.No;
            //    RightToLeftLayout = false;

            //}
            InitializeComponent();
        }

        private void EditDialog_Load(object sender, EventArgs e)
        {
            try
            {
                typeQuestionGroup.Enabled = false;
                orderUpDown.Maximum = int.MaxValue;
                sliderPanel.Visible = false;
                smileyPanel.Visible = false;
                starsPanel.Visible = false;

                switch (question.TypeQuestion)
                {
                    case TypeQuestionEnum.SliderQuestion:
                        SliderQuestion sliderQuestion = (SliderQuestion)question;

                        sliderQuestionRadioButton.Checked = true;
                        sliderPanel.Visible = true;
                        textQuestionTextBox.Text = question.Text;
                        orderUpDown.Value = question.Order;
                        startValueUpDown.Value = sliderQuestion.StartValue;
                        endValueUpDown.Value = sliderQuestion.EndValue;
                        startCaptionTextBox.Text = sliderQuestion.StartCaption;
                        endCaptionTextBox.Text = sliderQuestion.EndCaption;
                        break;

                    case TypeQuestionEnum.SmileyFacesQuestion:
                        SmileyFacesQuestion smileyQuestion = (SmileyFacesQuestion)question;

                        smileyFacesQuestionRadioButton.Checked = true;
                        smileyPanel.Visible = true;
                        textQuestionTextBox.Text = question.Text;
                        orderUpDown.Value = question.Order;
                        smileyFacesUpDown.Value = smileyQuestion.SmileyCount;
                        break;

                    case TypeQuestionEnum.StarsQuestion:
                        StarsQuestion starsQuestion = (StarsQuestion)question;

                        starsQuestionRadioButton.Checked = true;
                        starsPanel.Visible = true;
                        textQuestionTextBox.Text = question.Text;
                        orderUpDown.Value = question.Order;
                        starsUpDown.Value = starsQuestion.StarsCount;
                        break;
                }

                orderUpDown.Maximum = int.MaxValue;
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(
                    UI_ERROR_MESSAGE,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void okAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                EditQuestionDto edit = new();
                TypeQuestionEnum type = question.TypeQuestion;

                switch (type)
                {
                    case TypeQuestionEnum.SliderQuestion:
                        edit.Text = textQuestionTextBox.Text;
                        edit.Order = (int)orderUpDown.Value;
                        edit.StartValue = (int)startValueUpDown.Value;
                        edit.EndValue = (int)endValueUpDown.Value;
                        edit.StartCaption = startCaptionTextBox.Text;
                        edit.EndCaption = endCaptionTextBox.Text;
                        break;

                    case TypeQuestionEnum.SmileyFacesQuestion:
                        edit.Text = textQuestionTextBox.Text;
                        edit.Order = (int)orderUpDown.Value;
                        edit.SmileyCount = (int)smileyFacesUpDown.Value;
                        break;

                    case TypeQuestionEnum.StarsQuestion:
                        edit.Text = textQuestionTextBox.Text;
                        edit.Order = (int)orderUpDown.Value;
                        edit.StarsCount = (int)starsUpDown.Value;
                        break;
                }

                var result = service.EditQuestion(question.Id, edit);
                if (!result.Success)
                {
                    MessageBox.Show(
                        result.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(
                    UI_ERROR_MESSAGE,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CancelAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(
                    UI_ERROR_MESSAGE,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        
    }
}
