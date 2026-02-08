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
            detailsGroupBox = new GroupBox();
            smileyPanel = new Panel();
            smileyFacesCountLabel = new Label();
            smileyFacesUpDown = new NumericUpDown();
            starsPanel = new Panel();
            starsCountLabel = new Label();
            starsUpDown = new NumericUpDown();
            sliderPanel = new Panel();
            endCaptionTextBox = new TextBox();
            startCaptionTextBox = new TextBox();
            endValueUpDown = new NumericUpDown();
            startValueUpDown = new NumericUpDown();
            endCaptionLabel = new Label();
            startCaptionLabel = new Label();
            endValueLabel = new Label();
            startValueLabel = new Label();
            generalGroupBox = new GroupBox();
            orderUpDown = new NumericUpDown();
            textQuestionTextBox = new TextBox();
            typeQuestionGroup = new GroupBox();
            starsQuestionRadioButton = new RadioButton();
            smileyFacesQuestionRadioButton = new RadioButton();
            sliderQuestionRadioButton = new RadioButton();
            questionTextLabel = new Label();
            orderLabel = new Label();
            okAddButton = new Button();
            CancelAddButton = new Button();
            detailsGroupBox.SuspendLayout();
            smileyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smileyFacesUpDown).BeginInit();
            starsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)starsUpDown).BeginInit();
            sliderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)endValueUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)startValueUpDown).BeginInit();
            generalGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orderUpDown).BeginInit();
            typeQuestionGroup.SuspendLayout();
            SuspendLayout();
            // 
            // detailsGroupBox
            // 
            detailsGroupBox.Controls.Add(smileyPanel);
            detailsGroupBox.Controls.Add(starsPanel);
            detailsGroupBox.Controls.Add(sliderPanel);
            detailsGroupBox.Location = new Point(12, 267);
            detailsGroupBox.Name = "detailsGroupBox";
            detailsGroupBox.Size = new Size(639, 184);
            detailsGroupBox.TabIndex = 21;
            detailsGroupBox.TabStop = false;
            detailsGroupBox.Text = "Question Details";
            // 
            // smileyPanel
            // 
            smileyPanel.Controls.Add(smileyFacesCountLabel);
            smileyPanel.Controls.Add(smileyFacesUpDown);
            smileyPanel.Location = new Point(6, 22);
            smileyPanel.Name = "smileyPanel";
            smileyPanel.Size = new Size(621, 51);
            smileyPanel.TabIndex = 20;
            // 
            // smileyFacesCountLabel
            // 
            smileyFacesCountLabel.AutoSize = true;
            smileyFacesCountLabel.Location = new Point(7, 22);
            smileyFacesCountLabel.Name = "smileyFacesCountLabel";
            smileyFacesCountLabel.Size = new Size(98, 20);
            smileyFacesCountLabel.TabIndex = 18;
            smileyFacesCountLabel.Text = "Smiley faces :";
            // 
            // smileyFacesUpDown
            // 
            smileyFacesUpDown.Location = new Point(113, 20);
            smileyFacesUpDown.Margin = new Padding(3, 4, 3, 4);
            smileyFacesUpDown.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            smileyFacesUpDown.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            smileyFacesUpDown.Name = "smileyFacesUpDown";
            smileyFacesUpDown.Size = new Size(508, 27);
            smileyFacesUpDown.TabIndex = 19;
            smileyFacesUpDown.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // starsPanel
            // 
            starsPanel.Controls.Add(starsCountLabel);
            starsPanel.Controls.Add(starsUpDown);
            starsPanel.Location = new Point(6, 29);
            starsPanel.Name = "starsPanel";
            starsPanel.Size = new Size(621, 44);
            starsPanel.TabIndex = 19;
            // 
            // starsCountLabel
            // 
            starsCountLabel.AutoSize = true;
            starsCountLabel.Location = new Point(7, 18);
            starsCountLabel.Name = "starsCountLabel";
            starsCountLabel.Size = new Size(48, 20);
            starsCountLabel.TabIndex = 22;
            starsCountLabel.Text = "Stars :";
            // 
            // starsUpDown
            // 
            starsUpDown.Location = new Point(113, 16);
            starsUpDown.Margin = new Padding(3, 4, 3, 4);
            starsUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            starsUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            starsUpDown.Name = "starsUpDown";
            starsUpDown.Size = new Size(505, 27);
            starsUpDown.TabIndex = 23;
            starsUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
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
            sliderPanel.Location = new Point(6, 29);
            sliderPanel.Name = "sliderPanel";
            sliderPanel.Size = new Size(621, 149);
            sliderPanel.TabIndex = 0;
            // 
            // endCaptionTextBox
            // 
            endCaptionTextBox.Location = new Point(113, 117);
            endCaptionTextBox.Margin = new Padding(3, 4, 3, 4);
            endCaptionTextBox.Name = "endCaptionTextBox";
            endCaptionTextBox.Size = new Size(505, 27);
            endCaptionTextBox.TabIndex = 23;
            // 
            // startCaptionTextBox
            // 
            startCaptionTextBox.Location = new Point(113, 82);
            startCaptionTextBox.Margin = new Padding(3, 4, 3, 4);
            startCaptionTextBox.Name = "startCaptionTextBox";
            startCaptionTextBox.Size = new Size(505, 27);
            startCaptionTextBox.TabIndex = 22;
            // 
            // endValueUpDown
            // 
            endValueUpDown.Location = new Point(113, 48);
            endValueUpDown.Margin = new Padding(3, 4, 3, 4);
            endValueUpDown.Name = "endValueUpDown";
            endValueUpDown.Size = new Size(505, 27);
            endValueUpDown.TabIndex = 21;
            // 
            // startValueUpDown
            // 
            startValueUpDown.Location = new Point(113, 5);
            startValueUpDown.Margin = new Padding(3, 4, 3, 4);
            startValueUpDown.Name = "startValueUpDown";
            startValueUpDown.Size = new Size(505, 27);
            startValueUpDown.TabIndex = 20;
            // 
            // endCaptionLabel
            // 
            endCaptionLabel.AutoSize = true;
            endCaptionLabel.Location = new Point(3, 120);
            endCaptionLabel.Name = "endCaptionLabel";
            endCaptionLabel.Size = new Size(95, 20);
            endCaptionLabel.TabIndex = 19;
            endCaptionLabel.Text = "End caption :";
            // 
            // startCaptionLabel
            // 
            startCaptionLabel.AutoSize = true;
            startCaptionLabel.Location = new Point(2, 85);
            startCaptionLabel.Name = "startCaptionLabel";
            startCaptionLabel.Size = new Size(101, 20);
            startCaptionLabel.TabIndex = 18;
            startCaptionLabel.Text = "Start caption :";
            // 
            // endValueLabel
            // 
            endValueLabel.AutoSize = true;
            endValueLabel.Location = new Point(2, 50);
            endValueLabel.Name = "endValueLabel";
            endValueLabel.Size = new Size(80, 20);
            endValueLabel.TabIndex = 17;
            endValueLabel.Text = "End value :";
            // 
            // startValueLabel
            // 
            startValueLabel.AutoSize = true;
            startValueLabel.Location = new Point(2, 7);
            startValueLabel.Name = "startValueLabel";
            startValueLabel.Size = new Size(86, 20);
            startValueLabel.TabIndex = 16;
            startValueLabel.Text = "Start value :";
            // 
            // generalGroupBox
            // 
            generalGroupBox.Controls.Add(orderUpDown);
            generalGroupBox.Controls.Add(textQuestionTextBox);
            generalGroupBox.Controls.Add(typeQuestionGroup);
            generalGroupBox.Controls.Add(questionTextLabel);
            generalGroupBox.Controls.Add(orderLabel);
            generalGroupBox.Location = new Point(12, 12);
            generalGroupBox.Name = "generalGroupBox";
            generalGroupBox.Size = new Size(639, 249);
            generalGroupBox.TabIndex = 20;
            generalGroupBox.TabStop = false;
            generalGroupBox.Text = "General";
            // 
            // orderUpDown
            // 
            orderUpDown.Location = new Point(126, 66);
            orderUpDown.Margin = new Padding(3, 4, 3, 4);
            orderUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            orderUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            orderUpDown.Name = "orderUpDown";
            orderUpDown.Size = new Size(498, 27);
            orderUpDown.TabIndex = 5;
            orderUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // textQuestionTextBox
            // 
            textQuestionTextBox.Location = new Point(126, 31);
            textQuestionTextBox.Margin = new Padding(3, 4, 3, 4);
            textQuestionTextBox.Name = "textQuestionTextBox";
            textQuestionTextBox.Size = new Size(498, 27);
            textQuestionTextBox.TabIndex = 1;
            // 
            // typeQuestionGroup
            // 
            typeQuestionGroup.Controls.Add(starsQuestionRadioButton);
            typeQuestionGroup.Controls.Add(smileyFacesQuestionRadioButton);
            typeQuestionGroup.Controls.Add(sliderQuestionRadioButton);
            typeQuestionGroup.Location = new Point(13, 111);
            typeQuestionGroup.Margin = new Padding(3, 4, 3, 4);
            typeQuestionGroup.Name = "typeQuestionGroup";
            typeQuestionGroup.Padding = new Padding(3, 4, 3, 4);
            typeQuestionGroup.Size = new Size(620, 129);
            typeQuestionGroup.TabIndex = 0;
            typeQuestionGroup.TabStop = false;
            typeQuestionGroup.Text = "Type of Question";
            // 
            // starsQuestionRadioButton
            // 
            starsQuestionRadioButton.AutoSize = true;
            starsQuestionRadioButton.Location = new Point(7, 97);
            starsQuestionRadioButton.Margin = new Padding(3, 4, 3, 4);
            starsQuestionRadioButton.Name = "starsQuestionRadioButton";
            starsQuestionRadioButton.Size = new Size(123, 24);
            starsQuestionRadioButton.TabIndex = 2;
            starsQuestionRadioButton.TabStop = true;
            starsQuestionRadioButton.Text = "Stars question";
            starsQuestionRadioButton.UseVisualStyleBackColor = true;
            // 
            // smileyFacesQuestionRadioButton
            // 
            smileyFacesQuestionRadioButton.AutoSize = true;
            smileyFacesQuestionRadioButton.Location = new Point(7, 64);
            smileyFacesQuestionRadioButton.Margin = new Padding(3, 4, 3, 4);
            smileyFacesQuestionRadioButton.Name = "smileyFacesQuestionRadioButton";
            smileyFacesQuestionRadioButton.Size = new Size(173, 24);
            smileyFacesQuestionRadioButton.TabIndex = 1;
            smileyFacesQuestionRadioButton.TabStop = true;
            smileyFacesQuestionRadioButton.Text = "Smiley faces question";
            smileyFacesQuestionRadioButton.UseVisualStyleBackColor = true;
            // 
            // sliderQuestionRadioButton
            // 
            sliderQuestionRadioButton.AutoSize = true;
            sliderQuestionRadioButton.Location = new Point(7, 30);
            sliderQuestionRadioButton.Margin = new Padding(3, 4, 3, 4);
            sliderQuestionRadioButton.Name = "sliderQuestionRadioButton";
            sliderQuestionRadioButton.Size = new Size(129, 24);
            sliderQuestionRadioButton.TabIndex = 0;
            sliderQuestionRadioButton.TabStop = true;
            sliderQuestionRadioButton.Text = "Slider question";
            sliderQuestionRadioButton.UseVisualStyleBackColor = true;
            // 
            // questionTextLabel
            // 
            questionTextLabel.AutoSize = true;
            questionTextLabel.Location = new Point(13, 34);
            questionTextLabel.Name = "questionTextLabel";
            questionTextLabel.Size = new Size(104, 20);
            questionTextLabel.TabIndex = 0;
            questionTextLabel.Text = "Question text :";
            // 
            // orderLabel
            // 
            orderLabel.AutoSize = true;
            orderLabel.Location = new Point(13, 68);
            orderLabel.Name = "orderLabel";
            orderLabel.Size = new Size(54, 20);
            orderLabel.TabIndex = 3;
            orderLabel.Text = "Order :";
            // 
            // okAddButton
            // 
            okAddButton.Location = new Point(473, 483);
            okAddButton.Margin = new Padding(3, 4, 3, 4);
            okAddButton.Name = "okAddButton";
            okAddButton.Size = new Size(86, 31);
            okAddButton.TabIndex = 19;
            okAddButton.Text = "OK";
            okAddButton.UseVisualStyleBackColor = true;
            okAddButton.Click += okAddButton_Click;
            // 
            // CancelAddButton
            // 
            CancelAddButton.Location = new Point(565, 483);
            CancelAddButton.Margin = new Padding(3, 4, 3, 4);
            CancelAddButton.Name = "CancelAddButton";
            CancelAddButton.Size = new Size(86, 31);
            CancelAddButton.TabIndex = 18;
            CancelAddButton.Text = "Cancel";
            CancelAddButton.UseVisualStyleBackColor = true;
            CancelAddButton.Click += CancelAddButton_Click;
            // 
            // EditDialog
            // 
            AcceptButton = okAddButton;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CancelAddButton;
            ClientSize = new Size(667, 532);
            Controls.Add(detailsGroupBox);
            Controls.Add(generalGroupBox);
            Controls.Add(okAddButton);
            Controls.Add(CancelAddButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "EditDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditDialog";
            Load += EditDialog_Load;
            detailsGroupBox.ResumeLayout(false);
            smileyPanel.ResumeLayout(false);
            smileyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)smileyFacesUpDown).EndInit();
            starsPanel.ResumeLayout(false);
            starsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)starsUpDown).EndInit();
            sliderPanel.ResumeLayout(false);
            sliderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)endValueUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)startValueUpDown).EndInit();
            generalGroupBox.ResumeLayout(false);
            generalGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)orderUpDown).EndInit();
            typeQuestionGroup.ResumeLayout(false);
            typeQuestionGroup.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox detailsGroupBox;
        private Panel smileyPanel;
        private Label smileyFacesCountLabel;
        private NumericUpDown smileyFacesUpDown;
        private Panel starsPanel;
        private Label starsCountLabel;
        private NumericUpDown starsUpDown;
        private Panel sliderPanel;
        private TextBox endCaptionTextBox;
        private TextBox startCaptionTextBox;
        private NumericUpDown endValueUpDown;
        private NumericUpDown startValueUpDown;
        private Label endCaptionLabel;
        private Label startCaptionLabel;
        private Label endValueLabel;
        private Label startValueLabel;
        private GroupBox generalGroupBox;
        private NumericUpDown orderUpDown;
        private TextBox textQuestionTextBox;
        private GroupBox typeQuestionGroup;
        private RadioButton starsQuestionRadioButton;
        private RadioButton smileyFacesQuestionRadioButton;
        private RadioButton sliderQuestionRadioButton;
        private Label questionTextLabel;
        private Label orderLabel;
        private Button okAddButton;
        private Button CancelAddButton;
    }
}