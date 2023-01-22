using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRex.MPS.Login.Model;
using TRex.MPS.Model.Configuration;
using TRex.MPS.Core.Data;

namespace TRex.MPS.Login.DataService
{
    public class LoginDataService : ILoginDataService
    {
        private readonly AppSettings _appSettings;

        public LoginDataService(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public IEnumerable<UserLoginRecord> GetUserBy(string userName, string password)
        {
            var result = new List<UserLoginRecord>();

            var query = "SELECT * FROM User WHERE userName = @username AND password = @password";

            using var sqlConnection = new SqlConnection(_appSettings.DataBaseSettings.ConnectionString);
            sqlConnection.Open();

            var sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@userName", userName);
            sqlCommand.Parameters.AddWithValue("@password", password);

            var queryResult = sqlCommand.ExecuteReader();

            while (queryResult.Read())
            {
                result.Add(new UserLoginRecord(
                    DataExtensionMethods.GetDataReaderValue<int>(queryResult, "Id"),
                    DataExtensionMethods.GetDataReaderValue<string>(queryResult, "UserName"),
                    DataExtensionMethods.GetDataReaderValue<string>(queryResult, "Role")));
            }

            return result;
        }
    }
}