using System.Text;
using TRex.MPS.Model.Payment;

namespace TRex.MPS.Payment.Service
{
    public class PaymentEMailService : IPaymentEMailService
    {
        private string[,] magnifiedNumbers =
        {
            { "  _ ", "   ", "  _ ", " _ ", "    ", "  _ ", "  _ ", " _ ", "  _ ", "  _ " },
            { " | |", " | ", "  _|", " _|", " |_|", " |_ ", " |_ ", "  |", " |_|", " |_|" },
            { " |_|", " | ", " |_ ", " _|", "   |", "  _|", " |_|", "  |", " |_|", "  _|" }
        };

        private const string MonthHeader = "Month";
        private const string EmployeeHeader = "Employee";
        private const string CodeHeader = "Code";
        private const string SalaryHeader = "Salary";

        public void SendPaymentCodes(List<EmployeePaymentCode> paymentCodes)
        {
            foreach (var paymentCode in paymentCodes)
            {
                var Body = new StringBuilder();

                var month = paymentCode.PaymentDate.Date.ToString("MMM/yyyy");
                var salary = paymentCode.Salary.ToString("c");
                var paddedName = paymentCode.EmployeeName.PadRight(paymentCode.EmployeeName.Length);
                var paddedCode = paymentCode.Code.PadRight(paymentCode.Code.Length);
                var paddedSalary = paymentCode.Salary.ToString("c").PadRight(salary.Length);

                var magnifiedCodeLine1 = MagnifyCodeLine(0, paymentCode.Code);
                var magnifiedCodeLine2 = MagnifyCodeLine(1, paymentCode.Code);
                var magnifiedCodeLine3 = MagnifyCodeLine(2, paymentCode.Code);

                Body.AppendLine(
                    $"|-{string.Empty.PadRight(20, '-')}-|-{string.Empty.PadRight(paddedName.Length, '-')}-|-{string.Empty.PadRight(magnifiedCodeLine1.Length, '-')}-|-{string.Empty.PadRight(paddedSalary.Length, '-')}-|");
                Body.AppendLine(
                    $"| {MonthHeader.PadRight(20)} | {EmployeeHeader.PadRight(paddedName.Length)} | {CodeHeader.PadRight(magnifiedCodeLine1.Length)} | {SalaryHeader.PadRight(paddedSalary.Length)} |");
                Body.AppendLine(
                    $"| {String.Empty.PadRight(20, ' ')} | {string.Empty.PadRight(paddedName.Length, ' ')} | {magnifiedCodeLine1} | {string.Empty.PadRight(paddedSalary.Length, ' ')} |");
                Body.AppendLine(
                    $"| {month.PadRight(20)} | {paymentCode.EmployeeName} | {magnifiedCodeLine2} | {paddedSalary} |");
                Body.AppendLine(
                    $"| {String.Empty.PadRight(20, ' ')} | {string.Empty.PadRight(paddedName.Length, ' ')} | {magnifiedCodeLine3} | {string.Empty.PadRight(paddedSalary.Length, ' ')} |");
                Body.AppendLine(
                    $"|-{string.Empty.PadRight(20, '-')}-|-{string.Empty.PadRight(paddedName.Length, '-')}-|-{string.Empty.PadRight(magnifiedCodeLine3.Length, '-')}-|-{string.Empty.PadRight(paddedSalary.Length, '-')}-|");

                File.WriteAllText($"{paymentCode.EmployeeName}.txt", Body.ToString());

                //todo:send email
            }
        }

        private StringBuilder MagnifyCode(string code)
        {
            var magnifiedCode = new StringBuilder();

            for (int lineNumber = 0; lineNumber < 3; lineNumber++)
            {
                magnifiedCode.AppendLine(MagnifyCodeLine(lineNumber, code));
            }

            return magnifiedCode;
        }

        private string MagnifyCodeLine(int line, string code)
        {
            var magnifiedCode = new StringBuilder();

            foreach (char c in code)
            {
                magnifiedCode.Append(magnifiedNumbers[line, int.Parse(c.ToString())]);
            }

            return magnifiedCode.ToString();
        }
    }
}