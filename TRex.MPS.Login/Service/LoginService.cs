using TRex.MPS.Login.DataService;
using TRex.MPS.Model;

namespace TRex.MPS.Login.Service;

public class LoginService : ILoginService
{
    private readonly ILoginDataService _loginDataService;

    public LoginService(ILoginDataService loginDataService)
    {
        _loginDataService = loginDataService;
    }

    public UserProfile? Login(string username, string password)
    {
        UserProfile? profile = null;

        var result = _loginDataService.GetUserBy(username, password);


        if (result.Count() > 0)
        {
            var profileFound = result.First();

            profile = new UserProfile
            {
                EmployeeId = profileFound.Id,
                UserName = profileFound.UserName,
                Name = profileFound.UserName,
                Role = profileFound.Role
            };
        }

        return profile;
    }
}