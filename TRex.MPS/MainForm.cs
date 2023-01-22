using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRex.MPS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var loginForm = Config.IoC.GetForm<LoginForm>();
            loginForm.ShowDialog();

            if (!loginForm.IsAuthentiated)
                Application.Exit();
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var paymentsForm = Config.IoC.GetForm<PaymentsForm>();
            paymentsForm.MdiParent = this;
            paymentsForm.Show();
        }

        private void claimSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var claimSalaryForm = Config.IoC.GetForm<ClaimSalaryForm>();
            claimSalaryForm.MdiParent = this;
            claimSalaryForm.Show();
        }
    }
}