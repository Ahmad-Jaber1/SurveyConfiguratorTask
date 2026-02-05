using Microsoft.Data.SqlClient;
using Shared;
using System;

namespace Repository
{
    public static class SqlConnectionTest
    {
        public static Result<bool> TestConnection(string connectionString ,out Exception exErorr)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                }
                exErorr = null; 
                return new Result<bool>
                {
                    Success = true,
                    Data = true,
                    Erorr = ErrorTypeEnum.None
                };
            }
            catch (Exception ex)
            {
                exErorr = ex;   
                return new Result<bool>
                {
                    Success = false,
                    Data = false,
                    Erorr = ErrorTypeEnum.ConnectionStringError,
                    Message = ex.Message
                };
            }
        }
    }
}
