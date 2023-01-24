using TRex.MPS.Payment.Service;

namespace TRex.MPS;

public partial class ClaimSalaryForm : Form
{
    private readonly IPaymentService _paymentService;

    public ClaimSalaryForm(IPaymentService paymentService)
    {
        InitializeComponent();
        _paymentService = paymentService;
    }

    private void ClaimButton_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(CodeText.Text, out var code))
        {
            MessageBox.Show("Invalid Code");
            return;
        }

        if (_paymentService.ClaimSalary(Global.profile!.EmployeeId, code))
            MessageBox.Show("Salary claimed.", "Success");
        else
            MessageBox.Show("Code doesn't exist or already claimed");

        //todo:generate report with the payment as done
    }
}