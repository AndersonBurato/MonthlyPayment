using TRex.MPS.Model.Payment;

namespace TRex.MPS.Payment.Service;

public interface IPaymentEMailService
{
    void SendPaymentCodes(List<EmployeePaymentCode> paymentCodes);
}