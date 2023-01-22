using Microsoft.Data.SqlClient;
using TRex.MPS.Core.Data;
using TRex.MPS.Model.Configuration;
using TRex.MPS.Model.Employee;

namespace TRex.MPS.Employee.DataService
{
    public interface IEmployeeDataService
    {
        List<EmployeeModel> GetAll();
    }
}