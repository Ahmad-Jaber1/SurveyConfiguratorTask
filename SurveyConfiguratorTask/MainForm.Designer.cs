namespace SurveyConfiguratorTask
{
    partial class MainForm
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
            questionsGroupBox = new GroupBox();
            addButton = new Button();
            editButton = new Button();
            deleteButton = new Button();
            QuestionList = new ListBox();
            smileyPanel = new Panel();
            generalPanel = new Panel();
            questionTypeValue = new Label();
            starsPanel = new Panel();
            starsCountValue = new Label();
            starsCountLabel = new Label();
            questionOrderValue = new Label();
            questionTextValue = new Label();
            label18 = new Label();
            label21 = new Label();
            label22 = new Label();
            smileyCountValue = new Label();
            smileyCountLabel = new Label();
            detailsGroupBox = new GroupBox();
            sliderPanel = new Panel();
            endCaptionValue = new Label();
            startCaptionValue = new Label();
            endCaptionLabel = new Label();
            startCaptionLabel = new Label();
            endValueValue = new Label();
            startValueValue = new Label();
            endValueLabel = new Label();
            startValueLabel = new Label();
            questionsGroupBox.SuspendLayout();
            smileyPanel.SuspendLayout();
            generalPanel.SuspendLayout();
            starsPanel.SuspendLayout();
            detailsGroupBox.SuspendLayout();
            sliderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // questionsGroupBox
            // 
            questionsGroupBox.Controls.Add(addButton);
            questionsGroupBox.Controls.Add(editButton);
            questionsGroupBox.Controls.Add(deleteButton);
            questionsGroupBox.Controls.Add(QuestionList);
            questionsGroupBox.Location = new Point(14, 16);
            questionsGroupBox.Margin = new Padding(3, 4, 3, 4);
            questionsGroupBox.Name = "questionsGroupBox";
            questionsGroupBox.Padding = new Padding(3, 4, 3, 4);
            questionsGroupBox.Size = new Size(650, 477);
            questionsGroupBox.TabIndex = 0;
            questionsGroupBox.TabStop = false;
            questionsGroupBox.Text = "Questions ";
            // 
            // addButton
            // 
            addButton.Location = new Point(263, 416);
            addButton.Margin = new Padding(3, 4, 3, 4);
            addButton.Name = "addButton";
            addButton.Size = new Size(122, 45);
            addButton.TabIndex = 2;
            addButton.Text = "Add...";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // editButton
            // 
            editButton.Location = new Point(392, 416);
            editButton.Margin = new Padding(3, 4, 3, 4);
            editButton.Name = "editButton";
            editButton.Size = new Size(122, 45);
            editButton.TabIndex = 2;
            editButton.Text = "Edit...";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(521, 416);
            deleteButton.Margin = new Padding(3, 4, 3, 4);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(122, 45);
            deleteButton.TabIndex = 1;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // QuestionList
            // 
            QuestionList.FormattingEnabled = true;
            QuestionList.Location = new Point(7, 43);
            QuestionList.Margin = new Padding(3, 4, 3, 4);
            QuestionList.Name = "QuestionList";
            QuestionList.Size = new Size(636, 364);
            QuestionList.TabIndex = 0;
            QuestionList.SelectedIndexChanged += QuestionList_SelectedIndexChanged;
            // 
            // smileyPanel
            // 
            smileyPanel.Controls.Add(smileyCountValue);
            smileyPanel.Controls.Add(smileyCountLabel);
            smileyPanel.Location = new Point(7, 39);
            smileyPanel.Margin = new Padding(3, 4, 3, 4);
            smileyPanel.Name = "smileyPanel";
            smileyPanel.Size = new Size(630, 176);
            smileyPanel.TabIndex = 2;
            // 
            // generalPanel
            // 
            generalPanel.Controls.Add(questionTypeValue);
            generalPanel.Controls.Add(questionOrderValue);
            generalPanel.Controls.Add(questionTextValue);
            generalPanel.Controls.Add(label18);
            generalPanel.Controls.Add(label21);
            generalPanel.Controls.Add(label22);
            generalPanel.Location = new Point(7, 39);
            generalPanel.Margin = new Padding(3, 4, 3, 4);
            generalPanel.Name = "generalPanel";
            generalPanel.Size = new Size(630, 92);
            generalPanel.TabIndex = 3;
            // 
            // questionTypeValue
            // 
            questionTypeValue.AutoSize = true;
            questionTypeValue.Location = new Point(284, 49);
            questionTypeValue.Name = "questionTypeValue";
            questionTypeValue.Size = new Size(0, 20);
            questionTypeValue.TabIndex = 5;
            // 
            // starsPanel
            // 
            starsPanel.Controls.Add(starsCountValue);
            starsPanel.Controls.Add(starsCountLabel);
            starsPanel.Location = new Point(7, 39);
            starsPanel.Margin = new Padding(3, 4, 3, 4);
            starsPanel.Name = "starsPanel";
            starsPanel.Size = new Size(630, 176);
            starsPanel.TabIndex = 2;
            // 
            // starsCountValue
            // 
            starsCountValue.AutoSize = true;
            starsCountValue.Location = new Point(105, 101);
            starsCountValue.Name = "starsCountValue";
            starsCountValue.Size = new Size(0, 20);
            starsCountValue.TabIndex = 7;
            // 
            // starsCountLabel
            // 
            starsCountLabel.AutoSize = true;
            starsCountLabel.Location = new Point(3, 101);
            starsCountLabel.Name = "starsCountLabel";
            starsCountLabel.Size = new Size(89, 20);
            starsCountLabel.TabIndex = 6;
            starsCountLabel.Text = "Stars count :";
            // 
            // questionOrderValue
            // 
            questionOrderValue.AutoSize = true;
            questionOrderValue.Location = new Point(105, 49);
            questionOrderValue.Name = "questionOrderValue";
            questionOrderValue.Size = new Size(0, 20);
            questionOrderValue.TabIndex = 4;
            // 
            // questionTextValue
            // 
            questionTextValue.AutoSize = true;
            questionTextValue.Location = new Point(105, 16);
            questionTextValue.Name = "questionTextValue";
            questionTextValue.Size = new Size(0, 20);
            questionTextValue.TabIndex = 3;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(168, 49);
            label18.Name = "label18";
            label18.Size = new Size(110, 20);
            label18.TabIndex = 2;
            label18.Text = "Question Type :";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(3, 49);
            label21.Name = "label21";
            label21.Size = new Size(115, 20);
            label21.TabIndex = 1;
            label21.Text = "Question order :";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(3, 16);
            label22.Name = "label22";
            label22.Size = new Size(104, 20);
            label22.TabIndex = 0;
            label22.Text = "Question text :";
            // 
            // smileyCountValue
            // 
            smileyCountValue.AutoSize = true;
            smileyCountValue.Location = new Point(105, 112);
            smileyCountValue.Name = "smileyCountValue";
            smileyCountValue.Size = new Size(0, 20);
            smileyCountValue.TabIndex = 9;
            // 
            // smileyCountLabel
            // 
            smileyCountLabel.AutoSize = true;
            smileyCountLabel.Location = new Point(3, 112);
            smileyCountLabel.Name = "smileyCountLabel";
            smileyCountLabel.Size = new Size(101, 20);
            smileyCountLabel.TabIndex = 8;
            smileyCountLabel.Text = "Smiley count :";
            // 
            // detailsGroupBox
            // 
            detailsGroupBox.Controls.Add(generalPanel);
            detailsGroupBox.Controls.Add(smileyPanel);
            detailsGroupBox.Controls.Add(sliderPanel);
            detailsGroupBox.Controls.Add(starsPanel);
            detailsGroupBox.Location = new Point(14, 557);
            detailsGroupBox.Margin = new Padding(3, 4, 3, 4);
            detailsGroupBox.Name = "detailsGroupBox";
            detailsGroupBox.Padding = new Padding(3, 4, 3, 4);
            detailsGroupBox.Size = new Size(643, 223);
            detailsGroupBox.TabIndex = 1;
            detailsGroupBox.TabStop = false;
            detailsGroupBox.Text = "Details of the selected question";
            // 
            // sliderPanel
            // 
            sliderPanel.Controls.Add(endCaptionValue);
            sliderPanel.Controls.Add(startCaptionValue);
            sliderPanel.Controls.Add(endCaptionLabel);
            sliderPanel.Controls.Add(startCaptionLabel);
            sliderPanel.Controls.Add(endValueValue);
            sliderPanel.Controls.Add(startValueValue);
            sliderPanel.Controls.Add(endValueLabel);
            sliderPanel.Controls.Add(startValueLabel);
            sliderPanel.Location = new Point(7, 39);
            sliderPanel.Margin = new Padding(3, 4, 3, 4);
            sliderPanel.Name = "sliderPanel";
            sliderPanel.Size = new Size(630, 176);
            sliderPanel.TabIndex = 0;
            // 
            // endCaptionValue
            // 
            endCaptionValue.AutoSize = true;
            endCaptionValue.Location = new Point(256, 136);
            endCaptionValue.Name = "endCaptionValue";
            endCaptionValue.Size = new Size(0, 20);
            endCaptionValue.TabIndex = 13;
            // 
            // startCaptionValue
            // 
            startCaptionValue.AutoSize = true;
            startCaptionValue.Location = new Point(256, 96);
            startCaptionValue.Name = "startCaptionValue";
            startCaptionValue.Size = new Size(0, 20);
            startCaptionValue.TabIndex = 12;
            // 
            // endCaptionLabel
            // 
            endCaptionLabel.AutoSize = true;
            endCaptionLabel.Location = new Point(168, 136);
            endCaptionLabel.Name = "endCaptionLabel";
            endCaptionLabel.Size = new Size(97, 20);
            endCaptionLabel.TabIndex = 11;
            endCaptionLabel.Text = "End Caption :";
            // 
            // startCaptionLabel
            // 
            startCaptionLabel.AutoSize = true;
            startCaptionLabel.Location = new Point(168, 96);
            startCaptionLabel.Name = "startCaptionLabel";
            startCaptionLabel.Size = new Size(101, 20);
            startCaptionLabel.TabIndex = 10;
            startCaptionLabel.Text = "Start caption :";
            // 
            // endValueValue
            // 
            endValueValue.AutoSize = true;
            endValueValue.Location = new Point(96, 136);
            endValueValue.Name = "endValueValue";
            endValueValue.Size = new Size(0, 20);
            endValueValue.TabIndex = 9;
            // 
            // startValueValue
            // 
            startValueValue.AutoSize = true;
            startValueValue.Location = new Point(96, 96);
            startValueValue.Name = "startValueValue";
            startValueValue.Size = new Size(0, 20);
            startValueValue.TabIndex = 8;
            // 
            // endValueLabel
            // 
            endValueLabel.AutoSize = true;
            endValueLabel.Location = new Point(11, 136);
            endValueLabel.Name = "endValueLabel";
            endValueLabel.Size = new Size(80, 20);
            endValueLabel.TabIndex = 7;
            endValueLabel.Text = "End value :";
            // 
            // startValueLabel
            // 
            startValueLabel.AutoSize = true;
            startValueLabel.Location = new Point(11, 96);
            startValueLabel.Name = "startValueLabel";
            startValueLabel.Size = new Size(86, 20);
            startValueLabel.TabIndex = 6;
            startValueLabel.Text = "Start value :";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(667, 881);
            Controls.Add(detailsGroupBox);
            Controls.Add(questionsGroupBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            questionsGroupBox.ResumeLayout(false);
            smileyPanel.ResumeLayout(false);
            smileyPanel.PerformLayout();
            generalPanel.ResumeLayout(false);
            generalPanel.PerformLayout();
            starsPanel.ResumeLayout(false);
            starsPanel.PerformLayout();
            detailsGroupBox.ResumeLayout(false);
            sliderPanel.ResumeLayout(false);
            sliderPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox questionsGroupBox;
        private ListBox QuestionList;
        private Button addButton;
        private Button editButton;
        private Button deleteButton;
        private GroupBox detailsGroupBox;
        private Panel starsPanel;
        private Panel smileyPanel;
        private Label starsCountLabel;
        private Label starsCountValue;
        private Panel generalPanel;
        private Label questionTypeValue;
        private Label questionOrderValue;
        private Label questionTextValue;
        private Label label18;
        private Label label21;
        private Label label22;
        private Label smileyCountValue;
        private Label smileyCountLabel;
        private Panel sliderPanel;
        private Label endCaptionValue;
        private Label startCaptionValue;
        private Label endCaptionLabel;
        private Label startCaptionLabel;
        private Label endValueValue;
        private Label startValueValue;
        private Label endValueLabel;
        private Label startValueLabel;
    }
}