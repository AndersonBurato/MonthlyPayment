using TRex.MPS.Model.Employee;
using TRex.MPS.Model.Payment;
using TRex.MPS.Payment.DataService;

namespace TRex.MPS.Payment.Service;

public class PaymentService : IPaymentService
{
    private readonly IPaymentDataService _paymentDataService;

    public PaymentService(IPaymentDataService paymentDataService)
    {
        _paymentDataService = paymentDataService;
    }

    public (List<EmployeePaymentCode>, List<string>) GenerateCodesToEmails(DateTimeOffset paymentDate, List<EmployeeModel> employees)
    {
        var employeeCodeList = new List<EmployeePaymentCode>();
        var employeeNamesForExistingPayments = new List<string>();

        foreach (var employee in employees)
        {
            var code = GenerateCode(paymentDate, employee.Id);

            try
            {
                _paymentDataService.AddPaymentToClaim(paymentDate, employee.Id, code);
            }
            catch
            {
                employeeNamesForExistingPayments.Add(employee.Name);
            }

            employeeCodeList.Add(new EmployeePaymentCode
            {
                EmployeeId = employee.Id,
                Code = code,
                EmployeeName = employee.Name,
                Salary = employee.Salary,
                PaymentDate = paymentDate
            });
        }

        return (employeeCodeList, employeeNamesForExistingPayments);
    }

    public bool ClaimSalary(int employeeId, string code)
    {
        return _paymentDataService.ClaimSalary(employeeId, code);
    }

    private string GenerateCode(DateTimeOffset paymentDate, int employeeId)
    {
        return $"{paymentDate.ToString("MMyy")}{new Random().Next(0, 99999)}";
    }
}