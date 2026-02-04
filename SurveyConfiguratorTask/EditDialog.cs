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
    public partial class EditDialog : Form
    {
        QuestionService service;
        Question question;
        public EditDialog(QuestionService service, Question question)
        {
            this.question = question;
            this.service = service;
            InitializeComponent();
        }

        private void EditDialog_Load(object sender, EventArgs e)
        {
            typeQuestionGroup.Enabled = false;
            orderUpDown.Maximum = int.MaxValue;
            switch (question.TypeQuestion)
            {
                case TypeQuestionEnum.SliderQuestion:
                    SliderQuestion sliderQuestion = (SliderQuestion)question;

                    sliderQuestionRadioButton.Checked = true;
                    sliderPanel.Enabled = true;
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
                    smileyPanel.Enabled = true;
                    textQuestionTextBox.Text = question.Text;
                    orderUpDown.Value = question.Order;
                    smileyFacesUpDown.Value = smileyQuestion.SmileyCount;

                    break;

                case TypeQuestionEnum.StarsQuestion:
                    StarsQuestion starsQuestion = (StarsQuestion)question;

                    starsQuestionRadioButton.Checked = true;
                    starsPanel.Enabled = true;
                    textQuestionTextBox.Text = question.Text;
                    orderUpDown.Value = question.Order;
                    starsUpDown.Value = starsQuestion.StarsCount;

                    break;
            }
            orderUpDown.Maximum = int.MaxValue;

        }

        private void okAddButton_Click(object sender, EventArgs e)
        {
            EditContext edit = new();
            TypeQuestionEnum type = question.TypeQuestion;
            switch (type){
                case TypeQuestionEnum.SliderQuestion:
                    edit.Text = textQuestionTextBox.Text;
                    edit.Order = (int)orderUpDown.Value ;
                    edit.StartValue = (int) startValueUpDown.Value;
                    edit.EndValue =(int) endValueUpDown.Value ;
                    edit.StartCaption = startCaptionTextBox.Text ;
                    edit.EndCaption = endCaptionTextBox.Text ;
                    break;
                case TypeQuestionEnum.SmileyFacesQuestion:
                    edit.Text = textQuestionTextBox.Text;
                    edit.Order = (int)orderUpDown.Value;
                    edit.SmileyCount = (int)smileyFacesUpDown.Value ;
                    break;
                case TypeQuestionEnum.StarsQuestion:
                    edit.Text = textQuestionTextBox.Text;
                    edit.Order = (int)orderUpDown.Value;
                    edit.StarsCount = (int)starsUpDown.Value;
                    break ;
                

            }

            
            //    if (edit.Order > service.GetCountService())
            //{
            //    MessageBox.Show(
            //    "Order value is invalid.",
            //    "Validation Error",
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Error
            //    );
            //        return; 
                
            //}

            

                var result = service.EditQuestionService(question.Id, edit);
            if (!result.Success)
            {
                MessageBox.Show(result.Message, nameof(result.Erorr), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                DialogResult = DialogResult.OK;


            
            //catch (ArgumentNullException ex)
            //{
            //    MessageBox.Show(
            //    ex.Message,
            //    "Error",
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Error
            //    );
               


            //}

            //catch (ArgumentOutOfRangeException ex)
            //{
            //    MessageBox.Show(
            //    ex.Message,
            //    "Error",
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Error
            //    );
                

            //}

            //catch (ArgumentException ex)
            //{
            //    MessageBox.Show(
            //    ex.Message,
            //    "Error",
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Error
            //    );
                

            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(
            //    "An unexpected error occurred. Please try again.",
            //    "Error",
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Error
            //    );
            //}

            
        }

        private void CancelAddButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
