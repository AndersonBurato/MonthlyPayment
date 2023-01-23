namespace TRex.MPS.Model.Payment;

public class EmployeePaymentCode
{
    public int EmployeeId { get; set; }
    public DateTimeOffset PaymentDate { get; set; }
    public string EmployeeName { get; set; }
    public string EMail { get; set; }
    public string Code { get; set; }
    public string MagnifiedCode { get; set; }
    public decimal Salary { get; set; }
}