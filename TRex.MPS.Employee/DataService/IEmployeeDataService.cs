using TRex.MPS.Model.Employee;

namespace TRex.MPS.Employee.DataService;

public interface IEmployeeDataService
{
    List<EmployeeModel> GetAll();
}