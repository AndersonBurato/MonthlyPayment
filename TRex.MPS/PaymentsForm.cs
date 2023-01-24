using System.Linq;
using TRex.MPS.Employee.DataService;
using TRex.MPS.Model;
using TRex.MPS.Model.Employee;
using TRex.MPS.Payment.Service;

namespace TRex.MPS;

public partial class PaymentsForm : Form
{
    public PaymentsForm(
        IPaymentService paymentService,
        IEmployeeDataService employeeDataService
    )
    {
        InitializeComponent();
        _paymentService = paymentService;
        _employeeDataService = employeeDataService;
    }

    public IPaymentService _paymentService { get; }
    public IEmployeeDataService _employeeDataService { get; }

    private void PaymentsForm_Load(object sender, EventArgs e)
    {
        var employeeList = _employeeDataService.GetAll();
        EmployeeCheckedList.DisplayMember = "text";
        EmployeeCheckedList.ValueMember = "value";


        foreach (var employee in employeeList)
            EmployeeCheckedList.Items.Add(new ObjectListItem
                { Value = employee.Id, Text = employee.Name });
    }

    private void SendPaymentCodes_Click(object sender, EventArgs e)
    {
        var employeeToGenerateCode = new List<EmployeeModel>();

        foreach (var item in EmployeeCheckedList.CheckedItems)
        {
            var objectListItem = (ObjectListItem)item;

            employeeToGenerateCode.Add(new EmployeeModel
            {
                Id = objectListItem.Value,
                Name = objectListItem.Text
            });
        }

        var paymentDate = new DateTime(MonthYearPaymentDateTimePicker.Value.Year, MonthYearPaymentDateTimePicker.Value.Month, 1);

        var (employeeCodes, employeeNamesPaymentAlreadyExist) =
            _paymentService.GenerateCodesToEmails(paymentDate, employeeToGenerateCode);

        //todo:send real email

        if (employeeNamesPaymentAlreadyExist.Any())
        {
            MessageBox.Show($"Payment code already exist for: {string.Join(",", employeeNamesPaymentAlreadyExist)}");
        }

        MessageBox.Show("Emails sent.");
    }
}