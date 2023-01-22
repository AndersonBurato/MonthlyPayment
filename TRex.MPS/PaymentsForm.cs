using TRex.MPS.Employee.DataService;
using TRex.MPS.Employee.Service;
using TRex.MPS.Model.Employee;
using TRex.MPS.Payment.Service;

namespace TRex.MPS
{
    public partial class PaymentsForm : Form
    {
        public IPaymentService _paymentService { get; }
        public IEmployeeDataService _employeeDataService { get; }

        public PaymentsForm(
            IPaymentService paymentService,
            IEmployeeDataService employeeDataService
            )
        {
            InitializeComponent();
            _paymentService = paymentService;
            _employeeDataService = employeeDataService;
        }

        private void PaymentsForm_Load(object sender, EventArgs e)
        {
            var employeeList = _employeeDataService.GetAll();

            foreach (var employee in employeeList)
            {
                EmployeeCheckedList.Items.Add(new { value = employee.Id, Text = $"{employee.Id} - {employee.Name}" });
            }
        }

        private void SendPaymentCodes_Click(object sender, EventArgs e)
        {
            var selectedEmployee = EmployeeCheckedList.CheckedItems;

            var employeeToGenerateCode = new List<EmployeeModel>();

            foreach (var item in EmployeeCheckedList.CheckedItems)
            {
                employeeToGenerateCode.Add(new EmployeeModel {
                    Id = (int)item
                });
            }

            var employeeCodes = _paymentService.GenerateCodesToEmails(MonthYearPaymentDateTimePicker.Value, employeeToGenerateCode);
        
            //todo:send email
        }
    }
}