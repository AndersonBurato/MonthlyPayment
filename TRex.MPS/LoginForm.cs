using TRex.MPS.Login.Service;

namespace TRex.MPS;

public partial class LoginForm : Form
{
    public LoginForm(ILoginService loginService)
    {
        InitializeComponent();
        _loginService = loginService;
    }

    public bool IsAuthentiated { get; set; }
    private ILoginService _loginService { get; }

    private void LoginButton_Click(object sender, EventArgs e)
    {
        Global.profile = _loginService.Login(UserNameText.Text, PasswordText.Text);

        if (Global.profile is null)
        {
            MessageBox.Show("Authentication Fail. User name or Password do not match");
            return;
        }

        IsAuthentiated = true;

        Close();
    }
}