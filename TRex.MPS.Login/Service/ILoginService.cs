using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRex.MPS.Model;

namespace TRex.MPS.Login.Service
{
    public interface ILoginService
    {
        UserProfile? Login(string username, string password);
    }
}
