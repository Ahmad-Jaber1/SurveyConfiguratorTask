using Models;
using Serilog;
using Services;
using Shared;
using SurveyConfiguratorTask.Models;
using System;
using System.Windows.Forms;

namespace SurveyConfiguratorTask
{
    public partial class AddDialog : Form
    {
        QuestionService mService;
        private const string ERROR_QUESTION_TEXT_EMPTY = "Please enter a valid question. The question text cannot be empty or longer than 60 characters.";

        private const string UI_ERROR_MESSAGE =
            "An unexpected error occurred. Please contact support or the system administrator.";
        private const string ERROR = "Error";
        private const string ERROR_ORDER_VALUE_OUT_OF_RANGE = "Please enter a valid order value. The value must be between 1 and {MaxValue}.";
        private const string ERROR_STARS_COUNT_INVALID = "Please enter a valid stars count. The value must be between 1 and 10.";
        private const string ERROR_SMILEY_COUNT_INVALID = "Please enter a valid smiley count. The value must be between 2 and 5.";
        private const string ERROR_START_VALUE_OUT_OF_RANGE = "Please enter a valid start value. It must be between 0 and {EndValue} ";
        private const string ERROR_END_VALUE_OUT_OF_RANGE = "Please enter a valid end value. It must be between {StartValue} and {Param2} ";
        private const string ERROR_CAPTION_TEXT_EMPTY = "Please enter a valid caption. The caption text cannot be empty or longer than 30 characters .";
        private const string MAX_END_VALUE = "100";
        //private const string ERROR_Question_TEXT_EMPTY = "Please enter a valid caption. The caption text cannot be empty.";

        public AddDialog(QuestionService service)
        {
            try
            {
                this.mService = service;

                InitializeComponent();
                detailsGroupBox.Visible = true;
                sliderQuestionRadioButton.Checked = true;


                var tResult = service.GetCount();
                if (!tResult.Success)
                {
                    MessageBox.Show(
                         ErrorLocalizer.GetMessage(tResult.Error.ToString()),
                        ERROR,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                orderUpDown.Value = tResult.Data + 1;
            }
            catch (Exception ex)
            {
                Log.Error(ex , "Unexpected error occurred while create AddDialog object.");
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void okAddButton_Click(object sender, EventArgs e)
        {
            try
            {
                //validate text
                if (string.IsNullOrEmpty(textQuestionTextBox.Text) || textQuestionTextBox.Text.Length > 60)
                {
                    MessageBox.Show(
                        ErrorLocalizer.GetMessage(nameof(ERROR_QUESTION_TEXT_EMPTY)),
                        ERROR,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                var tQuestionsCount = mService.GetCount();
                if (!tQuestionsCount.Success)
                {
                    MessageBox.Show(
                        ErrorLocalizer.GetMessage(tQuestionsCount.Error.ToString()),
                        ERROR,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                //validate order
                if ((int)orderUpDown.Value < 1)
                {

                    MessageBox.Show(
                        ErrorLocalizer.GetMessage(nameof(ERROR_ORDER_VALUE_OUT_OF_RANGE), (tQuestionsCount.Data + 1).ToString()),
                        ERROR,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                //if ((int)orderUpDown.Value > tQuestionsCount.Data + 1 || (int)orderUpDown.Value < 1)
                //{

                //    MessageBox.Show(
                //        ErrorLocalizer.GetMessage(nameof(ERROR_ORDER_VALUE_OUT_OF_RANGE), (tQuestionsCount.Data + 1).ToString()),
                //        ERROR,
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Error);
                //    return;
                //}
                var tAddedQuestion = new AddQuestionDto
                {
                    Text = textQuestionTextBox.Text,
                    Order = (int)orderUpDown.Value
                };

                TypeQuestionEnum type;

                if (sliderQuestionRadioButton.Checked)
                {

                    if ((int)startValueUpDown.Value < 0 ||
                        (int)startValueUpDown.Value >= (int)endValueUpDown.Value)
                    {
                        MessageBox.Show(
                         ErrorLocalizer.GetMessage(nameof(ERROR_START_VALUE_OUT_OF_RANGE), ((int)endValueUpDown.Value - 1).ToString()),
                        ERROR,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return;
                    }
                    if ((int)endValueUpDown.Value > 100 ||
                        (int)endValueUpDown.Value <= (int)startValueUpDown.Value)
                    {
                        MessageBox.Show(
                         ErrorLocalizer.GetMessage(nameof(ERROR_END_VALUE_OUT_OF_RANGE), ((int)startValueUpDown.Value + 1).ToString(), MAX_END_VALUE),
                        ERROR,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return;
                    }
                    if (string.IsNullOrEmpty(startCaptionTextBox.Text) ||
                                string.IsNullOrEmpty(endCaptionTextBox.Text) ||
                                startCaptionTextBox.Text.Length > 30 ||
                                endCaptionTextBox.Text.Length > 30)
                    {
                        MessageBox.Show(
                         ErrorLocalizer.GetMessage(nameof(ERROR_CAPTION_TEXT_EMPTY)),
                        ERROR,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return;
                    }





                    tAddedQuestion.StartValue = (int)startValueUpDown.Value;
                    tAddedQuestion.EndValue = (int)endValueUpDown.Value;
                    tAddedQuestion.StartCaption = startCaptionTextBox.Text;
                    tAddedQuestion.EndCaption = endCaptionTextBox.Text;
                    type = TypeQuestionEnum.SliderQuestion;
                }
                else if (smileyFacesQuestionRadioButton.Checked)
                {
                    //validate smiley count 
                    if ((int)smileyFacesUpDown.Value < 2 || (int)smileyFacesUpDown.Value > 5)
                    {
                        MessageBox.Show(
                        ErrorLocalizer.GetMessage(nameof(ERROR_SMILEY_COUNT_INVALID)),
                        ERROR,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return;
                    }
                    tAddedQuestion.SmileyCount = (int)smileyFacesUpDown.Value;
                    type = TypeQuestionEnum.SmileyFacesQuestion;
                }
                else
                {
                    //validate stars count 

                    if ((int)starsUpDown.Value < 1 || (int)starsUpDown.Value > 10)
                    {
                        MessageBox.Show(
                        ErrorLocalizer.GetMessage(nameof(ERROR_STARS_COUNT_INVALID)),
                        ERROR,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return;
                    }
                    tAddedQuestion.StarsCount = (int)starsUpDown.Value;
                    type = TypeQuestionEnum.StarsQuestion;
                }

                var tResult = mService.AddQuestion(type, tAddedQuestion);
                if (!tResult.Success)
                {
                    MessageBox.Show(
                        ErrorLocalizer.GetMessage(tResult.Error.ToString()),
                        ERROR,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
