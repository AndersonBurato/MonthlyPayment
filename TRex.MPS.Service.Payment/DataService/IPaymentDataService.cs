namespace TRex.MPS.Payment.DataService
{
    public interface IPaymentDataService
    {
        void AddPaymentToClaim(DateTimeOffset monthYear, int employeeId, string code);

        bool ClaimSalary(int employeeId, int code);
    }
}