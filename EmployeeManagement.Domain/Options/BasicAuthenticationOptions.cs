namespace EmployeeManagement.Domain.Options;

public class BasicAuthenticationOptions
{
    public const string SectionName = "BasicAuthentication";
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
}