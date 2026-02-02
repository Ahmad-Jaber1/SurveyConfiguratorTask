using Models;
using Serilog;
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
    public partial class AddDialog : Form
    {
        QuestionService service ;

        public AddDialog(QuestionService service)
        {
            this.service = service;
            //Add Try here 
            InitializeComponent();
            orderUpDown.Value = service.GetCountService() + 1;

        }



        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            sliderPanel.Enabled = sliderQuestionRadioButton.Checked;
            smileyPanel.Enabled = smileyFacesQuestionRadioButton.Checked;
            starsPanel.Enabled = starsQuestionRadioButton.Checked;

        }

        private void okAddButton_Click(object sender, EventArgs e)
        {
            var addedQuestion = new AddQuestionDto();
            addedQuestion.Text = textQuestionTextBox.Text;
            addedQuestion.Order = (int)orderUpDown.Value;
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

            try
            {
                if (addedQuestion.Order > service.GetCountService() + 1 || addedQuestion.Order <= 0)
                {
                    MessageBox.Show(
                    "Order value is invalid.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                    return;

                }
                service.AddQuestionService(type, addedQuestion);
                DialogResult = DialogResult.OK;
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(
                            ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                                );
                
            }

            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(
                            ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                
            }

            catch (ArgumentException ex)
            {
                MessageBox.Show(
                            ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                            "An unexpected error occurred. Please try again.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
            }
            

            

            
            

        }

        private void CancelAddButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
