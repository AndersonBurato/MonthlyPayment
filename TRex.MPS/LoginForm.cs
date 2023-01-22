using TRex.MPS.Login.Service;

namespace TRex.MPS;

public partial class LoginForm : Form
{
    public bool IsAuthentiated { get; set; } = false;
    private ILoginService _loginService { get; }

    public LoginForm(ILoginService loginService)
    {
        InitializeComponent();
        _loginService = loginService;
    }

    private void LoginButton_Click(object sender, EventArgs e)
    {
        Global.profile = _loginService.Login(UserNameText.Text, PasswordText.Text);

        if (Global.profile is null)
        {
            MessageBox.Show("Authentication Fail. User name or Password do not match");
            return;
        }

        this.Close();
    }
}