using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRex.MPS.Model.Configuration;

namespace TRex.MPS.Payment.DataService
{
    public class PaymentDataService : IPaymentDataService
    {
        private readonly AppSettings _appSettings;

        public PaymentDataService(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public void AddPaymentToClaim(DateTimeOffset monthYear, int employeeId, string code)
        {
            var query = "INSERT INTO Payment(monthYear, employeeId, code)VALUES(@monthYear, @employeeId, @code)";

            using var sqlConnection = new SqlConnection(_appSettings.DataBaseSettings.ConnectionString);
            sqlConnection.Open();

            var sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@monthYear", monthYear);
            sqlCommand.Parameters.AddWithValue("@employeeId", employeeId);
            sqlCommand.Parameters.AddWithValue("@code", code);
        }

        public bool ClaimSalary(int employeeId, int code)
        {
            var query = "UPDATE Payment SET claimed = 1 WHERE employeeId = @employeeId AND code = @code and claimed = 0";

            using var sqlConnection = new SqlConnection(_appSettings.DataBaseSettings.ConnectionString);
            sqlConnection.Open();

            var sqlCommand = new SqlCommand(query, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@employeeId", employeeId);
            sqlCommand.Parameters.AddWithValue("@code", code);

            return sqlCommand.ExecuteNonQuery() > 0;
        }
    }
}