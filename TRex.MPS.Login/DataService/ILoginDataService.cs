using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRex.MPS.Login.Model;

namespace TRex.MPS.Login.DataService
{
    public interface ILoginDataService
    {
        IEnumerable<UserLoginRecord> GetUserBy(string userName, string password);
            
    }
}
