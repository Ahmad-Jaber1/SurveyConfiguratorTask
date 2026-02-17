using Serilog;
using Services;
using Shared;
using System;
using System.Text;
using System.Windows.Forms;

namespace SurveyConfiguratorTask
{
    public partial class setConnectionString : Form
    {
        QuestionService mService;

        private const string UI_ERROR_MESSAGE =
            "An unexpected error occurred. Please contact support or the system administrator.";
        public const string ERROR = "Error";

        public setConnectionString(QuestionService pService)
        {
            try
            {
                mService = pService;
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setConnectionString_Load(object sender, EventArgs e)
        {
            
            try
            {
                authComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                
                var tConnectionString = mService.GetConnectionString();
                if (!tConnectionString.Success)
                {
                    authComboBox.SelectedIndex = 0;
                    return;
                }
                serverTextBox.Text = tConnectionString.Data.DataSource;
                databaseTextBox.Text = tConnectionString.Data.InitialCatalog;
                authComboBox.SelectedIndex = tConnectionString.Data.IntegratedSecurity ? 0 : 1;
                if (!tConnectionString.Data.IntegratedSecurity)
                {
                    userTextBox.Text = tConnectionString.Data.UserID;
                    passwordTextBox.Text = tConnectionString.Data.Password;
                }

            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                //Starting from SqlClient 4.0 , Changed Encrypt connection string property to be true by default 
                stringBuilder.Append("TrustServerCertificate=True;");
                string connectionString = stringBuilder.ToString();

                var tResult = mService.ChangeConnectionString(connectionString);
                if (!tResult.Success)
                {
                    MessageBox.Show(
                        ErrorLocalizer.GetMessage(tResult.Error.ToString()),
                        ERROR,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                Close();
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void connectionTestButton_Click(object sender, EventArgs e)
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
                //Starting from SqlClient 4.0 , Changed Encrypt connection string property to be true by default 

                stringBuilder.Append("TrustServerCertificate=True;");
                string tConnectionString = stringBuilder.ToString();

                var tResult = mService.ConnectionTest(tConnectionString);
                if (!tResult.Success)
                {
                    MessageBox.Show(
                        ErrorLocalizer.GetMessage(tResult.Error.ToString()),
                        ERROR,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Test successful: the application was able to connect to the database.", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                //Close();
            }
            catch (Exception ex)
            {
                Log.Error(null, ex);
                MessageBox.Show(ErrorLocalizer.GetMessage(nameof(UI_ERROR_MESSAGE)), ERROR,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
