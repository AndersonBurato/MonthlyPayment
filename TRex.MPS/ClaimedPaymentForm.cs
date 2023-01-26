using System.Text;
using TRex.MPS.Model.Payment;
using TRex.MPS.Payment.DataService;

namespace TRex.MPS;

public partial class ClaimedPaymentForm : Form
{
    private readonly IPaymentDataService _paymentDataService;
    

    public ClaimedPaymentForm(IPaymentDataService paymentDataService)
    {
        InitializeComponent();
        _paymentDataService = paymentDataService;
    }

    private void ClaimedPaymentForm_Load(object sender, EventArgs e)
    {
        PaymentDateTimePicker_ValueChanged(sender, e);
    }

    private void PaymentDateTimePicker_ValueChanged(object sender, EventArgs e)
    {
        var paymentDate = new DateTimeOffset(PaymentDateTimePicker.Value.Year, PaymentDateTimePicker.Value.Month, 1, 0, 0, 0, new TimeSpan(0, 0, 0));
        
        ClaimedPaymentslistBox.Items.Clear();

        var payments = _paymentDataService.GetEmployeePaymentCodes();

        ClaimedPaymentslistBox.Items.Add("Name - Status");
        
        foreach (var payment in payments.Where(x=> x.PaymentDate == paymentDate))
        {
            ClaimedPaymentslistBox.Items.Add($"{payment.EmployeeName} - {(payment.Claimed ? "Completed" : "Pending")}");
        }
    }
}