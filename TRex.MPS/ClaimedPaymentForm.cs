using System.Text;
using TRex.MPS.Model.Payment;
using TRex.MPS.Payment.DataService;

namespace TRex.MPS;

public partial class ClaimedPaymentForm : Form
{
    private readonly IPaymentDataService _paymentDataService;
    private string[,] magnifiedNumbers =
    {
        { "  _ ", "   ", "  _ ", " _ ", "    ", "  _ ", "  _ ", " _ ", "  _ ", "  _ " },
        { " | |", " | ", "  _|", " _|", " |_|", " |_ ", " |_ ", "  |", " |_|", " |_|" },
        { " |_|", " | ", " |_ ", " _|", "   |", "  _|", " |_|", "  |", " |_|", "  _|" }
    };

    public ClaimedPaymentForm(IPaymentDataService paymentDataService)
    {
        InitializeComponent();
        _paymentDataService = paymentDataService;
    }

    private void ClaimedPaymentForm_Load(object sender, EventArgs e)
    {
        List<EmployeePaymentCode> employeePaymentCodes = _paymentDataService.GetEmployeePaymentCodes();

        foreach (var employeePaymentCode in employeePaymentCodes)
        {
            employeePaymentCode.MagnifiedCode = MagnifyCode(employeePaymentCode.Code);
        }

        MessageBox.Show("");
    }

    private StringBuilder MagnifyCode(string code)
    {
        var mamagnifiedCode = new StringBuilder();

        for (int lineNumber = 0; lineNumber < 3; lineNumber++)
        {
            foreach (char c in code)
            {
                mamagnifiedCode.Append(magnifiedNumbers[lineNumber, int.Parse(c.ToString())]);
            }

            mamagnifiedCode.AppendLine();
        }

        return mamagnifiedCode;
    }
}