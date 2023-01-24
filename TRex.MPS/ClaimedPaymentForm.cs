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

    //generate a report with all the payments claimed or pending
}