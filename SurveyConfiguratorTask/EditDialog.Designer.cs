namespace SurveyConfiguratorTask
{
    partial class EditDialog
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
            okAddButton = new Button();
            CancelAddButton = new Button();
            starsPanel = new Panel();
            starsUpDown = new NumericUpDown();
            starsCountLabel = new Label();
            smileyPanel = new Panel();
            smileyFacesUpDown = new NumericUpDown();
            smileyFacesCountLabel = new Label();
            sliderPanel = new Panel();
            endCaptionTextBox = new TextBox();
            startCaptionTextBox = new TextBox();
            endValueUpDown = new NumericUpDown();
            startValueUpDown = new NumericUpDown();
            endCaptionLabel = new Label();
            startCaptionLabel = new Label();
            endValueLabel = new Label();
            startValueLabel = new Label();
            textPanel = new Panel();
            textQuestionTextBox = new TextBox();
            questionTextLabel = new Label();
            typeQuestionGroup = new GroupBox();
            starsQuestionRadioButton = new RadioButton();
            smileyFacesQuestionRadioButton = new RadioButton();
            sliderQuestionRadioButton = new RadioButton();
            orderPanel = new Panel();
            orderUpDown = new NumericUpDown();
            orderLabel = new Label();
            starsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)starsUpDown).BeginInit();
            smileyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smileyFacesUpDown).BeginInit();
            sliderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)endValueUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)startValueUpDown).BeginInit();
            textPanel.SuspendLayout();
            typeQuestionGroup.SuspendLayout();
            orderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orderUpDown).BeginInit();
            SuspendLayout();
            // 
            // okAddButton
            // 
            okAddButton.Location = new Point(338, 593);
            okAddButton.Name = "okAddButton";
            okAddButton.Size = new Size(114, 51);
            okAddButton.TabIndex = 13;
            okAddButton.Text = "OK";
            okAddButton.UseVisualStyleBackColor = true;
            okAddButton.Click += okAddButton_Click;
            // 
            // CancelAddButton
            // 
            CancelAddButton.Location = new Point(458, 593);
            CancelAddButton.Name = "CancelAddButton";
            CancelAddButton.Size = new Size(114, 51);
            CancelAddButton.TabIndex = 12;
            CancelAddButton.Text = "Cancel";
            CancelAddButton.UseVisualStyleBackColor = true;
            CancelAddButton.Click += CancelAddButton_Click;
            // 
            // starsPanel
            // 
            starsPanel.Controls.Add(starsUpDown);
            starsPanel.Controls.Add(starsCountLabel);
            starsPanel.Enabled = false;
            starsPanel.Location = new Point(12, 457);
            starsPanel.Name = "starsPanel";
            starsPanel.Size = new Size(560, 51);
            starsPanel.TabIndex = 11;
            // 
            // starsUpDown
            // 
            starsUpDown.Location = new Point(95, 17);
            starsUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            starsUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            starsUpDown.Name = "starsUpDown";
            starsUpDown.Size = new Size(120, 23);
            starsUpDown.TabIndex = 5;
            starsUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // starsCountLabel
            // 
            starsCountLabel.AutoSize = true;
            starsCountLabel.Location = new Point(6, 19);
            starsCountLabel.Name = "starsCountLabel";
            starsCountLabel.Size = new Size(32, 15);
            starsCountLabel.TabIndex = 3;
            starsCountLabel.Text = "Stars";
            // 
            // smileyPanel
            // 
            smileyPanel.Controls.Add(smileyFacesUpDown);
            smileyPanel.Controls.Add(smileyFacesCountLabel);
            smileyPanel.Enabled = false;
            smileyPanel.Location = new Point(12, 388);
            smileyPanel.Name = "smileyPanel";
            smileyPanel.Size = new Size(560, 51);
            smileyPanel.TabIndex = 10;
            // 
            // smileyFacesUpDown
            // 
            smileyFacesUpDown.Location = new Point(95, 17);
            smileyFacesUpDown.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            smileyFacesUpDown.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            smileyFacesUpDown.Name = "smileyFacesUpDown";
            smileyFacesUpDown.Size = new Size(120, 23);
            smileyFacesUpDown.TabIndex = 5;
            smileyFacesUpDown.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // smileyFacesCountLabel
            // 
            smileyFacesCountLabel.AutoSize = true;
            smileyFacesCountLabel.Location = new Point(6, 19);
            smileyFacesCountLabel.Name = "smileyFacesCountLabel";
            smileyFacesCountLabel.Size = new Size(72, 15);
            smileyFacesCountLabel.TabIndex = 3;
            smileyFacesCountLabel.Text = "Smiley faces";
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
            sliderPanel.Enabled = false;
            sliderPanel.Location = new Point(12, 197);
            sliderPanel.Name = "sliderPanel";
            sliderPanel.Size = new Size(560, 174);
            sliderPanel.TabIndex = 9;
            // 
            // endCaptionTextBox
            // 
            endCaptionTextBox.Location = new Point(95, 146);
            endCaptionTextBox.Name = "endCaptionTextBox";
            endCaptionTextBox.Size = new Size(455, 23);
            endCaptionTextBox.TabIndex = 7;
            // 
            // startCaptionTextBox
            // 
            startCaptionTextBox.Location = new Point(95, 105);
            startCaptionTextBox.Name = "startCaptionTextBox";
            startCaptionTextBox.Size = new Size(455, 23);
            startCaptionTextBox.TabIndex = 6;
            // 
            // endValueUpDown
            // 
            endValueUpDown.Location = new Point(95, 68);
            endValueUpDown.Name = "endValueUpDown";
            endValueUpDown.Size = new Size(120, 23);
            endValueUpDown.TabIndex = 5;
            // 
            // startValueUpDown
            // 
            startValueUpDown.Location = new Point(95, 20);
            startValueUpDown.Name = "startValueUpDown";
            startValueUpDown.Size = new Size(120, 23);
            startValueUpDown.TabIndex = 4;
            // 
            // endCaptionLabel
            // 
            endCaptionLabel.AutoSize = true;
            endCaptionLabel.Location = new Point(6, 149);
            endCaptionLabel.Name = "endCaptionLabel";
            endCaptionLabel.Size = new Size(78, 15);
            endCaptionLabel.TabIndex = 3;
            endCaptionLabel.Text = "End Caption :";
            // 
            // startCaptionLabel
            // 
            startCaptionLabel.AutoSize = true;
            startCaptionLabel.Location = new Point(6, 108);
            startCaptionLabel.Name = "startCaptionLabel";
            startCaptionLabel.Size = new Size(82, 15);
            startCaptionLabel.TabIndex = 2;
            startCaptionLabel.Text = "Start Caption :";
            // 
            // endValueLabel
            // 
            endValueLabel.AutoSize = true;
            endValueLabel.Location = new Point(6, 70);
            endValueLabel.Name = "endValueLabel";
            endValueLabel.Size = new Size(58, 15);
            endValueLabel.TabIndex = 1;
            endValueLabel.Text = "End value";
            // 
            // startValueLabel
            // 
            startValueLabel.AutoSize = true;
            startValueLabel.Location = new Point(6, 22);
            startValueLabel.Name = "startValueLabel";
            startValueLabel.Size = new Size(62, 15);
            startValueLabel.TabIndex = 0;
            startValueLabel.Text = "Start value";
            // 
            // textPanel
            // 
            textPanel.Controls.Add(textQuestionTextBox);
            textPanel.Controls.Add(questionTextLabel);
            textPanel.Location = new Point(12, 132);
            textPanel.Name = "textPanel";
            textPanel.Size = new Size(560, 49);
            textPanel.TabIndex = 8;
            // 
            // textQuestionTextBox
            // 
            textQuestionTextBox.Location = new Point(95, 13);
            textQuestionTextBox.Name = "textQuestionTextBox";
            textQuestionTextBox.Size = new Size(455, 23);
            textQuestionTextBox.TabIndex = 1;
            // 
            // questionTextLabel
            // 
            questionTextLabel.AutoSize = true;
            questionTextLabel.Location = new Point(6, 16);
            questionTextLabel.Name = "questionTextLabel";
            questionTextLabel.Size = new Size(83, 15);
            questionTextLabel.TabIndex = 0;
            questionTextLabel.Text = "Question text :";
            // 
            // typeQuestionGroup
            // 
            typeQuestionGroup.Controls.Add(starsQuestionRadioButton);
            typeQuestionGroup.Controls.Add(smileyFacesQuestionRadioButton);
            typeQuestionGroup.Controls.Add(sliderQuestionRadioButton);
            typeQuestionGroup.Enabled = false;
            typeQuestionGroup.Location = new Point(12, 16);
            typeQuestionGroup.Name = "typeQuestionGroup";
            typeQuestionGroup.Size = new Size(560, 97);
            typeQuestionGroup.TabIndex = 7;
            typeQuestionGroup.TabStop = false;
            typeQuestionGroup.Text = "Type of quetion";
            // 
            // starsQuestionRadioButton
            // 
            starsQuestionRadioButton.AutoSize = true;
            starsQuestionRadioButton.Location = new Point(6, 72);
            starsQuestionRadioButton.Name = "starsQuestionRadioButton";
            starsQuestionRadioButton.Size = new Size(101, 19);
            starsQuestionRadioButton.TabIndex = 2;
            starsQuestionRadioButton.TabStop = true;
            starsQuestionRadioButton.Text = "Stars Question";
            starsQuestionRadioButton.UseVisualStyleBackColor = true;
            // 
            // smileyFacesQuestionRadioButton
            // 
            smileyFacesQuestionRadioButton.AutoSize = true;
            smileyFacesQuestionRadioButton.Location = new Point(6, 47);
            smileyFacesQuestionRadioButton.Name = "smileyFacesQuestionRadioButton";
            smileyFacesQuestionRadioButton.Size = new Size(141, 19);
            smileyFacesQuestionRadioButton.TabIndex = 1;
            smileyFacesQuestionRadioButton.TabStop = true;
            smileyFacesQuestionRadioButton.Text = "Smiley faces Question";
            smileyFacesQuestionRadioButton.UseVisualStyleBackColor = true;
            // 
            // sliderQuestionRadioButton
            // 
            sliderQuestionRadioButton.AutoSize = true;
            sliderQuestionRadioButton.Location = new Point(6, 22);
            sliderQuestionRadioButton.Name = "sliderQuestionRadioButton";
            sliderQuestionRadioButton.Size = new Size(105, 19);
            sliderQuestionRadioButton.TabIndex = 0;
            sliderQuestionRadioButton.TabStop = true;
            sliderQuestionRadioButton.Text = "Slider Question";
            sliderQuestionRadioButton.UseVisualStyleBackColor = true;
            // 
            // orderPanel
            // 
            orderPanel.Controls.Add(orderUpDown);
            orderPanel.Controls.Add(orderLabel);
            orderPanel.Location = new Point(12, 523);
            orderPanel.Name = "orderPanel";
            orderPanel.Size = new Size(560, 51);
            orderPanel.TabIndex = 14;
            // 
            // orderUpDown
            // 
            orderUpDown.Location = new Point(95, 17);
            orderUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            orderUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            orderUpDown.Name = "orderUpDown";
            orderUpDown.Size = new Size(120, 23);
            orderUpDown.TabIndex = 5;
            orderUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // orderLabel
            // 
            orderLabel.AutoSize = true;
            orderLabel.Location = new Point(6, 19);
            orderLabel.Name = "orderLabel";
            orderLabel.Size = new Size(37, 15);
            orderLabel.TabIndex = 3;
            orderLabel.Text = "Order";
            // 
            // EditDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 661);
            Controls.Add(orderPanel);
            Controls.Add(okAddButton);
            Controls.Add(CancelAddButton);
            Controls.Add(starsPanel);
            Controls.Add(smileyPanel);
            Controls.Add(sliderPanel);
            Controls.Add(textPanel);
            Controls.Add(typeQuestionGroup);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "EditDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditDialog";
            Load += EditDialog_Load;
            starsPanel.ResumeLayout(false);
            starsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)starsUpDown).EndInit();
            smileyPanel.ResumeLayout(false);
            smileyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)smileyFacesUpDown).EndInit();
            sliderPanel.ResumeLayout(false);
            sliderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)endValueUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)startValueUpDown).EndInit();
            textPanel.ResumeLayout(false);
            textPanel.PerformLayout();
            typeQuestionGroup.ResumeLayout(false);
            typeQuestionGroup.PerformLayout();
            orderPanel.ResumeLayout(false);
            orderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)orderUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button okAddButton;
        private Button CancelAddButton;
        private Panel starsPanel;
        private NumericUpDown starsUpDown;
        private Label starsCountLabel;
        private Panel smileyPanel;
        private NumericUpDown smileyFacesUpDown;
        private Label smileyFacesCountLabel;
        private Panel sliderPanel;
        private TextBox endCaptionTextBox;
        private TextBox startCaptionTextBox;
        private NumericUpDown endValueUpDown;
        private NumericUpDown startValueUpDown;
        private Label endCaptionLabel;
        private Label startCaptionLabel;
        private Label endValueLabel;
        private Label startValueLabel;
        private Panel textPanel;
        private TextBox textQuestionTextBox;
        private Label questionTextLabel;
        private GroupBox typeQuestionGroup;
        private RadioButton starsQuestionRadioButton;
        private RadioButton smileyFacesQuestionRadioButton;
        private RadioButton sliderQuestionRadioButton;
        private Panel orderPanel;
        private NumericUpDown orderUpDown;
        private Label orderLabel;
    }
}