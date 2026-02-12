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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            questionsGroupBox = new GroupBox();
            QuestionGridView = new DataGridView();
            smileyPanel = new Panel();
            smileyCountValue = new Label();
            smileyCountLabel = new Label();
            sliderPanel = new Panel();
            endCaptionValue = new Label();
            startCaptionValue = new Label();
            endCaptionLabel = new Label();
            startCaptionLabel = new Label();
            endValueValue = new Label();
            startValueValue = new Label();
            endValueLabel = new Label();
            startValueLabel = new Label();
            starsPanel = new Panel();
            starsCountValue = new Label();
            starsCountLabel = new Label();
            addButton = new Button();
            editButton = new Button();
            deleteButton = new Button();
            generalPanel = new Panel();
            questionTypeValue = new Label();
            questionOrderValue = new Label();
            questionTextValue = new Label();
            label18 = new Label();
            label21 = new Label();
            label22 = new Label();
            detailsGroupBox = new GroupBox();
            panel1 = new Panel();
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            databaseConToolStripMenuItem = new ToolStripMenuItem();
            languageStripMenuItem = new ToolStripMenuItem();
            englishToolStripMenuItem = new ToolStripMenuItem();
            arabicToolStripMenuItem = new ToolStripMenuItem();
            questionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)QuestionGridView).BeginInit();
            smileyPanel.SuspendLayout();
            sliderPanel.SuspendLayout();
            starsPanel.SuspendLayout();
            generalPanel.SuspendLayout();
            detailsGroupBox.SuspendLayout();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // questionsGroupBox
            // 
            resources.ApplyResources(questionsGroupBox, "questionsGroupBox");
            questionsGroupBox.Controls.Add(QuestionGridView);
            questionsGroupBox.Name = "questionsGroupBox";
            questionsGroupBox.TabStop = false;
            // 
            // QuestionGridView
            // 
            resources.ApplyResources(QuestionGridView, "QuestionGridView");
            QuestionGridView.AllowUserToDeleteRows = false;
            QuestionGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            QuestionGridView.MultiSelect = false;
            QuestionGridView.Name = "QuestionGridView";
            QuestionGridView.ReadOnly = true;
            QuestionGridView.RowHeadersVisible = false;
            QuestionGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // smileyPanel
            // 
            resources.ApplyResources(smileyPanel, "smileyPanel");
            smileyPanel.Controls.Add(smileyCountValue);
            smileyPanel.Controls.Add(smileyCountLabel);
            smileyPanel.Name = "smileyPanel";
            // 
            // smileyCountValue
            // 
            resources.ApplyResources(smileyCountValue, "smileyCountValue");
            smileyCountValue.Name = "smileyCountValue";
            // 
            // smileyCountLabel
            // 
            resources.ApplyResources(smileyCountLabel, "smileyCountLabel");
            smileyCountLabel.Name = "smileyCountLabel";
            // 
            // sliderPanel
            // 
            resources.ApplyResources(sliderPanel, "sliderPanel");
            sliderPanel.Controls.Add(endCaptionValue);
            sliderPanel.Controls.Add(startCaptionValue);
            sliderPanel.Controls.Add(endCaptionLabel);
            sliderPanel.Controls.Add(startCaptionLabel);
            sliderPanel.Controls.Add(endValueValue);
            sliderPanel.Controls.Add(startValueValue);
            sliderPanel.Controls.Add(endValueLabel);
            sliderPanel.Controls.Add(startValueLabel);
            sliderPanel.Name = "sliderPanel";
            // 
            // endCaptionValue
            // 
            resources.ApplyResources(endCaptionValue, "endCaptionValue");
            endCaptionValue.Name = "endCaptionValue";
            // 
            // startCaptionValue
            // 
            resources.ApplyResources(startCaptionValue, "startCaptionValue");
            startCaptionValue.Name = "startCaptionValue";
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
            // endValueValue
            // 
            resources.ApplyResources(endValueValue, "endValueValue");
            endValueValue.Name = "endValueValue";
            // 
            // startValueValue
            // 
            resources.ApplyResources(startValueValue, "startValueValue");
            startValueValue.Name = "startValueValue";
            // 
            // endValueLabel
            // 
            resources.ApplyResources(endValueLabel, "endValueLabel");
            endValueLabel.Name = "endValueLabel";
            // 
            // startValueLabel
            // 
            resources.ApplyResources(startValueLabel, "startValueLabel");
            startValueLabel.Name = "startValueLabel";
            // 
            // starsPanel
            // 
            resources.ApplyResources(starsPanel, "starsPanel");
            starsPanel.Controls.Add(starsCountValue);
            starsPanel.Controls.Add(starsCountLabel);
            starsPanel.Name = "starsPanel";
            // 
            // starsCountValue
            // 
            resources.ApplyResources(starsCountValue, "starsCountValue");
            starsCountValue.Name = "starsCountValue";
            // 
            // starsCountLabel
            // 
            resources.ApplyResources(starsCountLabel, "starsCountLabel");
            starsCountLabel.Name = "starsCountLabel";
            // 
            // addButton
            // 
            resources.ApplyResources(addButton, "addButton");
            addButton.Name = "addButton";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // editButton
            // 
            resources.ApplyResources(editButton, "editButton");
            editButton.Name = "editButton";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // deleteButton
            // 
            resources.ApplyResources(deleteButton, "deleteButton");
            deleteButton.Name = "deleteButton";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // generalPanel
            // 
            resources.ApplyResources(generalPanel, "generalPanel");
            generalPanel.Controls.Add(questionTypeValue);
            generalPanel.Controls.Add(questionOrderValue);
            generalPanel.Controls.Add(questionTextValue);
            generalPanel.Controls.Add(label18);
            generalPanel.Controls.Add(label21);
            generalPanel.Controls.Add(label22);
            generalPanel.Name = "generalPanel";
            // 
            // questionTypeValue
            // 
            resources.ApplyResources(questionTypeValue, "questionTypeValue");
            questionTypeValue.Name = "questionTypeValue";
            // 
            // questionOrderValue
            // 
            resources.ApplyResources(questionOrderValue, "questionOrderValue");
            questionOrderValue.Name = "questionOrderValue";
            // 
            // questionTextValue
            // 
            resources.ApplyResources(questionTextValue, "questionTextValue");
            questionTextValue.Name = "questionTextValue";
            // 
            // label18
            // 
            resources.ApplyResources(label18, "label18");
            label18.Name = "label18";
            // 
            // label21
            // 
            resources.ApplyResources(label21, "label21");
            label21.Name = "label21";
            // 
            // label22
            // 
            resources.ApplyResources(label22, "label22");
            label22.Name = "label22";
            // 
            // detailsGroupBox
            // 
            resources.ApplyResources(detailsGroupBox, "detailsGroupBox");
            detailsGroupBox.Controls.Add(panel1);
            detailsGroupBox.Controls.Add(generalPanel);
            detailsGroupBox.Name = "detailsGroupBox";
            detailsGroupBox.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.Controls.Add(smileyPanel);
            panel1.Controls.Add(starsPanel);
            panel1.Controls.Add(sliderPanel);
            panel1.Name = "panel1";
            // 
            // menuStrip1
            // 
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, languageStripMenuItem });
            menuStrip1.Name = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            resources.ApplyResources(settingsToolStripMenuItem, "settingsToolStripMenuItem");
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { databaseConToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            // 
            // databaseConToolStripMenuItem
            // 
            resources.ApplyResources(databaseConToolStripMenuItem, "databaseConToolStripMenuItem");
            databaseConToolStripMenuItem.Name = "databaseConToolStripMenuItem";
            databaseConToolStripMenuItem.Click += databaseConToolStripMenuItem_Click;
            // 
            // languageStripMenuItem
            // 
            resources.ApplyResources(languageStripMenuItem, "languageStripMenuItem");
            languageStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { englishToolStripMenuItem, arabicToolStripMenuItem });
            languageStripMenuItem.Name = "languageStripMenuItem";
            // 
            // englishToolStripMenuItem
            // 
            resources.ApplyResources(englishToolStripMenuItem, "englishToolStripMenuItem");
            englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            englishToolStripMenuItem.Click += englishToolStripMenuItem_Click;
            // 
            // arabicToolStripMenuItem
            // 
            resources.ApplyResources(arabicToolStripMenuItem, "arabicToolStripMenuItem");
            arabicToolStripMenuItem.Name = "arabicToolStripMenuItem";
            arabicToolStripMenuItem.Click += arabicToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(detailsGroupBox);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(addButton);
            Controls.Add(questionsGroupBox);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MainForm";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            questionsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)QuestionGridView).EndInit();
            smileyPanel.ResumeLayout(false);
            smileyPanel.PerformLayout();
            sliderPanel.ResumeLayout(false);
            sliderPanel.PerformLayout();
            starsPanel.ResumeLayout(false);
            starsPanel.PerformLayout();
            generalPanel.ResumeLayout(false);
            generalPanel.PerformLayout();
            detailsGroupBox.ResumeLayout(false);
            panel1.ResumeLayout(false);
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
        private Panel generalPanel;
        private Label questionTypeValue;
        private Label questionOrderValue;
        private Label questionTextValue;
        private Label label18;
        private Label label21;
        private Label label22;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem databaseConToolStripMenuItem;
        private DataGridView QuestionGridView;
        private Panel smileyPanel;
        private Label smileyCountLabel;
        private Panel starsPanel;
        private Label starsCountLabel;
        private Label smileyCountValue;
        private Label starsCountValue;
        private ToolStripMenuItem languageStripMenuItem;
        private ToolStripMenuItem englishToolStripMenuItem;
        private ToolStripMenuItem arabicToolStripMenuItem;
        private Panel sliderPanel;
        private Label endCaptionValue;
        private Label startCaptionValue;
        private Label endCaptionLabel;
        private Label startCaptionLabel;
        private Label endValueValue;
        private Label startValueValue;
        private Label endValueLabel;
        private Label startValueLabel;
        private Panel panel1;
    }
}