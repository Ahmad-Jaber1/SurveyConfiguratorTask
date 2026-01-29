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
            typeQuestionGroup = new GroupBox();
            starsQuestionRadioButton = new RadioButton();
            smileyFacesQuestionRadioButton = new RadioButton();
            sliderQuestionRadioButton = new RadioButton();
            textPanel = new Panel();
            textQuestionTextBox = new TextBox();
            questionTextLabel = new Label();
            sliderPanel = new Panel();
            endCaptionTextBox = new TextBox();
            startCaptionTextBox = new TextBox();
            endValueUpDown = new NumericUpDown();
            startValueUpDown = new NumericUpDown();
            endCaptionLabel = new Label();
            startCaptionLabel = new Label();
            endValueLabel = new Label();
            startValueLabel = new Label();
            smileyPanel = new Panel();
            smileyFacesUpDown = new NumericUpDown();
            smileyFacesCountLabel = new Label();
            starsPanel = new Panel();
            starsUpDown = new NumericUpDown();
            starsCountLabel = new Label();
            CancelAddButton = new Button();
            okAddButton = new Button();
            typeQuestionGroup.SuspendLayout();
            textPanel.SuspendLayout();
            sliderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)endValueUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)startValueUpDown).BeginInit();
            smileyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smileyFacesUpDown).BeginInit();
            starsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)starsUpDown).BeginInit();
            SuspendLayout();
            // 
            // typeQuestionGroup
            // 
            typeQuestionGroup.Controls.Add(starsQuestionRadioButton);
            typeQuestionGroup.Controls.Add(smileyFacesQuestionRadioButton);
            typeQuestionGroup.Controls.Add(sliderQuestionRadioButton);
            typeQuestionGroup.Location = new Point(14, 16);
            typeQuestionGroup.Margin = new Padding(3, 4, 3, 4);
            typeQuestionGroup.Name = "typeQuestionGroup";
            typeQuestionGroup.Padding = new Padding(3, 4, 3, 4);
            typeQuestionGroup.Size = new Size(640, 129);
            typeQuestionGroup.TabIndex = 0;
            typeQuestionGroup.TabStop = false;
            typeQuestionGroup.Text = "Type of quetion";
            // 
            // starsQuestionRadioButton
            // 
            starsQuestionRadioButton.AutoSize = true;
            starsQuestionRadioButton.Location = new Point(7, 96);
            starsQuestionRadioButton.Margin = new Padding(3, 4, 3, 4);
            starsQuestionRadioButton.Name = "starsQuestionRadioButton";
            starsQuestionRadioButton.Size = new Size(125, 24);
            starsQuestionRadioButton.TabIndex = 2;
            starsQuestionRadioButton.TabStop = true;
            starsQuestionRadioButton.Text = "Stars Question";
            starsQuestionRadioButton.UseVisualStyleBackColor = true;
            starsQuestionRadioButton.CheckedChanged += Radio_CheckedChanged;
            // 
            // smileyFacesQuestionRadioButton
            // 
            smileyFacesQuestionRadioButton.AutoSize = true;
            smileyFacesQuestionRadioButton.Location = new Point(7, 63);
            smileyFacesQuestionRadioButton.Margin = new Padding(3, 4, 3, 4);
            smileyFacesQuestionRadioButton.Name = "smileyFacesQuestionRadioButton";
            smileyFacesQuestionRadioButton.Size = new Size(175, 24);
            smileyFacesQuestionRadioButton.TabIndex = 1;
            smileyFacesQuestionRadioButton.TabStop = true;
            smileyFacesQuestionRadioButton.Text = "Smiley faces Question";
            smileyFacesQuestionRadioButton.UseVisualStyleBackColor = true;
            smileyFacesQuestionRadioButton.CheckedChanged += Radio_CheckedChanged;
            // 
            // sliderQuestionRadioButton
            // 
            sliderQuestionRadioButton.AutoSize = true;
            sliderQuestionRadioButton.Location = new Point(7, 29);
            sliderQuestionRadioButton.Margin = new Padding(3, 4, 3, 4);
            sliderQuestionRadioButton.Name = "sliderQuestionRadioButton";
            sliderQuestionRadioButton.Size = new Size(131, 24);
            sliderQuestionRadioButton.TabIndex = 0;
            sliderQuestionRadioButton.TabStop = true;
            sliderQuestionRadioButton.Text = "Slider Question";
            sliderQuestionRadioButton.UseVisualStyleBackColor = true;
            sliderQuestionRadioButton.CheckedChanged += Radio_CheckedChanged;
            // 
            // textPanel
            // 
            textPanel.Controls.Add(textQuestionTextBox);
            textPanel.Controls.Add(questionTextLabel);
            textPanel.Location = new Point(14, 171);
            textPanel.Margin = new Padding(3, 4, 3, 4);
            textPanel.Name = "textPanel";
            textPanel.Size = new Size(640, 65);
            textPanel.TabIndex = 1;
            // 
            // textQuestionTextBox
            // 
            textQuestionTextBox.Location = new Point(109, 17);
            textQuestionTextBox.Margin = new Padding(3, 4, 3, 4);
            textQuestionTextBox.Name = "textQuestionTextBox";
            textQuestionTextBox.Size = new Size(519, 27);
            textQuestionTextBox.TabIndex = 1;
            // 
            // questionTextLabel
            // 
            questionTextLabel.AutoSize = true;
            questionTextLabel.Location = new Point(7, 21);
            questionTextLabel.Name = "questionTextLabel";
            questionTextLabel.Size = new Size(104, 20);
            questionTextLabel.TabIndex = 0;
            questionTextLabel.Text = "Question text :";
            // 
            // sliderPanel
            // 
            sliderPanel.Controls.Add(endCaptionTextBox);
            sliderPanel.Controls.Add(startCaptionTextBox);
            sliderPanel.Controls.Add(endValueUpDown);
            sliderPanel.Controls.Add(startValueUpDown);
            sliderPanel.Controls.Add(endCaptionLabel);
            sliderPanel.Controls.Add(startCaptionLabel);
            sliderPanel.Controls.Add(endValueLabel);
            sliderPanel.Controls.Add(startValueLabel);
            sliderPanel.Location = new Point(14, 257);
            sliderPanel.Margin = new Padding(3, 4, 3, 4);
            sliderPanel.Name = "sliderPanel";
            sliderPanel.Size = new Size(640, 232);
            sliderPanel.TabIndex = 2;
            // 
            // endCaptionTextBox
            // 
            endCaptionTextBox.Location = new Point(109, 195);
            endCaptionTextBox.Margin = new Padding(3, 4, 3, 4);
            endCaptionTextBox.Name = "endCaptionTextBox";
            endCaptionTextBox.Size = new Size(519, 27);
            endCaptionTextBox.TabIndex = 7;
            // 
            // startCaptionTextBox
            // 
            startCaptionTextBox.Location = new Point(109, 140);
            startCaptionTextBox.Margin = new Padding(3, 4, 3, 4);
            startCaptionTextBox.Name = "startCaptionTextBox";
            startCaptionTextBox.Size = new Size(519, 27);
            startCaptionTextBox.TabIndex = 6;
            // 
            // endValueUpDown
            // 
            endValueUpDown.Location = new Point(109, 91);
            endValueUpDown.Margin = new Padding(3, 4, 3, 4);
            endValueUpDown.Name = "endValueUpDown";
            endValueUpDown.Size = new Size(137, 27);
            endValueUpDown.TabIndex = 5;
            // 
            // startValueUpDown
            // 
            startValueUpDown.Location = new Point(109, 27);
            startValueUpDown.Margin = new Padding(3, 4, 3, 4);
            startValueUpDown.Name = "startValueUpDown";
            startValueUpDown.Size = new Size(137, 27);
            startValueUpDown.TabIndex = 4;
            // 
            // endCaptionLabel
            // 
            endCaptionLabel.AutoSize = true;
            endCaptionLabel.Location = new Point(7, 199);
            endCaptionLabel.Name = "endCaptionLabel";
            endCaptionLabel.Size = new Size(97, 20);
            endCaptionLabel.TabIndex = 3;
            endCaptionLabel.Text = "End Caption :";
            // 
            // startCaptionLabel
            // 
            startCaptionLabel.AutoSize = true;
            startCaptionLabel.Location = new Point(7, 144);
            startCaptionLabel.Name = "startCaptionLabel";
            startCaptionLabel.Size = new Size(103, 20);
            startCaptionLabel.TabIndex = 2;
            startCaptionLabel.Text = "Start Caption :";
            // 
            // endValueLabel
            // 
            endValueLabel.AutoSize = true;
            endValueLabel.Location = new Point(7, 93);
            endValueLabel.Name = "endValueLabel";
            endValueLabel.Size = new Size(73, 20);
            endValueLabel.TabIndex = 1;
            endValueLabel.Text = "End value";
            // 
            // startValueLabel
            // 
            startValueLabel.AutoSize = true;
            startValueLabel.Location = new Point(7, 29);
            startValueLabel.Name = "startValueLabel";
            startValueLabel.Size = new Size(79, 20);
            startValueLabel.TabIndex = 0;
            startValueLabel.Text = "Start value";
            // 
            // smileyPanel
            // 
            smileyPanel.Controls.Add(smileyFacesUpDown);
            smileyPanel.Controls.Add(smileyFacesCountLabel);
            smileyPanel.Location = new Point(14, 512);
            smileyPanel.Margin = new Padding(3, 4, 3, 4);
            smileyPanel.Name = "smileyPanel";
            smileyPanel.Size = new Size(640, 68);
            smileyPanel.TabIndex = 3;
            // 
            // smileyFacesUpDown
            // 
            smileyFacesUpDown.Location = new Point(109, 23);
            smileyFacesUpDown.Margin = new Padding(3, 4, 3, 4);
            smileyFacesUpDown.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            smileyFacesUpDown.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            smileyFacesUpDown.Name = "smileyFacesUpDown";
            smileyFacesUpDown.Size = new Size(137, 27);
            smileyFacesUpDown.TabIndex = 5;
            smileyFacesUpDown.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // smileyFacesCountLabel
            // 
            smileyFacesCountLabel.AutoSize = true;
            smileyFacesCountLabel.Location = new Point(7, 25);
            smileyFacesCountLabel.Name = "smileyFacesCountLabel";
            smileyFacesCountLabel.Size = new Size(91, 20);
            smileyFacesCountLabel.TabIndex = 3;
            smileyFacesCountLabel.Text = "Smiley faces";
            // 
            // starsPanel
            // 
            starsPanel.Controls.Add(starsUpDown);
            starsPanel.Controls.Add(starsCountLabel);
            starsPanel.Location = new Point(14, 604);
            starsPanel.Margin = new Padding(3, 4, 3, 4);
            starsPanel.Name = "starsPanel";
            starsPanel.Size = new Size(640, 68);
            starsPanel.TabIndex = 4;
            // 
            // starsUpDown
            // 
            starsUpDown.Location = new Point(109, 23);
            starsUpDown.Margin = new Padding(3, 4, 3, 4);
            starsUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            starsUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            starsUpDown.Name = "starsUpDown";
            starsUpDown.Size = new Size(137, 27);
            starsUpDown.TabIndex = 5;
            starsUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // starsCountLabel
            // 
            starsCountLabel.AutoSize = true;
            starsCountLabel.Location = new Point(7, 25);
            starsCountLabel.Name = "starsCountLabel";
            starsCountLabel.Size = new Size(41, 20);
            starsCountLabel.TabIndex = 3;
            starsCountLabel.Text = "Stars";
            // 
            // CancelAddButton
            // 
            CancelAddButton.Location = new Point(523, 785);
            CancelAddButton.Margin = new Padding(3, 4, 3, 4);
            CancelAddButton.Name = "CancelAddButton";
            CancelAddButton.Size = new Size(130, 68);
            CancelAddButton.TabIndex = 5;
            CancelAddButton.Text = "Cancel";
            CancelAddButton.UseVisualStyleBackColor = true;
            CancelAddButton.Click += CancelAddButton_Click;
            // 
            // okAddButton
            // 
            okAddButton.Location = new Point(386, 785);
            okAddButton.Margin = new Padding(3, 4, 3, 4);
            okAddButton.Name = "okAddButton";
            okAddButton.Size = new Size(130, 68);
            okAddButton.TabIndex = 6;
            okAddButton.Text = "OK";
            okAddButton.UseVisualStyleBackColor = true;
            okAddButton.Click += okAddButton_Click;
            // 
            // AddDialog
            // 
            AcceptButton = okAddButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(667, 881);
            Controls.Add(okAddButton);
            Controls.Add(CancelAddButton);
            Controls.Add(starsPanel);
            Controls.Add(smileyPanel);
            Controls.Add(sliderPanel);
            Controls.Add(textPanel);
            Controls.Add(typeQuestionGroup);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "AddDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddDialog";
            typeQuestionGroup.ResumeLayout(false);
            typeQuestionGroup.PerformLayout();
            textPanel.ResumeLayout(false);
            textPanel.PerformLayout();
            sliderPanel.ResumeLayout(false);
            sliderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)endValueUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)startValueUpDown).EndInit();
            smileyPanel.ResumeLayout(false);
            smileyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)smileyFacesUpDown).EndInit();
            starsPanel.ResumeLayout(false);
            starsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)starsUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox typeQuestionGroup;
        private RadioButton starsQuestionRadioButton;
        private RadioButton smileyFacesQuestionRadioButton;
        private RadioButton sliderQuestionRadioButton;
        private Panel textPanel;
        private Label questionTextLabel;
        private TextBox textQuestionTextBox;
        private Panel sliderPanel;
        private NumericUpDown endValueUpDown;
        private NumericUpDown startValueUpDown;
        private Label endCaptionLabel;
        private Label startCaptionLabel;
        private Label endValueLabel;
        private Label startValueLabel;
        private TextBox endCaptionTextBox;
        private TextBox startCaptionTextBox;
        private Panel smileyPanel;
        private NumericUpDown smileyFacesUpDown;
        private Label smileyFacesCountLabel;
        private Panel starsPanel;
        private NumericUpDown starsUpDown;
        private Label starsCountLabel;
        private Button CancelAddButton;
        private Button okAddButton;
    }
}