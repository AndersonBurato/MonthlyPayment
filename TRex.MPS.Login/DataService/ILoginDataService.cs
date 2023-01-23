using TRex.MPS.Login.Model;

namespace TRex.MPS.Login.DataService;

public interface ILoginDataService
{
    IEnumerable<UserLoginRecord> GetUserBy(string userName, string password);
}