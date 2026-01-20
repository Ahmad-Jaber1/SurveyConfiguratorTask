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
        public AddDialog()
        {
            InitializeComponent();

        }

        private void sliderQuestionOption_CheckedChanged(object sender, EventArgs e)
        {

            UpdateGroupBoxes();



        }

        private void smileyFacesQuestionOption_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGroupBoxes();



        }

        private void starsQuestionOption_CheckedChanged(object sender, EventArgs e)
        {
            UpdateGroupBoxes();


        }

        private void UpdateGroupBoxes()
        {
            sliderGroupBox.Enabled = sliderQuestionOption.Checked;
            smileyFacesGroupBox.Enabled = smileyFacesQuestionOption.Checked;
            starsGroupBox.Enabled = starsQuestionOption.Checked;
        }

        
    }
}
