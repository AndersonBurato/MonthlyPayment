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
            EmployeeCheckedList.Items.Add(new objectListItem
                { Value = employee.Id, Text = $"{employee.Id} - {employee.Name}" });
    }

    private void SendPaymentCodes_Click(object sender, EventArgs e)
    {
        var selectedEmployee = EmployeeCheckedList.CheckedItems;

        var employeeToGenerateCode = new List<EmployeeModel>();

        foreach (var item in EmployeeCheckedList.CheckedItems)
        {
            var objectListItem = (objectListItem)item;

            employeeToGenerateCode.Add(new EmployeeModel
            {
                Id = objectListItem.Value
            });
        }

        var employeeCodes =
            _paymentService.GenerateCodesToEmails(MonthYearPaymentDateTimePicker.Value, employeeToGenerateCode);

        //todo:send email
    }
}