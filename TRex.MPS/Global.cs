using TRex.MPS.Model;

namespace TRex.MPS;

public static class Global
{
    public static UserProfile? profile = null;

    public static class Roles 
    { 
        public const string HR = "hr";
        public const string Employee = "employee";
    }
}