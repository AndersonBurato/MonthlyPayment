using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TRex.MPS.Model.Employee;
using TRex.MPS.Model.Payment;
using TRex.MPS.Payment.DataService;

namespace TRex.MPS.Payment.Service
{
    public class PaymentService : IPaymentService
    {
        

        private readonly IPaymentDataService _paymentDataService;

        public PaymentService(IPaymentDataService paymentDataService)
        {
            _paymentDataService = paymentDataService;
        }

        public List<EmployeePaymentCode> GenerateCodesToEmails(DateTimeOffset paymentDate, List<EmployeeModel> employees)
        {
            var employeeCodeList = new List<EmployeePaymentCode>();

            foreach (var employee in employees)
            {
                var code = GenerateCode(paymentDate, employee.Id);

                _paymentDataService.AddPaymentToClaim(paymentDate, employee.Id, code);

                employeeCodeList.Add(new EmployeePaymentCode
                {
                    EmployeeId = employee.Id,
                    Code = code,
                    EmployeeName = employee.Name,
                    PaymentDate = paymentDate,
                    Salary = employee.Salary
                });
            }

            return employeeCodeList;
        }

        private string GenerateCode(DateTimeOffset paymentDate, int employeeId)
        {
            return  $"{paymentDate.Month}{paymentDate.Year}{new Random(employeeId).Next()}";
        }

        public bool ClaimSalary(int employeeId, int code)
        {
            return _paymentDataService.ClaimSalary(employeeId, code);
        }
    }
}