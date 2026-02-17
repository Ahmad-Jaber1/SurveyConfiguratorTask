using Serilog;
using Services;
using Shared;
using SurveyConfiguratorTask.Models;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace SurveyConfiguratorTask
{
    public partial class EditDialog : Form
    {
        QuestionService mService;
        Question mQuestion;

        private const string ERROR_QUESTION_TEXT_EMPTY = "Please enter a valid question. The question text cannot be empty or longer than 60 characters.";

        private const string UI_ERROR_MESSAGE =
            "An unexpected error occurred. Please contact support or the system administrator.";
        public const string ERROR = "Error";
        public const string ERROR_ORDER_VALUE_OUT_OF_RANGE = "Please enter a valid order value. The value must be between 1 and {MaxValue}.";
        public const string ERROR_STARS_COUNT_INVALID = "Please enter a valid stars count. The value must be between 1 and 10.";
        public const string ERROR_SMILEY_COUNT_INVALID = "Please enter a valid smiley count. The value must be between 2 and 5.";
        public const string ERROR_START_VALUE_OUT_OF_RANGE = "Please enter a valid start value. It must be between 0 and {EndValue} ";
        public const string ERROR_END_VALUE_OUT_OF_RANGE = "Please enter a valid end value. It must be between {StartValue} and {Param2} ";
        private const string ERROR_CAPTION_TEXT_EMPTY = "Please enter a valid caption. The caption text cannot be empty or longer than 30 characters .";
        private const string MAX_END_VALUE = "100";

        public EditDialog(QuestionService service, Question question)
        {
            try
            {
                mQuestion = question;
                mService = service;

                InitializeComponent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unexpected error occurred while create EditDialog object.");
                MessageBox.Show(ErrorLocalizer.GetMessage(UI_ERROR_MESSAGE), ERROR,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
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

                switch (mQuestion.TypeQuestion)
                {
                    case TypeQuestionEnum.SliderQuestion:
                        SliderQuestion sliderQuestion = (SliderQuestion)mQuestion;

                        sliderQuestionRadioButton.Checked = true;
                        sliderPanel.Visible = true;
                        textQuestionTextBox.Text = mQuestion.Text;
                        orderUpDown.Value = mQuestion.Order;
                        startValueUpDown.Value = sliderQuestion.StartValue;
                        endValueUpDown.Value = sliderQuestion.EndValue;
                        startCaptionTextBox.Text = sliderQuestion.StartCaption;
                        endCaptionTextBox.Text = sliderQuestion.EndCaption;
                        break;

                    case TypeQuestionEnum.SmileyFacesQuestion:
                        SmileyFacesQuestion smileyQuestion = (SmileyFacesQuestion)mQuestion;

                        smileyFacesQuestionRadioButton.Checked = true;
                        smileyPanel.Visible = true;
                        textQuestionTextBox.Text = mQuestion.Text;
                        orderUpDown.Value = mQuestion.Order;
                        smileyFacesUpDown.Value = smileyQuestion.SmileyCount;
                        break;

                    case TypeQuestionEnum.StarsQuestion:
                        StarsQuestion starsQuestion = (StarsQuestion)mQuestion;

                        starsQuestionRadioButton.Checked = true;
                        starsPanel.Visible = true;
                        textQuestionTextBox.Text = mQuestion.Text;
                        orderUpDown.Value = mQuestion.Order;
                        starsUpDown.Value = starsQuestion.StarsCount;
                        break;
                }

                orderUpDown.Maximum = int.MaxValue;
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
                EditQuestionDto edit = new();
                TypeQuestionEnum type = mQuestion.TypeQuestion;
                //validate text
                if (string.IsNullOrEmpty(textQuestionTextBox.Text)||
                    textQuestionTextBox.Text.Length>60)
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
                if ( (int)orderUpDown.Value < 1)
                {

                    MessageBox.Show(
                        ErrorLocalizer.GetMessage(nameof(ERROR_ORDER_VALUE_OUT_OF_RANGE), tQuestionsCount.Data.ToString() ),
                        ERROR,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                switch (type)
                {
                    case TypeQuestionEnum.SliderQuestion:
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
                             ErrorLocalizer.GetMessage(nameof(ERROR_START_VALUE_OUT_OF_RANGE), ((int)startValueUpDown.Value + 1).ToString(), MAX_END_VALUE),
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
                        edit.Text = textQuestionTextBox.Text;
                        edit.Order = (int)orderUpDown.Value;
                        edit.StartValue = (int)startValueUpDown.Value;
                        edit.EndValue = (int)endValueUpDown.Value;
                        edit.StartCaption = startCaptionTextBox.Text;
                        edit.EndCaption = endCaptionTextBox.Text;
                        break;

                    case TypeQuestionEnum.SmileyFacesQuestion:
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
                        edit.Text = textQuestionTextBox.Text;
                        edit.Order = (int)orderUpDown.Value;
                        edit.SmileyCount = (int)smileyFacesUpDown.Value;
                        break;

                    case TypeQuestionEnum.StarsQuestion:

                        //validate stars count 

                        if ((int)starsUpDown.Value < 1 || (int)starsUpDown.Value > 10)
                        {
                            MessageBox.Show(
                            ErrorLocalizer.GetMessage(nameof(ERROR_SMILEY_COUNT_INVALID)),
                            ERROR,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                            return;
                        }
                        edit.Text = textQuestionTextBox.Text;
                        edit.Order = (int)orderUpDown.Value;
                        edit.StarsCount = (int)starsUpDown.Value;
                        break;
                }

                var tResult = mService.EditQuestion(mQuestion.Id, edit);
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
