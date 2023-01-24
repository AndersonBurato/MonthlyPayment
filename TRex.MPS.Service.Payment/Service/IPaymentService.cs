using TRex.MPS.Model.Employee;
using TRex.MPS.Model.Payment;

namespace TRex.MPS.Payment.Service;

public interface IPaymentService
{
    (List<EmployeePaymentCode>, List<string>) GenerateCodesToEmails(DateTimeOffset paymentDate, List<EmployeeModel> employees);

    bool ClaimSalary(int employeeId, int code);
}