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
            groupBox1.SuspendLayout();
            loginPanel.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(loginPanel);
            groupBox1.Controls.Add(authLabel);
            groupBox1.Controls.Add(authComboBox);
            groupBox1.Controls.Add(databaseTextBox);
            groupBox1.Controls.Add(databaseLabel);
            groupBox1.Controls.Add(serverTextBox);
            groupBox1.Controls.Add(serverLabel);
            groupBox1.Location = new Point(5, 9);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(569, 263);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Connection Settings";
            // 
            // loginPanel
            // 
            loginPanel.Controls.Add(passwordTextBox);
            loginPanel.Controls.Add(passwordLabel);
            loginPanel.Controls.Add(userTextBox);
            loginPanel.Controls.Add(userLabel);
            loginPanel.Location = new Point(6, 153);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(561, 104);
            loginPanel.TabIndex = 10;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(121, 61);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(436, 23);
            passwordTextBox.TabIndex = 17;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(0, 69);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(57, 15);
            passwordLabel.TabIndex = 16;
            passwordLabel.Text = "Password";
            // 
            // userTextBox
            // 
            userTextBox.Location = new Point(121, 21);
            userTextBox.Name = "userTextBox";
            userTextBox.Size = new Size(436, 23);
            userTextBox.TabIndex = 15;
            // 
            // userLabel
            // 
            userLabel.AutoSize = true;
            userLabel.Location = new Point(0, 24);
            userLabel.Name = "userLabel";
            userLabel.Size = new Size(33, 15);
            userLabel.TabIndex = 14;
            userLabel.Text = "User:";
            // 
            // authLabel
            // 
            authLabel.AutoSize = true;
            authLabel.Location = new Point(6, 123);
            authLabel.Name = "authLabel";
            authLabel.Size = new Size(115, 15);
            authLabel.TabIndex = 9;
            authLabel.Text = "Authentication type:";
            // 
            // authComboBox
            // 
            authComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            authComboBox.FormattingEnabled = true;
            authComboBox.Items.AddRange(new object[] { "" });
            authComboBox.Location = new Point(127, 123);
            authComboBox.Name = "authComboBox";
            authComboBox.Size = new Size(436, 23);
            authComboBox.TabIndex = 8;
            authComboBox.SelectedIndexChanged += authComboBox_SelectedIndexChanged;
            // 
            // databaseTextBox
            // 
            databaseTextBox.Location = new Point(127, 77);
            databaseTextBox.Name = "databaseTextBox";
            databaseTextBox.Size = new Size(436, 23);
            databaseTextBox.TabIndex = 3;
            // 
            // databaseLabel
            // 
            databaseLabel.AutoSize = true;
            databaseLabel.Location = new Point(6, 80);
            databaseLabel.Name = "databaseLabel";
            databaseLabel.Size = new Size(58, 15);
            databaseLabel.TabIndex = 2;
            databaseLabel.Text = "Database:";
            // 
            // serverTextBox
            // 
            serverTextBox.Location = new Point(127, 33);
            serverTextBox.Name = "serverTextBox";
            serverTextBox.Size = new Size(436, 23);
            serverTextBox.TabIndex = 1;
            // 
            // serverLabel
            // 
            serverLabel.AutoSize = true;
            serverLabel.Location = new Point(6, 36);
            serverLabel.Name = "serverLabel";
            serverLabel.Size = new Size(45, 15);
            serverLabel.TabIndex = 0;
            serverLabel.Text = "Server: ";
            // 
            // okButton
            // 
            okButton.Location = new Point(395, 291);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 1;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(476, 291);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 2;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // setConnectionString
            // 
            AcceptButton = okButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(584, 337);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "setConnectionString";
            Text = "Database Connection";
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
    }
}