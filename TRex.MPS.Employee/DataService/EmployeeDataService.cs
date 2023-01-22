using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRex.MPS.Core.Data;
using TRex.MPS.Model.Configuration;
using TRex.MPS.Model.Employee;

namespace TRex.MPS.Employee.DataService
{
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


            var query = "SELECT * FROM Employee";

            using var sqlConnection = new SqlConnection(_appSettings.DataBaseSettings.ConnectionString);
            sqlConnection.Open();

            var sqlCommand = new SqlCommand(query, sqlConnection);

            var queryResult = sqlCommand.ExecuteReader();

            while (queryResult.Read())
            {
                result.Add(new EmployeeModel
                {
                    Id = DataExtensionMethods.GetDataReaderValue<int>(queryResult, "Id"),
                    Name = DataExtensionMethods.GetDataReaderValue<string>(queryResult, "Name"),
                    Salary = DataExtensionMethods.GetDataReaderValue<decimal>(queryResult, "Salary")
                });
            }

            return result;
        }
    }
}