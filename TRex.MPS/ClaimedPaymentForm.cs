using TRex.MPS.Model.Payment;

namespace TRex.MPS;

public partial class ClaimedPaymentForm : Form
{
    private string[,] magnifiedNumbers =
    {
        { "  _ ", "   ", "  _ ", " _ ", "    ", "  _ ", "  _ ", " _ ", "  _ ", "  _ " },
        { " | |", " | ", "  _|", " _|", " |_|", " |_ ", " |_ ", "  |", " |_|", " |_|" },
        { " |_|", " | ", " |_ ", " _|", "   |", "  _|", " |_|", "  |", " |_|", "  _|" }
    };

    public ClaimedPaymentForm()
    {
        InitializeComponent();
    }

    private void ClaimedPaymentForm_Load(object sender, EventArgs e)
    {
        List<EmployeePaymentCode> employeePaymentCodes = new List<EmployeePaymentCode>();


    }

    //generate a report with all the payments claimed or pending
}