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
            QuestionGridView = new DataGridView();
            addButton = new Button();
            editButton = new Button();
            deleteButton = new Button();
            smileyPanel = new Panel();
            smileyCountValue = new Label();
            smileyCountLabel = new Label();
            generalPanel = new Panel();
            questionTypeValue = new Label();
            questionOrderValue = new Label();
            questionTextValue = new Label();
            label18 = new Label();
            label21 = new Label();
            label22 = new Label();
            starsPanel = new Panel();
            starsCountValue = new Label();
            starsCountLabel = new Label();
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
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            databaseConToolStripMenuItem = new ToolStripMenuItem();
            questionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)QuestionGridView).BeginInit();
            smileyPanel.SuspendLayout();
            generalPanel.SuspendLayout();
            starsPanel.SuspendLayout();
            detailsGroupBox.SuspendLayout();
            sliderPanel.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // questionsGroupBox
            // 
            questionsGroupBox.Controls.Add(QuestionGridView);
            questionsGroupBox.Controls.Add(addButton);
            questionsGroupBox.Controls.Add(editButton);
            questionsGroupBox.Controls.Add(deleteButton);
            questionsGroupBox.Location = new Point(12, 39);
            questionsGroupBox.Name = "questionsGroupBox";
            questionsGroupBox.Size = new Size(569, 358);
            questionsGroupBox.TabIndex = 0;
            questionsGroupBox.TabStop = false;
            questionsGroupBox.Text = "Questions ";
            // 
            // QuestionGridView
            // 
            QuestionGridView.AllowUserToDeleteRows = false;
            QuestionGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            QuestionGridView.Location = new Point(6, 22);
            QuestionGridView.MultiSelect = false;
            QuestionGridView.Name = "QuestionGridView";
            QuestionGridView.ReadOnly = true;
            QuestionGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            QuestionGridView.Size = new Size(551, 284);
            QuestionGridView.TabIndex = 3;
            // 
            // addButton
            // 
            addButton.Location = new Point(230, 312);
            addButton.Name = "addButton";
            addButton.Size = new Size(107, 34);
            addButton.TabIndex = 2;
            addButton.Text = "Add...";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // editButton
            // 
            editButton.Location = new Point(343, 312);
            editButton.Name = "editButton";
            editButton.Size = new Size(107, 34);
            editButton.TabIndex = 2;
            editButton.Text = "Edit...";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(456, 312);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(107, 34);
            deleteButton.TabIndex = 1;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // smileyPanel
            // 
            smileyPanel.Controls.Add(smileyCountValue);
            smileyPanel.Controls.Add(smileyCountLabel);
            smileyPanel.Location = new Point(6, 29);
            smileyPanel.Name = "smileyPanel";
            smileyPanel.Size = new Size(551, 132);
            smileyPanel.TabIndex = 2;
            // 
            // smileyCountValue
            // 
            smileyCountValue.AutoSize = true;
            smileyCountValue.Location = new Point(92, 84);
            smileyCountValue.Name = "smileyCountValue";
            smileyCountValue.Size = new Size(0, 15);
            smileyCountValue.TabIndex = 9;
            // 
            // smileyCountLabel
            // 
            smileyCountLabel.AutoSize = true;
            smileyCountLabel.Location = new Point(3, 84);
            smileyCountLabel.Name = "smileyCountLabel";
            smileyCountLabel.Size = new Size(82, 15);
            smileyCountLabel.TabIndex = 8;
            smileyCountLabel.Text = "Smiley count :";
            // 
            // generalPanel
            // 
            generalPanel.Controls.Add(questionTypeValue);
            generalPanel.Controls.Add(questionOrderValue);
            generalPanel.Controls.Add(questionTextValue);
            generalPanel.Controls.Add(label18);
            generalPanel.Controls.Add(label21);
            generalPanel.Controls.Add(label22);
            generalPanel.Location = new Point(6, 29);
            generalPanel.Name = "generalPanel";
            generalPanel.Size = new Size(551, 69);
            generalPanel.TabIndex = 3;
            // 
            // questionTypeValue
            // 
            questionTypeValue.AutoSize = true;
            questionTypeValue.Location = new Point(248, 37);
            questionTypeValue.Name = "questionTypeValue";
            questionTypeValue.Size = new Size(0, 15);
            questionTypeValue.TabIndex = 5;
            // 
            // questionOrderValue
            // 
            questionOrderValue.AutoSize = true;
            questionOrderValue.Location = new Point(92, 37);
            questionOrderValue.Name = "questionOrderValue";
            questionOrderValue.Size = new Size(0, 15);
            questionOrderValue.TabIndex = 4;
            // 
            // questionTextValue
            // 
            questionTextValue.AutoSize = true;
            questionTextValue.Location = new Point(92, 12);
            questionTextValue.Name = "questionTextValue";
            questionTextValue.Size = new Size(0, 15);
            questionTextValue.TabIndex = 3;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(147, 37);
            label18.Name = "label18";
            label18.Size = new Size(89, 15);
            label18.TabIndex = 2;
            label18.Text = "Question Type :";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(3, 37);
            label21.Name = "label21";
            label21.Size = new Size(92, 15);
            label21.TabIndex = 1;
            label21.Text = "Question order :";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(3, 12);
            label22.Name = "label22";
            label22.Size = new Size(83, 15);
            label22.TabIndex = 0;
            label22.Text = "Question text :";
            // 
            // starsPanel
            // 
            starsPanel.Controls.Add(starsCountValue);
            starsPanel.Controls.Add(starsCountLabel);
            starsPanel.Location = new Point(6, 29);
            starsPanel.Name = "starsPanel";
            starsPanel.Size = new Size(551, 132);
            starsPanel.TabIndex = 2;
            // 
            // starsCountValue
            // 
            starsCountValue.AutoSize = true;
            starsCountValue.Location = new Point(92, 76);
            starsCountValue.Name = "starsCountValue";
            starsCountValue.Size = new Size(0, 15);
            starsCountValue.TabIndex = 7;
            // 
            // starsCountLabel
            // 
            starsCountLabel.AutoSize = true;
            starsCountLabel.Location = new Point(3, 76);
            starsCountLabel.Name = "starsCountLabel";
            starsCountLabel.Size = new Size(72, 15);
            starsCountLabel.TabIndex = 6;
            starsCountLabel.Text = "Stars count :";
            // 
            // detailsGroupBox
            // 
            detailsGroupBox.Controls.Add(generalPanel);
            detailsGroupBox.Controls.Add(smileyPanel);
            detailsGroupBox.Controls.Add(sliderPanel);
            detailsGroupBox.Controls.Add(starsPanel);
            detailsGroupBox.Location = new Point(12, 418);
            detailsGroupBox.Name = "detailsGroupBox";
            detailsGroupBox.Size = new Size(563, 167);
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
            sliderPanel.Location = new Point(6, 29);
            sliderPanel.Name = "sliderPanel";
            sliderPanel.Size = new Size(551, 132);
            sliderPanel.TabIndex = 0;
            // 
            // endCaptionValue
            // 
            endCaptionValue.AutoSize = true;
            endCaptionValue.Location = new Point(224, 102);
            endCaptionValue.Name = "endCaptionValue";
            endCaptionValue.Size = new Size(0, 15);
            endCaptionValue.TabIndex = 13;
            // 
            // startCaptionValue
            // 
            startCaptionValue.AutoSize = true;
            startCaptionValue.Location = new Point(224, 72);
            startCaptionValue.Name = "startCaptionValue";
            startCaptionValue.Size = new Size(0, 15);
            startCaptionValue.TabIndex = 12;
            // 
            // endCaptionLabel
            // 
            endCaptionLabel.AutoSize = true;
            endCaptionLabel.Location = new Point(147, 102);
            endCaptionLabel.Name = "endCaptionLabel";
            endCaptionLabel.Size = new Size(78, 15);
            endCaptionLabel.TabIndex = 11;
            endCaptionLabel.Text = "End Caption :";
            // 
            // startCaptionLabel
            // 
            startCaptionLabel.AutoSize = true;
            startCaptionLabel.Location = new Point(147, 72);
            startCaptionLabel.Name = "startCaptionLabel";
            startCaptionLabel.Size = new Size(80, 15);
            startCaptionLabel.TabIndex = 10;
            startCaptionLabel.Text = "Start caption :";
            // 
            // endValueValue
            // 
            endValueValue.AutoSize = true;
            endValueValue.Location = new Point(84, 102);
            endValueValue.Name = "endValueValue";
            endValueValue.Size = new Size(0, 15);
            endValueValue.TabIndex = 9;
            // 
            // startValueValue
            // 
            startValueValue.AutoSize = true;
            startValueValue.Location = new Point(84, 72);
            startValueValue.Name = "startValueValue";
            startValueValue.Size = new Size(0, 15);
            startValueValue.TabIndex = 8;
            // 
            // endValueLabel
            // 
            endValueLabel.AutoSize = true;
            endValueLabel.Location = new Point(10, 102);
            endValueLabel.Name = "endValueLabel";
            endValueLabel.Size = new Size(64, 15);
            endValueLabel.TabIndex = 7;
            endValueLabel.Text = "End value :";
            // 
            // startValueLabel
            // 
            startValueLabel.AutoSize = true;
            startValueLabel.Location = new Point(10, 72);
            startValueLabel.Name = "startValueLabel";
            startValueLabel.Size = new Size(68, 15);
            startValueLabel.TabIndex = 6;
            startValueLabel.Text = "Start value :";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(584, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { databaseConToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "&Settings";
            // 
            // databaseConToolStripMenuItem
            // 
            databaseConToolStripMenuItem.Name = "databaseConToolStripMenuItem";
            databaseConToolStripMenuItem.Size = new Size(196, 22);
            databaseConToolStripMenuItem.Text = "&Database Connection…";
            databaseConToolStripMenuItem.Click += databaseConToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(584, 661);
            Controls.Add(detailsGroupBox);
            Controls.Add(questionsGroupBox);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            questionsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)QuestionGridView).EndInit();
            smileyPanel.ResumeLayout(false);
            smileyPanel.PerformLayout();
            generalPanel.ResumeLayout(false);
            generalPanel.PerformLayout();
            starsPanel.ResumeLayout(false);
            starsPanel.PerformLayout();
            detailsGroupBox.ResumeLayout(false);
            sliderPanel.ResumeLayout(false);
            sliderPanel.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox questionsGroupBox;
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
        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem databaseConToolStripMenuItem;
        private DataGridView QuestionGridView;
    }
}