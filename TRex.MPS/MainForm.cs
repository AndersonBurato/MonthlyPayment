using TRex.MPS.Config;

namespace TRex.MPS;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        var loginForm = IoC.GetForm<LoginForm>();
        loginForm.ShowDialog();

        if (!loginForm.IsAuthentiated)
        {
            Application.Exit();
            return;
        }

        employeesToolStripMenuItem.Visible = Global.profile.Role.Equals("hr", StringComparison.OrdinalIgnoreCase);
        myActionsToolStripMenuItem.Visible = true;
    }

    private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var paymentsForm = IoC.GetForm<PaymentsForm>();
        paymentsForm.MdiParent = this;
        paymentsForm.Show();
    }

    private void claimSalaryToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var claimSalaryForm = IoC.GetForm<ClaimSalaryForm>();
        claimSalaryForm.MdiParent = this;
        claimSalaryForm.Show();
    }
}