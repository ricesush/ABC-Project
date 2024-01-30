using Serilog;
using Dapper;
using MySql.Data.MySqlClient;
using ABC.Shared.Models;

namespace ABC.Shared.Services;

public partial class POSService_SQL
{ 
    #region BATCH FETCH OF MARKET DATA: SECURITY INFORMATION AND SECURITY QUOTATION
    private async Task<string> GetAllCustomerInformation(string AuthToken, string status)
    {
        // string queryTrade = $"SELECT cs.client_id, c.first_name, ca.status FROM {dbName}.client_session AS cs INNER JOIN {dbName}.client AS c ON cs.client_id = c.id INNER JOIN {dbName}.client_account AS ca ON c.id = ca.client_id WHERE cs.token = @token AND ca.status = 1";
        // string queryTrade = $"SELECT ca.status FROM {dbName}.client_session AS cs INNER JOIN {dbName}.client AS c ON cs.client_id = c.id INNER JOIN {dbName}.client_account AS ca ON c.id = ca.client_id WHERE cs.token = @token AND ca.status = 1";
        string query = $"SELECT cs.client_id, ca.status FROM client_session AS cs INNER JOIN client AS c ON cs.client_id = c.id INNER JOIN client_account AS ca ON c.id = ca.client_id WHERE cs.token = @token AND ca.status = @status";
        try
        {
            string Name = String.Empty;

            using (var userServiceSql = new MySqlConnection(AbcDbConnection))
            {
                MySqlCommand command = new MySqlCommand(query, userServiceSql);
                command.Parameters.Add("token", MySqlDbType.String);
                command.Parameters["token"].Value = AuthToken;
                command.Parameters.Add("status", MySqlDbType.Int32);
                command.Parameters["status"].Value = status;
                userServiceSql.Open();
                var userRawTradeData = command.ExecuteReader();
                while (userRawTradeData.Read())
                {
                    Name = Convert.ToString(userRawTradeData["status"]);
                }
                
                return Name;
            };
        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());
            return null;
        }
    }
    #endregion
}