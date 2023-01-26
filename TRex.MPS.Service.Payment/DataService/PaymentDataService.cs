using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Security.Claims;
using TRex.MPS.Core.Data;
using TRex.MPS.Model.Configuration;
using TRex.MPS.Model.Employee;
using TRex.MPS.Model.Payment;

namespace TRex.MPS.Payment.DataService;

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

        sqlCommand.ExecuteNonQuery();
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

    public List<EmployeePaymentCode> GetEmployeePaymentCodes()
    {
        var result = new List<EmployeePaymentCode>();

        var query = $"SELECT e.EmployeeId, p.MonthYear AS PaymentDate, e.Name AS EmployeeName, p.Code, p.Claimed " +
                    $"FROM Payment p " +
                    $"INNER JOIN Employee e ON p.EmployeeId = e.EmployeeId";

        using var sqlConnection = new SqlConnection(_appSettings.DataBaseSettings.ConnectionString);
        sqlConnection.Open();

        var sqlCommand = new SqlCommand(query, sqlConnection);

        var queryResult = sqlCommand.ExecuteReader();

        sqlConnection.Close();
        
        while (queryResult.Read())
            result.Add(new EmployeePaymentCode
            {
                EmployeeId = DataExtensionMethods.GetDataReaderValue<int>(queryResult, "EmployeeId"),
                PaymentDate = DateTime.SpecifyKind(DataExtensionMethods.GetDataReaderValue<DateTime>(queryResult, "PaymentDate"), DateTimeKind.Utc),
                EmployeeName = DataExtensionMethods.GetDataReaderValue<string>(queryResult, "EmployeeName"),
                Code = DataExtensionMethods.GetDataReaderValue<string>(queryResult, "Code"),
                Claimed = DataExtensionMethods.GetDataReaderValue<bool>(queryResult, "Claimed")
            });

        return result;
    }
}