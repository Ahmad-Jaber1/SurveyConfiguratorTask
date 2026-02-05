using Services;
using Serilog;
using System;
using System.Text;
using System.Windows.Forms;

namespace SurveyConfiguratorTask
{
    public partial class setConnectionString : Form
    {
        QuestionService service;

        private const string UiErrorMessage =
            "An unexpected error occurred. Please contact support or the system administrator.";

        public setConnectionString(QuestionService service)
        {
            try
            {
                this.service = service;
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(
                    UiErrorMessage,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void setConnectionString_Load(object sender, EventArgs e)
        {
            try
            {
                authComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                authComboBox.Items.Clear();
                authComboBox.Items.Add("Windows authentication");
                authComboBox.Items.Add("SQL Server authentication");
                authComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(
                    UiErrorMessage,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void authComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (authComboBox.SelectedIndex == 0)
                {
                    loginPanel.Enabled = false;
                }
                else
                {
                    loginPanel.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(
                    UiErrorMessage,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(
                    $"Data Source={serverTextBox.Text};" +
                    $"Database={databaseTextBox.Text};");

                if (authComboBox.SelectedIndex == 0)
                {
                    stringBuilder.Append("Trusted_Connection=True;");
                }
                else
                {
                    stringBuilder.Append(
                        $"User Id={userTextBox.Text};" +
                        $"Password={passwordTextBox.Text};" +
                        $"Trusted_Connection=False;");
                }

                stringBuilder.Append("TrustServerCertificate=True;");
                string connectionString = stringBuilder.ToString();

                var result = service.ChangeConnectionString(connectionString);
                if (!result.Success)
                {
                    MessageBox.Show(
                        result.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                Close();
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(
                    UiErrorMessage,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(
                    UiErrorMessage,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
