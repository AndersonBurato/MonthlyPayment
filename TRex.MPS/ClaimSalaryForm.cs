using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRex.MPS.Payment.Service;

namespace TRex.MPS
{
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
            try
            {
                if (!int.TryParse(ClaimButton.Text, out int code))
                {
                    MessageBox.Show("Invalid Code");
                    return;
                }

                _paymentService.ClaimSalary(Global.profile!.EmployeeId, code);

                MessageBox.Show("Salary claimed.", "Success");
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}