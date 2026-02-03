using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SurveyConfiguratorTask
{
    public partial class setConnectionString : Form
    {
        QuestionService service;
        public setConnectionString(QuestionService service)
        {
            this.service = service;
            InitializeComponent();

        }

        private void setConnectionString_Load(object sender, EventArgs e)
        {
            authComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            authComboBox.Items.Clear();
            authComboBox.Items.Add("Windows authentication");
            authComboBox.Items.Add("SQL Server authentication");
            authComboBox.SelectedIndex = 0;
        }

        private void authComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (authComboBox.SelectedIndex == 0)
            {
                loginPanel.Enabled = false;
            }
            else
                loginPanel.Enabled = true;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Data Source={serverTextBox.Text};" +
                $"Database={databaseTextBox.Text};");
            if (authComboBox.SelectedIndex == 0)
                stringBuilder.Append("Trusted_Connection=True;");
            else
                stringBuilder.Append($"User Id={userTextBox.Text};Password={passwordTextBox.Text};" +
                    $"Trusted_Connection=False;");
            stringBuilder.Append("TrustServerCertificate=True;");
            string connectionString = stringBuilder.ToString();

            service.ChangeConnectionString(connectionString);

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
