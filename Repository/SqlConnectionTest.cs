using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Repository
{
    public static class SqlConnectionTest
    {
        private static bool TestConnection(string connectionString , out Exception error)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    
                }
                error = null; 
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                return false; 
            }
            
        }
        public static bool ChangeConnectionString(string connectionString)
        {
            Exception exception; 
            bool connectionTest = TestConnection(connectionString,out exception);
            if (connectionTest == false)
            {
                return false; 
            }

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string connection = "Data Source=localhost;Database=SurveyConfigrator;Trusted_Connection=True;TrustServerCertificate=True";
            config.ConnectionStrings.ConnectionStrings["DbConnectionString"].ConnectionString = connection;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            return true;
        
        }

    }
}