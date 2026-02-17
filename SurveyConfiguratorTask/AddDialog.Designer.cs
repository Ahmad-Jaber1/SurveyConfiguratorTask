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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDialog));
            typeQuestionGroup = new GroupBox();
            starsQuestionRadioButton = new RadioButton();
            smileyFacesQuestionRadioButton = new RadioButton();
            sliderQuestionRadioButton = new RadioButton();
            CancelAddButton = new Button();
            okAddButton = new Button();
            orderUpDown = new NumericUpDown();
            orderLabel = new Label();
            textQuestionTextBox = new TextBox();
            questionTextLabel = new Label();
            generalGroupBox = new GroupBox();
            starsPanel = new Panel();
            starsCountLabel = new Label();
            starsUpDown = new NumericUpDown();
            detailsGroupBox = new GroupBox();
            smileyPanel = new Panel();
            smileyFacesCountLabel = new Label();
            smileyFacesUpDown = new NumericUpDown();
            sliderPanel = new Panel();
            endCaptionTextBox = new TextBox();
            startCaptionTextBox = new TextBox();
            endValueUpDown = new NumericUpDown();
            endCaptionLabel = new Label();
            startCaptionLabel = new Label();
            startValueLabel = new Label();
            endValueLabel = new Label();
            startValueUpDown = new NumericUpDown();
            typeQuestionGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orderUpDown).BeginInit();
            generalGroupBox.SuspendLayout();
            starsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)starsUpDown).BeginInit();
            detailsGroupBox.SuspendLayout();
            smileyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)smileyFacesUpDown).BeginInit();
            sliderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)endValueUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)startValueUpDown).BeginInit();
            SuspendLayout();
            // 
            // typeQuestionGroup
            // 
            typeQuestionGroup.Controls.Add(starsQuestionRadioButton);
            typeQuestionGroup.Controls.Add(smileyFacesQuestionRadioButton);
            typeQuestionGroup.Controls.Add(sliderQuestionRadioButton);
            resources.ApplyResources(typeQuestionGroup, "typeQuestionGroup");
            typeQuestionGroup.Name = "typeQuestionGroup";
            typeQuestionGroup.TabStop = false;
            // 
            // starsQuestionRadioButton
            // 
            resources.ApplyResources(starsQuestionRadioButton, "starsQuestionRadioButton");
            starsQuestionRadioButton.Name = "starsQuestionRadioButton";
            starsQuestionRadioButton.TabStop = true;
            starsQuestionRadioButton.UseVisualStyleBackColor = true;
            starsQuestionRadioButton.CheckedChanged += Radio_CheckedChanged;
            // 
            // smileyFacesQuestionRadioButton
            // 
            resources.ApplyResources(smileyFacesQuestionRadioButton, "smileyFacesQuestionRadioButton");
            smileyFacesQuestionRadioButton.Name = "smileyFacesQuestionRadioButton";
            smileyFacesQuestionRadioButton.TabStop = true;
            smileyFacesQuestionRadioButton.UseVisualStyleBackColor = true;
            smileyFacesQuestionRadioButton.CheckedChanged += Radio_CheckedChanged;
            // 
            // sliderQuestionRadioButton
            // 
            resources.ApplyResources(sliderQuestionRadioButton, "sliderQuestionRadioButton");
            sliderQuestionRadioButton.Name = "sliderQuestionRadioButton";
            sliderQuestionRadioButton.TabStop = true;
            sliderQuestionRadioButton.UseVisualStyleBackColor = true;
            sliderQuestionRadioButton.CheckedChanged += Radio_CheckedChanged;
            // 
            // CancelAddButton
            // 
            resources.ApplyResources(CancelAddButton, "CancelAddButton");
            CancelAddButton.Name = "CancelAddButton";
            CancelAddButton.UseVisualStyleBackColor = true;
            CancelAddButton.Click += CancelAddButton_Click;
            // 
            // okAddButton
            // 
            resources.ApplyResources(okAddButton, "okAddButton");
            okAddButton.Name = "okAddButton";
            okAddButton.UseVisualStyleBackColor = true;
            okAddButton.Click += okAddButton_Click;
            // 
            // orderUpDown
            // 
            resources.ApplyResources(orderUpDown, "orderUpDown");
            orderUpDown.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            orderUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            orderUpDown.Name = "orderUpDown";
            orderUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // orderLabel
            // 
            resources.ApplyResources(orderLabel, "orderLabel");
            orderLabel.Name = "orderLabel";
            // 
            // textQuestionTextBox
            // 
            resources.ApplyResources(textQuestionTextBox, "textQuestionTextBox");
            textQuestionTextBox.Name = "textQuestionTextBox";
            // 
            // questionTextLabel
            // 
            resources.ApplyResources(questionTextLabel, "questionTextLabel");
            questionTextLabel.Name = "questionTextLabel";
            // 
            // generalGroupBox
            // 
            generalGroupBox.Controls.Add(orderUpDown);
            generalGroupBox.Controls.Add(textQuestionTextBox);
            generalGroupBox.Controls.Add(typeQuestionGroup);
            generalGroupBox.Controls.Add(questionTextLabel);
            generalGroupBox.Controls.Add(orderLabel);
            resources.ApplyResources(generalGroupBox, "generalGroupBox");
            generalGroupBox.Name = "generalGroupBox";
            generalGroupBox.TabStop = false;
            // 
            // starsPanel
            // 
            starsPanel.Controls.Add(starsCountLabel);
            starsPanel.Controls.Add(starsUpDown);
            resources.ApplyResources(starsPanel, "starsPanel");
            starsPanel.Name = "starsPanel";
            // 
            // starsCountLabel
            // 
            resources.ApplyResources(starsCountLabel, "starsCountLabel");
            starsCountLabel.Name = "starsCountLabel";
            // 
            // starsUpDown
            // 
            resources.ApplyResources(starsUpDown, "starsUpDown");
            starsUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            starsUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            starsUpDown.Name = "starsUpDown";
            starsUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // detailsGroupBox
            // 
            detailsGroupBox.Controls.Add(starsPanel);
            detailsGroupBox.Controls.Add(smileyPanel);
            detailsGroupBox.Controls.Add(sliderPanel);
            resources.ApplyResources(detailsGroupBox, "detailsGroupBox");
            detailsGroupBox.Name = "detailsGroupBox";
            detailsGroupBox.TabStop = false;
            // 
            // smileyPanel
            // 
            smileyPanel.Controls.Add(smileyFacesCountLabel);
            smileyPanel.Controls.Add(smileyFacesUpDown);
            resources.ApplyResources(smileyPanel, "smileyPanel");
            smileyPanel.Name = "smileyPanel";
            // 
            // smileyFacesCountLabel
            // 
            resources.ApplyResources(smileyFacesCountLabel, "smileyFacesCountLabel");
            smileyFacesCountLabel.Name = "smileyFacesCountLabel";
            // 
            // smileyFacesUpDown
            // 
            resources.ApplyResources(smileyFacesUpDown, "smileyFacesUpDown");
            smileyFacesUpDown.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            smileyFacesUpDown.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            smileyFacesUpDown.Name = "smileyFacesUpDown";
            smileyFacesUpDown.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // sliderPanel
            // 
            sliderPanel.Controls.Add(endCaptionTextBox);
            sliderPanel.Controls.Add(startCaptionTextBox);
            sliderPanel.Controls.Add(endValueUpDown);
            sliderPanel.Controls.Add(endCaptionLabel);
            sliderPanel.Controls.Add(startCaptionLabel);
            sliderPanel.Controls.Add(startValueLabel);
            sliderPanel.Controls.Add(endValueLabel);
            sliderPanel.Controls.Add(startValueUpDown);
            resources.ApplyResources(sliderPanel, "sliderPanel");
            sliderPanel.Name = "sliderPanel";
            // 
            // endCaptionTextBox
            // 
            resources.ApplyResources(endCaptionTextBox, "endCaptionTextBox");
            endCaptionTextBox.Name = "endCaptionTextBox";
            // 
            // startCaptionTextBox
            // 
            resources.ApplyResources(startCaptionTextBox, "startCaptionTextBox");
            startCaptionTextBox.Name = "startCaptionTextBox";
            // 
            // endValueUpDown
            // 
            resources.ApplyResources(endValueUpDown, "endValueUpDown");
            endValueUpDown.Name = "endValueUpDown";
            // 
            // endCaptionLabel
            // 
            resources.ApplyResources(endCaptionLabel, "endCaptionLabel");
            endCaptionLabel.Name = "endCaptionLabel";
            // 
            // startCaptionLabel
            // 
            resources.ApplyResources(startCaptionLabel, "startCaptionLabel");
            startCaptionLabel.Name = "startCaptionLabel";
            // 
            // startValueLabel
            // 
            resources.ApplyResources(startValueLabel, "startValueLabel");
            startValueLabel.Name = "startValueLabel";
            // 
            // endValueLabel
            // 
            resources.ApplyResources(endValueLabel, "endValueLabel");
            endValueLabel.Name = "endValueLabel";
            // 
            // startValueUpDown
            // 
            resources.ApplyResources(startValueUpDown, "startValueUpDown");
            startValueUpDown.Name = "startValueUpDown";
            // 
            // AddDialog
            // 
            AcceptButton = okAddButton;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CancelAddButton;
            Controls.Add(detailsGroupBox);
            Controls.Add(generalGroupBox);
            Controls.Add(okAddButton);
            Controls.Add(CancelAddButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "AddDialog";
            typeQuestionGroup.ResumeLayout(false);
            typeQuestionGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)orderUpDown).EndInit();
            generalGroupBox.ResumeLayout(false);
            generalGroupBox.PerformLayout();
            starsPanel.ResumeLayout(false);
            starsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)starsUpDown).EndInit();
            detailsGroupBox.ResumeLayout(false);
            smileyPanel.ResumeLayout(false);
            smileyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)smileyFacesUpDown).EndInit();
            sliderPanel.ResumeLayout(false);
            sliderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)endValueUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)startValueUpDown).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox typeQuestionGroup;
        private RadioButton starsQuestionRadioButton;
        private RadioButton smileyFacesQuestionRadioButton;
        private RadioButton sliderQuestionRadioButton;
        private Button CancelAddButton;
        private Button okAddButton;
        private NumericUpDown orderUpDown;
        private Label orderLabel;
        private TextBox textQuestionTextBox;
        private Label questionTextLabel;
        private GroupBox generalGroupBox;
        private GroupBox detailsGroupBox;
        private Panel sliderPanel;
        private TextBox endCaptionTextBox;
        private TextBox startCaptionTextBox;
        private NumericUpDown endValueUpDown;
        private NumericUpDown startValueUpDown;
        private Label endCaptionLabel;
        private Label startCaptionLabel;
        private Label endValueLabel;
        private Label startValueLabel;
        private Panel starsPanel;
        private Label starsCountLabel;
        private NumericUpDown starsUpDown;
        private Panel smileyPanel;
        private Label smileyFacesCountLabel;
        private NumericUpDown smileyFacesUpDown;
    }
}