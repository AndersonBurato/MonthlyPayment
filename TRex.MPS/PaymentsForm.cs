using System.Linq;
using TRex.MPS.Employee.DataService;
using TRex.MPS.Model;
using TRex.MPS.Model.Employee;
using TRex.MPS.Payment.Service;

namespace TRex.MPS;

public partial class PaymentsForm : Form
{

    private readonly IPaymentService _paymentService;
    private readonly IEmployeeDataService _employeeDataService;
    private readonly IPaymentEMailService _paymentEmailService;

    public PaymentsForm(
        IPaymentService paymentService,
        IEmployeeDataService employeeDataService,
        IPaymentEMailService paymentEmailService
    )
    {
        InitializeComponent();
        _paymentService = paymentService;
        _employeeDataService = employeeDataService;
        _paymentEmailService = paymentEmailService;
    }
    
    private void PaymentsForm_Load(object sender, EventArgs e)
    {
        var employeeList = _employeeDataService.GetAll();
        EmployeeCheckedList.DisplayMember = "Name";
        EmployeeCheckedList.ValueMember = "Id";
        
        foreach (var employee in employeeList)
        {
            EmployeeCheckedList.Items.Add(employee);
        }
    }

    private void SendPaymentCodes_Click(object sender, EventArgs e)
    {
        var employeeToGenerateCode = new List<EmployeeModel>();

        foreach (var item in EmployeeCheckedList.CheckedItems)
        {
            var employee = (EmployeeModel)item;

            employeeToGenerateCode.Add(employee);
        }

        var paymentDate = new DateTimeOffset(MonthYearPaymentDateTimePicker.Value.Year, MonthYearPaymentDateTimePicker.Value.Month, 1, 0,0,0, new TimeSpan(-0, 0, 0));

        var (employeeCodes, employeeNamesPaymentAlreadyExist) =
            _paymentService.GenerateCodesToEmails(paymentDate, employeeToGenerateCode);

        _paymentEmailService.SendPaymentCodes(employeeCodes);

        if (employeeNamesPaymentAlreadyExist.Any())
        {
            MessageBox.Show($"Payment code already exist for: {string.Join(",", employeeNamesPaymentAlreadyExist)}");
        }

        MessageBox.Show("Emails sent.");
    }
}