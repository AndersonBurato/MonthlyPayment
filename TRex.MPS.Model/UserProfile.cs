using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRex.MPS.Model
{
    public record UserProfile
    {
        public int EmployeeId { get; init; }
        public string UserName { get; init; }
        public string Name { get; init; }
        public string Role { get; set; }
    }
}
