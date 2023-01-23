namespace TRex.MPS.Model;

public record UserProfile
{
    public int EmployeeId { get; init; }
    public string UserName { get; init; }
    public string Name { get; init; }
    public string Role { get; set; }
}