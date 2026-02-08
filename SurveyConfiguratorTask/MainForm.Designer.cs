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
            Text = new DataGridViewTextBoxColumn();
            Order = new DataGridViewTextBoxColumn();
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
            starsPanel = new Panel();
            starsCountValue = new Label();
            starsCountLabel = new Label();
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
            label1 = new Label();
            startValueLabel = new Label();
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            databaseConToolStripMenuItem = new ToolStripMenuItem();
            questionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)QuestionGridView).BeginInit();
            generalPanel.SuspendLayout();
            detailsGroupBox.SuspendLayout();
            starsPanel.SuspendLayout();
            smileyPanel.SuspendLayout();
            sliderPanel.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // questionsGroupBox
            // 
            questionsGroupBox.Controls.Add(QuestionGridView);
            questionsGroupBox.Location = new Point(12, 34);
            questionsGroupBox.Margin = new Padding(3, 4, 3, 4);
            questionsGroupBox.Name = "questionsGroupBox";
            questionsGroupBox.Padding = new Padding(3, 4, 3, 4);
            questionsGroupBox.Size = new Size(650, 418);
            questionsGroupBox.TabIndex = 0;
            questionsGroupBox.TabStop = false;
            questionsGroupBox.Text = "Questions ";
            // 
            // QuestionGridView
            // 
            QuestionGridView.AllowUserToDeleteRows = false;
            QuestionGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            QuestionGridView.Columns.AddRange(new DataGridViewColumn[] { Text, Order });
            QuestionGridView.Location = new Point(7, 29);
            QuestionGridView.Margin = new Padding(3, 4, 3, 4);
            QuestionGridView.MultiSelect = false;
            QuestionGridView.Name = "QuestionGridView";
            QuestionGridView.ReadOnly = true;
            QuestionGridView.RowHeadersVisible = false;
            QuestionGridView.RowHeadersWidth = 51;
            QuestionGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            QuestionGridView.Size = new Size(630, 379);
            QuestionGridView.TabIndex = 3;
            // 
            // Text
            // 
            Text.HeaderText = "Text";
            Text.MinimumWidth = 6;
            Text.Name = "Text";
            Text.ReadOnly = true;
            Text.Width = 125;
            // 
            // Order
            // 
            Order.HeaderText = "Order";
            Order.MinimumWidth = 6;
            Order.Name = "Order";
            Order.ReadOnly = true;
            Order.Width = 125;
            // 
            // addButton
            // 
            addButton.Location = new Point(387, 706);
            addButton.Margin = new Padding(3, 4, 3, 4);
            addButton.Name = "addButton";
            addButton.Size = new Size(86, 31);
            addButton.TabIndex = 2;
            addButton.Text = "Add...";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // editButton
            // 
            editButton.Location = new Point(479, 706);
            editButton.Margin = new Padding(3, 4, 3, 4);
            editButton.Name = "editButton";
            editButton.Size = new Size(86, 31);
            editButton.TabIndex = 2;
            editButton.Text = "Edit...";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(571, 706);
            deleteButton.Margin = new Padding(3, 4, 3, 4);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(86, 31);
            deleteButton.TabIndex = 1;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // generalPanel
            // 
            generalPanel.Controls.Add(questionTypeValue);
            generalPanel.Controls.Add(questionOrderValue);
            generalPanel.Controls.Add(questionTextValue);
            generalPanel.Controls.Add(label18);
            generalPanel.Controls.Add(label21);
            generalPanel.Controls.Add(label22);
            generalPanel.Location = new Point(6, 28);
            generalPanel.Margin = new Padding(3, 4, 3, 4);
            generalPanel.Name = "generalPanel";
            generalPanel.Size = new Size(630, 92);
            generalPanel.TabIndex = 3;
            // 
            // questionTypeValue
            // 
            questionTypeValue.AutoSize = true;
            questionTypeValue.Location = new Point(283, 49);
            questionTypeValue.Name = "questionTypeValue";
            questionTypeValue.Size = new Size(0, 20);
            questionTypeValue.TabIndex = 5;
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
            // detailsGroupBox
            // 
            detailsGroupBox.Controls.Add(starsPanel);
            detailsGroupBox.Controls.Add(smileyPanel);
            detailsGroupBox.Controls.Add(generalPanel);
            detailsGroupBox.Controls.Add(sliderPanel);
            detailsGroupBox.Location = new Point(12, 460);
            detailsGroupBox.Margin = new Padding(3, 4, 3, 4);
            detailsGroupBox.Name = "detailsGroupBox";
            detailsGroupBox.Padding = new Padding(3, 4, 3, 4);
            detailsGroupBox.Size = new Size(643, 223);
            detailsGroupBox.TabIndex = 1;
            detailsGroupBox.TabStop = false;
            detailsGroupBox.Text = "Question Details";
            // 
            // starsPanel
            // 
            starsPanel.Controls.Add(starsCountValue);
            starsPanel.Controls.Add(starsCountLabel);
            starsPanel.Location = new Point(6, 130);
            starsPanel.Name = "starsPanel";
            starsPanel.Size = new Size(630, 76);
            starsPanel.TabIndex = 5;
            // 
            // starsCountValue
            // 
            starsCountValue.AutoSize = true;
            starsCountValue.Location = new Point(110, 22);
            starsCountValue.Name = "starsCountValue";
            starsCountValue.Size = new Size(0, 20);
            starsCountValue.TabIndex = 1;
            // 
            // starsCountLabel
            // 
            starsCountLabel.AutoSize = true;
            starsCountLabel.Location = new Point(2, 22);
            starsCountLabel.Name = "starsCountLabel";
            starsCountLabel.Size = new Size(89, 20);
            starsCountLabel.TabIndex = 0;
            starsCountLabel.Text = "Stars count :";
            // 
            // smileyPanel
            // 
            smileyPanel.Controls.Add(smileyCountValue);
            smileyPanel.Controls.Add(smileyCountLabel);
            smileyPanel.Location = new Point(6, 127);
            smileyPanel.Name = "smileyPanel";
            smileyPanel.Size = new Size(630, 76);
            smileyPanel.TabIndex = 4;
            // 
            // smileyCountValue
            // 
            smileyCountValue.AutoSize = true;
            smileyCountValue.Location = new Point(109, 22);
            smileyCountValue.Name = "smileyCountValue";
            smileyCountValue.Size = new Size(0, 20);
            smileyCountValue.TabIndex = 1;
            // 
            // smileyCountLabel
            // 
            smileyCountLabel.AutoSize = true;
            smileyCountLabel.Location = new Point(2, 22);
            smileyCountLabel.Name = "smileyCountLabel";
            smileyCountLabel.Size = new Size(101, 20);
            smileyCountLabel.TabIndex = 0;
            smileyCountLabel.Text = "Smiley count :";
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
            sliderPanel.Controls.Add(label1);
            sliderPanel.Controls.Add(startValueLabel);
            sliderPanel.Location = new Point(6, 130);
            sliderPanel.Name = "sliderPanel";
            sliderPanel.Size = new Size(630, 79);
            sliderPanel.TabIndex = 6;
            // 
            // endCaptionValue
            // 
            endCaptionValue.AutoSize = true;
            endCaptionValue.Location = new Point(270, 46);
            endCaptionValue.Name = "endCaptionValue";
            endCaptionValue.Size = new Size(0, 20);
            endCaptionValue.TabIndex = 8;
            // 
            // startCaptionValue
            // 
            startCaptionValue.AutoSize = true;
            startCaptionValue.Location = new Point(270, 13);
            startCaptionValue.Name = "startCaptionValue";
            startCaptionValue.Size = new Size(0, 20);
            startCaptionValue.TabIndex = 7;
            // 
            // endCaptionLabel
            // 
            endCaptionLabel.AutoSize = true;
            endCaptionLabel.Location = new Point(168, 46);
            endCaptionLabel.Name = "endCaptionLabel";
            endCaptionLabel.Size = new Size(95, 20);
            endCaptionLabel.TabIndex = 6;
            endCaptionLabel.Text = "End caption :";
            // 
            // startCaptionLabel
            // 
            startCaptionLabel.AutoSize = true;
            startCaptionLabel.Location = new Point(168, 13);
            startCaptionLabel.Name = "startCaptionLabel";
            startCaptionLabel.Size = new Size(101, 20);
            startCaptionLabel.TabIndex = 5;
            startCaptionLabel.Text = "Start caption :";
            // 
            // endValueValue
            // 
            endValueValue.AutoSize = true;
            endValueValue.Location = new Point(94, 46);
            endValueValue.Name = "endValueValue";
            endValueValue.Size = new Size(0, 20);
            endValueValue.TabIndex = 4;
            // 
            // startValueValue
            // 
            startValueValue.AutoSize = true;
            startValueValue.Location = new Point(94, 13);
            startValueValue.Name = "startValueValue";
            startValueValue.Size = new Size(0, 20);
            startValueValue.TabIndex = 3;
            // 
            // endValueLabel
            // 
            endValueLabel.AutoSize = true;
            endValueLabel.Location = new Point(3, 46);
            endValueLabel.Name = "endValueLabel";
            endValueLabel.Size = new Size(80, 20);
            endValueLabel.TabIndex = 2;
            endValueLabel.Text = "End value :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(110, 22);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 1;
            // 
            // startValueLabel
            // 
            startValueLabel.AutoSize = true;
            startValueLabel.Location = new Point(2, 13);
            startValueLabel.Name = "startValueLabel";
            startValueLabel.Size = new Size(86, 20);
            startValueLabel.TabIndex = 0;
            startValueLabel.Text = "Start value :";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(667, 30);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { databaseConToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(76, 24);
            settingsToolStripMenuItem.Text = "&Settings";
            // 
            // databaseConToolStripMenuItem
            // 
            databaseConToolStripMenuItem.Name = "databaseConToolStripMenuItem";
            databaseConToolStripMenuItem.Size = new Size(245, 26);
            databaseConToolStripMenuItem.Text = "&Database Connection…";
            databaseConToolStripMenuItem.Click += databaseConToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(667, 761);
            Controls.Add(detailsGroupBox);
            Controls.Add(deleteButton);
            Controls.Add(editButton);
            Controls.Add(addButton);
            Controls.Add(questionsGroupBox);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            questionsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)QuestionGridView).EndInit();
            generalPanel.ResumeLayout(false);
            generalPanel.PerformLayout();
            detailsGroupBox.ResumeLayout(false);
            starsPanel.ResumeLayout(false);
            starsPanel.PerformLayout();
            smileyPanel.ResumeLayout(false);
            smileyPanel.PerformLayout();
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
        private DataGridViewTextBoxColumn Text;
        private DataGridViewTextBoxColumn Order;
        private Panel smileyPanel;
        private Label smileyCountLabel;
        private Panel starsPanel;
        private Label starsCountLabel;
        private Label smileyCountValue;
        private Label starsCountValue;
        private Panel sliderPanel;
        private Label endValueLabel;
        private Label label1;
        private Label startValueLabel;
        private Label endCaptionValue;
        private Label startCaptionValue;
        private Label endCaptionLabel;
        private Label startCaptionLabel;
        private Label endValueValue;
        private Label startValueValue;
    }
}