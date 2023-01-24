using Microsoft.Data.SqlClient;
using TRex.MPS.Core.Data;
using TRex.MPS.Model.Configuration;
using TRex.MPS.Model.Employee;

namespace TRex.MPS.Employee.DataService;

public class EmployeeDataService : IEmployeeDataService
{
    private readonly AppSettings _appSettings;

    public EmployeeDataService(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }

    public List<EmployeeModel> GetAll()
    {
        var result = new List<EmployeeModel>();


        var query = "SELECT EmployeeId, Name, Email FROM Employee";

        using var sqlConnection = new SqlConnection(_appSettings.DataBaseSettings.ConnectionString);
        sqlConnection.Open();

        var sqlCommand = new SqlCommand(query, sqlConnection);

        var queryResult = sqlCommand.ExecuteReader();

        while (queryResult.Read())
            result.Add(new EmployeeModel
            {
                Id = DataExtensionMethods.GetDataReaderValue<int>(queryResult, "EmployeeId"),
                Email = DataExtensionMethods.GetDataReaderValue<string>(queryResult, "Email"),
                Name = DataExtensionMethods.GetDataReaderValue<string>(queryResult, "Name")
            });

        return result;
    }
}