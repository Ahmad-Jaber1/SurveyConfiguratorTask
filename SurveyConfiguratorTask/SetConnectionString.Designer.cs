namespace SurveyConfiguratorTask
{
    partial class setConnectionString
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(setConnectionString));
            groupBox1 = new GroupBox();
            loginPanel = new Panel();
            passwordTextBox = new TextBox();
            passwordLabel = new Label();
            userTextBox = new TextBox();
            userLabel = new Label();
            authLabel = new Label();
            authComboBox = new ComboBox();
            databaseTextBox = new TextBox();
            databaseLabel = new Label();
            serverTextBox = new TextBox();
            serverLabel = new Label();
            okButton = new Button();
            cancelButton = new Button();
            connectionTestButton = new Button();
            groupBox1.SuspendLayout();
            loginPanel.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Controls.Add(loginPanel);
            groupBox1.Controls.Add(authLabel);
            groupBox1.Controls.Add(authComboBox);
            groupBox1.Controls.Add(databaseTextBox);
            groupBox1.Controls.Add(databaseLabel);
            groupBox1.Controls.Add(serverTextBox);
            groupBox1.Controls.Add(serverLabel);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // loginPanel
            // 
            resources.ApplyResources(loginPanel, "loginPanel");
            loginPanel.Controls.Add(passwordTextBox);
            loginPanel.Controls.Add(passwordLabel);
            loginPanel.Controls.Add(userTextBox);
            loginPanel.Controls.Add(userLabel);
            loginPanel.Name = "loginPanel";
            // 
            // passwordTextBox
            // 
            resources.ApplyResources(passwordTextBox, "passwordTextBox");
            passwordTextBox.Name = "passwordTextBox";
            // 
            // passwordLabel
            // 
            resources.ApplyResources(passwordLabel, "passwordLabel");
            passwordLabel.Name = "passwordLabel";
            // 
            // userTextBox
            // 
            resources.ApplyResources(userTextBox, "userTextBox");
            userTextBox.Name = "userTextBox";
            // 
            // userLabel
            // 
            resources.ApplyResources(userLabel, "userLabel");
            userLabel.Name = "userLabel";
            // 
            // authLabel
            // 
            resources.ApplyResources(authLabel, "authLabel");
            authLabel.Name = "authLabel";
            // 
            // authComboBox
            // 
            resources.ApplyResources(authComboBox, "authComboBox");
            authComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            authComboBox.FormattingEnabled = true;
            authComboBox.Items.AddRange(new object[] { resources.GetString("authComboBox.Items"), resources.GetString("authComboBox.Items1") });
            authComboBox.Name = "authComboBox";
            authComboBox.SelectedIndexChanged += authComboBox_SelectedIndexChanged;
            // 
            // databaseTextBox
            // 
            resources.ApplyResources(databaseTextBox, "databaseTextBox");
            databaseTextBox.Name = "databaseTextBox";
            // 
            // databaseLabel
            // 
            resources.ApplyResources(databaseLabel, "databaseLabel");
            databaseLabel.Name = "databaseLabel";
            // 
            // serverTextBox
            // 
            resources.ApplyResources(serverTextBox, "serverTextBox");
            serverTextBox.Name = "serverTextBox";
            // 
            // serverLabel
            // 
            resources.ApplyResources(serverLabel, "serverLabel");
            serverLabel.Name = "serverLabel";
            // 
            // okButton
            // 
            resources.ApplyResources(okButton, "okButton");
            okButton.Name = "okButton";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            resources.ApplyResources(cancelButton, "cancelButton");
            cancelButton.Name = "cancelButton";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // connectionTestButton
            // 
            resources.ApplyResources(connectionTestButton, "connectionTestButton");
            connectionTestButton.Name = "connectionTestButton";
            connectionTestButton.UseVisualStyleBackColor = true;
            connectionTestButton.Click += connectionTestButton_Click;
            // 
            // setConnectionString
            // 
            AcceptButton = okButton;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            Controls.Add(connectionTestButton);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "setConnectionString";
            Load += setConnectionString_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label serverLabel;
        private TextBox serverTextBox;
        private TextBox databaseTextBox;
        private Label databaseLabel;
        private Label authLabel;
        private ComboBox authComboBox;
        private Panel loginPanel;
        private TextBox passwordTextBox;
        private Label passwordLabel;
        private TextBox userTextBox;
        private Label userLabel;
        private Button okButton;
        private Button cancelButton;
        private Button connectionTestButton;
    }
}