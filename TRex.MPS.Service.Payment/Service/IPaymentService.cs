using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRex.MPS.Model.Employee;
using TRex.MPS.Model.Payment;

namespace TRex.MPS.Payment.Service
{
    public interface IPaymentService
    {
        List<EmployeePaymentCode> GenerateCodesToEmails(DateTimeOffset paymentDate, List<EmployeeModel> employees);

        bool ClaimSalary(int employeeId, int code);
    }
}