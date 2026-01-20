namespace SurveyConfiguratorTask
{
    partial class AddDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            questionTypeGroupBox = new GroupBox();
            starsQuestionOption = new RadioButton();
            smileyFacesQuestionOption = new RadioButton();
            sliderQuestionOption = new RadioButton();
            label1 = new Label();
            starsGroupBox = new GroupBox();
            starsUpDown = new NumericUpDown();
            countStarsLabel = new Label();
            smileyFacesGroupBox = new GroupBox();
            smileyFacesUpDown = new NumericUpDown();
            coumtsmileyFacesLabel = new Label();
            sliderGroupBox = new GroupBox();
            endValueUpDown = new NumericUpDown();
            startValueUpDown = new NumericUpDown();
            endCaptionTextBox = new TextBox();
            startCaptionTextBox = new TextBox();
            endValueLabel = new Label();
            startValueLabel = new Label();
            endCaptionLabel = new Label();
            startCaptionLabel = new Label();
            generalQuestionGroupBox = new GroupBox();
            textQuestionLabel = new Label();
            orderQuestionUpDown = new NumericUpDown();
            textQuestionTextBox = new TextBox();
            orderQuestionLabel = new Label();
            questionTypeGroupBox.SuspendLayout();
            starsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)starsUpDown).BeginInit();
            smileyFacesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smileyFacesUpDown).BeginInit();
            sliderGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)endValueUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)startValueUpDown).BeginInit();
            generalQuestionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orderQuestionUpDown).BeginInit();
            SuspendLayout();
            // 
            // questionTypeGroupBox
            // 
            questionTypeGroupBox.Controls.Add(starsQuestionOption);
            questionTypeGroupBox.Controls.Add(smileyFacesQuestionOption);
            questionTypeGroupBox.Controls.Add(sliderQuestionOption);
            questionTypeGroupBox.Controls.Add(label1);
            questionTypeGroupBox.Location = new Point(53, 39);
            questionTypeGroupBox.Name = "questionTypeGroupBox";
            questionTypeGroupBox.Size = new Size(307, 169);
            questionTypeGroupBox.TabIndex = 70;
            questionTypeGroupBox.TabStop = false;
            questionTypeGroupBox.Text = "Question Type ";
            // 
            // starsQuestionOption
            // 
            starsQuestionOption.AutoSize = true;
            starsQuestionOption.Location = new Point(17, 112);
            starsQuestionOption.Name = "starsQuestionOption";
            starsQuestionOption.Size = new Size(101, 19);
            starsQuestionOption.TabIndex = 68;
            starsQuestionOption.TabStop = true;
            starsQuestionOption.Text = "Stars Question";
            starsQuestionOption.UseVisualStyleBackColor = true;
            starsQuestionOption.CheckedChanged += starsQuestionOption_CheckedChanged;
            // 
            // smileyFacesQuestionOption
            // 
            smileyFacesQuestionOption.AutoSize = true;
            smileyFacesQuestionOption.Location = new Point(17, 87);
            smileyFacesQuestionOption.Name = "smileyFacesQuestionOption";
            smileyFacesQuestionOption.Size = new Size(143, 19);
            smileyFacesQuestionOption.TabIndex = 67;
            smileyFacesQuestionOption.TabStop = true;
            smileyFacesQuestionOption.Text = "Smiley Faces Question";
            smileyFacesQuestionOption.UseVisualStyleBackColor = true;
            smileyFacesQuestionOption.CheckedChanged += smileyFacesQuestionOption_CheckedChanged;
            // 
            // sliderQuestionOption
            // 
            sliderQuestionOption.AutoSize = true;
            sliderQuestionOption.Location = new Point(17, 62);
            sliderQuestionOption.Name = "sliderQuestionOption";
            sliderQuestionOption.Size = new Size(105, 19);
            sliderQuestionOption.TabIndex = 66;
            sliderQuestionOption.TabStop = true;
            sliderQuestionOption.Text = "Slider Question";
            sliderQuestionOption.UseVisualStyleBackColor = true;
            sliderQuestionOption.CheckedChanged += sliderQuestionOption_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(231, 32);
            label1.TabIndex = 65;
            label1.Text = "Enter Question Type";
            // 
            // starsGroupBox
            // 
            starsGroupBox.Controls.Add(starsUpDown);
            starsGroupBox.Controls.Add(countStarsLabel);
            starsGroupBox.Enabled = false;
            starsGroupBox.Location = new Point(53, 388);
            starsGroupBox.Name = "starsGroupBox";
            starsGroupBox.Size = new Size(307, 55);
            starsGroupBox.TabIndex = 69;
            starsGroupBox.TabStop = false;
            starsGroupBox.Text = "Stars Question";
            // 
            // starsUpDown
            // 
            starsUpDown.Location = new Point(227, 15);
            starsUpDown.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            starsUpDown.Name = "starsUpDown";
            starsUpDown.Size = new Size(40, 23);
            starsUpDown.TabIndex = 60;
            // 
            // countStarsLabel
            // 
            countStarsLabel.AutoSize = true;
            countStarsLabel.Location = new Point(6, 19);
            countStarsLabel.Name = "countStarsLabel";
            countStarsLabel.Size = new Size(141, 15);
            countStarsLabel.TabIndex = 59;
            countStarsLabel.Text = "Number of stars question";
            // 
            // smileyFacesGroupBox
            // 
            smileyFacesGroupBox.Controls.Add(smileyFacesUpDown);
            smileyFacesGroupBox.Controls.Add(coumtsmileyFacesLabel);
            smileyFacesGroupBox.Enabled = false;
            smileyFacesGroupBox.Location = new Point(53, 333);
            smileyFacesGroupBox.Name = "smileyFacesGroupBox";
            smileyFacesGroupBox.Size = new Size(307, 45);
            smileyFacesGroupBox.TabIndex = 68;
            smileyFacesGroupBox.TabStop = false;
            smileyFacesGroupBox.Text = "Smiley Faces Question";
            // 
            // smileyFacesUpDown
            // 
            smileyFacesUpDown.Location = new Point(227, 17);
            smileyFacesUpDown.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            smileyFacesUpDown.Name = "smileyFacesUpDown";
            smileyFacesUpDown.Size = new Size(40, 23);
            smileyFacesUpDown.TabIndex = 59;
            // 
            // coumtsmileyFacesLabel
            // 
            coumtsmileyFacesLabel.AutoSize = true;
            coumtsmileyFacesLabel.Location = new Point(6, 19);
            coumtsmileyFacesLabel.Name = "coumtsmileyFacesLabel";
            coumtsmileyFacesLabel.Size = new Size(181, 15);
            coumtsmileyFacesLabel.TabIndex = 58;
            coumtsmileyFacesLabel.Text = "Number of smiley faces question";
            // 
            // sliderGroupBox
            // 
            sliderGroupBox.Controls.Add(endValueUpDown);
            sliderGroupBox.Controls.Add(startValueUpDown);
            sliderGroupBox.Controls.Add(endCaptionTextBox);
            sliderGroupBox.Controls.Add(startCaptionTextBox);
            sliderGroupBox.Controls.Add(endValueLabel);
            sliderGroupBox.Controls.Add(startValueLabel);
            sliderGroupBox.Controls.Add(endCaptionLabel);
            sliderGroupBox.Controls.Add(startCaptionLabel);
            sliderGroupBox.Enabled = false;
            sliderGroupBox.Location = new Point(441, 227);
            sliderGroupBox.Name = "sliderGroupBox";
            sliderGroupBox.Size = new Size(311, 216);
            sliderGroupBox.TabIndex = 67;
            sliderGroupBox.TabStop = false;
            sliderGroupBox.Text = "Slider Question";
            // 
            // endValueUpDown
            // 
            endValueUpDown.Location = new Point(122, 159);
            endValueUpDown.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            endValueUpDown.Name = "endValueUpDown";
            endValueUpDown.Size = new Size(40, 23);
            endValueUpDown.TabIndex = 59;
            // 
            // startValueUpDown
            // 
            startValueUpDown.Location = new Point(122, 122);
            startValueUpDown.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            startValueUpDown.Name = "startValueUpDown";
            startValueUpDown.Size = new Size(40, 23);
            startValueUpDown.TabIndex = 58;
            // 
            // endCaptionTextBox
            // 
            endCaptionTextBox.Location = new Point(83, 74);
            endCaptionTextBox.Name = "endCaptionTextBox";
            endCaptionTextBox.Size = new Size(217, 23);
            endCaptionTextBox.TabIndex = 57;
            // 
            // startCaptionTextBox
            // 
            startCaptionTextBox.Location = new Point(83, 37);
            startCaptionTextBox.Name = "startCaptionTextBox";
            startCaptionTextBox.Size = new Size(217, 23);
            startCaptionTextBox.TabIndex = 56;
            // 
            // endValueLabel
            // 
            endValueLabel.AutoSize = true;
            endValueLabel.Location = new Point(1, 161);
            endValueLabel.Name = "endValueLabel";
            endValueLabel.Size = new Size(58, 15);
            endValueLabel.TabIndex = 55;
            endValueLabel.Text = "End Value";
            // 
            // startValueLabel
            // 
            startValueLabel.AutoSize = true;
            startValueLabel.Location = new Point(1, 130);
            startValueLabel.Name = "startValueLabel";
            startValueLabel.Size = new Size(62, 15);
            startValueLabel.TabIndex = 54;
            startValueLabel.Text = "Start Value";
            // 
            // endCaptionLabel
            // 
            endCaptionLabel.AutoSize = true;
            endCaptionLabel.Location = new Point(1, 75);
            endCaptionLabel.Name = "endCaptionLabel";
            endCaptionLabel.Size = new Size(72, 15);
            endCaptionLabel.TabIndex = 53;
            endCaptionLabel.Text = "End Caption";
            // 
            // startCaptionLabel
            // 
            startCaptionLabel.AutoSize = true;
            startCaptionLabel.Location = new Point(1, 40);
            startCaptionLabel.Name = "startCaptionLabel";
            startCaptionLabel.Size = new Size(76, 15);
            startCaptionLabel.TabIndex = 52;
            startCaptionLabel.Text = "Start Caption";
            // 
            // generalQuestionGroupBox
            // 
            generalQuestionGroupBox.Controls.Add(textQuestionLabel);
            generalQuestionGroupBox.Controls.Add(orderQuestionUpDown);
            generalQuestionGroupBox.Controls.Add(textQuestionTextBox);
            generalQuestionGroupBox.Controls.Add(orderQuestionLabel);
            generalQuestionGroupBox.Location = new Point(53, 227);
            generalQuestionGroupBox.Name = "generalQuestionGroupBox";
            generalQuestionGroupBox.Size = new Size(307, 100);
            generalQuestionGroupBox.TabIndex = 66;
            generalQuestionGroupBox.TabStop = false;
            generalQuestionGroupBox.Text = "General Question";
            // 
            // textQuestionLabel
            // 
            textQuestionLabel.AutoSize = true;
            textQuestionLabel.Location = new Point(6, 33);
            textQuestionLabel.Name = "textQuestionLabel";
            textQuestionLabel.Size = new Size(91, 15);
            textQuestionLabel.TabIndex = 46;
            textQuestionLabel.Text = "Text of question";
            // 
            // orderQuestionUpDown
            // 
            orderQuestionUpDown.Location = new Point(180, 61);
            orderQuestionUpDown.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            orderQuestionUpDown.Name = "orderQuestionUpDown";
            orderQuestionUpDown.Size = new Size(40, 23);
            orderQuestionUpDown.TabIndex = 49;
            // 
            // textQuestionTextBox
            // 
            textQuestionTextBox.Location = new Point(103, 28);
            textQuestionTextBox.Multiline = true;
            textQuestionTextBox.Name = "textQuestionTextBox";
            textQuestionTextBox.Size = new Size(198, 23);
            textQuestionTextBox.TabIndex = 48;
            // 
            // orderQuestionLabel
            // 
            orderQuestionLabel.AutoSize = true;
            orderQuestionLabel.Location = new Point(6, 63);
            orderQuestionLabel.Name = "orderQuestionLabel";
            orderQuestionLabel.Size = new Size(100, 15);
            orderQuestionLabel.TabIndex = 47;
            orderQuestionLabel.Text = "Order of question";
            // 
            // AddDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 482);
            Controls.Add(questionTypeGroupBox);
            Controls.Add(starsGroupBox);
            Controls.Add(smileyFacesGroupBox);
            Controls.Add(sliderGroupBox);
            Controls.Add(generalQuestionGroupBox);
            Name = "AddDialog";
            Text = "AddDialog";
            questionTypeGroupBox.ResumeLayout(false);
            questionTypeGroupBox.PerformLayout();
            starsGroupBox.ResumeLayout(false);
            starsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)starsUpDown).EndInit();
            smileyFacesGroupBox.ResumeLayout(false);
            smileyFacesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)smileyFacesUpDown).EndInit();
            sliderGroupBox.ResumeLayout(false);
            sliderGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)endValueUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)startValueUpDown).EndInit();
            generalQuestionGroupBox.ResumeLayout(false);
            generalQuestionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)orderQuestionUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox questionTypeGroupBox;
        private RadioButton starsQuestionOption;
        private RadioButton smileyFacesQuestionOption;
        private RadioButton sliderQuestionOption;
        private Label label1;
        private GroupBox starsGroupBox;
        private NumericUpDown starsUpDown;
        private Label countStarsLabel;
        private GroupBox smileyFacesGroupBox;
        private NumericUpDown smileyFacesUpDown;
        private Label coumtsmileyFacesLabel;
        private GroupBox sliderGroupBox;
        private NumericUpDown endValueUpDown;
        private NumericUpDown startValueUpDown;
        private TextBox endCaptionTextBox;
        private TextBox startCaptionTextBox;
        private Label endValueLabel;
        private Label startValueLabel;
        private Label endCaptionLabel;
        private Label startCaptionLabel;
        private GroupBox generalQuestionGroupBox;
        private Label textQuestionLabel;
        private NumericUpDown orderQuestionUpDown;
        private TextBox textQuestionTextBox;
        private Label orderQuestionLabel;
    }
}