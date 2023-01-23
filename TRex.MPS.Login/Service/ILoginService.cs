using TRex.MPS.Model;

namespace TRex.MPS.Login.Service;

public interface ILoginService
{
    UserProfile? Login(string username, string password);
}