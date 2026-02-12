using Models;
using Serilog;
using Services;
using SurveyConfiguratorTask.Models;
using System;
using System.Windows.Forms;

namespace SurveyConfiguratorTask
{
    public partial class AddDialog : Form
    {
        QuestionService mService;

        private const string UI_ERROR_MESSAGE =
            "An unexpected error occurred. Please contact support or the system administrator.";

        public AddDialog(QuestionService service)
        {
            try
            {
                this.mService = service;

                InitializeComponent();
                detailsGroupBox.Visible = true;
                sliderQuestionRadioButton.Checked = true;


                var result = service.GetCount();
                if (!result.Success)
                {
                    MessageBox.Show(
                        result.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                orderUpDown.Value = result.Data + 1;
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

        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                sliderPanel.Visible = false;
                smileyPanel.Visible = false;
                starsPanel.Visible = false;
                if (sliderQuestionRadioButton.Checked)
                {
                    sliderPanel.BringToFront();
                    sliderPanel.Visible = true;

                }
                if (smileyFacesQuestionRadioButton.Checked)
                {
                    smileyPanel.BringToFront();

                    smileyPanel.Visible = true;

                }
                if (starsQuestionRadioButton.Checked)
                {
                    starsPanel.BringToFront();

                    starsPanel.Visible = true;
                }
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
                var addedQuestion = new AddQuestionDto
                {
                    Text = textQuestionTextBox.Text,
                    Order = (int)orderUpDown.Value
                };

                TypeQuestionEnum type;

                if (sliderQuestionRadioButton.Checked)
                {
                    addedQuestion.StartValue = (int)startValueUpDown.Value;
                    addedQuestion.EndValue = (int)endValueUpDown.Value;
                    addedQuestion.StartCaption = startCaptionTextBox.Text;
                    addedQuestion.EndCaption = endCaptionTextBox.Text;
                    type = TypeQuestionEnum.SliderQuestion;
                }
                else if (smileyFacesQuestionRadioButton.Checked)
                {
                    addedQuestion.SmileyCount = (int)smileyFacesUpDown.Value;
                    type = TypeQuestionEnum.SmileyFacesQuestion;
                }
                else
                {
                    addedQuestion.StarsCount = (int)starsUpDown.Value;
                    type = TypeQuestionEnum.StarsQuestion;
                }

                var result = mService.AddQuestion(type, addedQuestion);
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
