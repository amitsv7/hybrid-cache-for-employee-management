namespace EmployeeManagement.Domain.Options;

public class ConnectionStringOptions
{
    public const string SectionName = "ConnectionStrings";
    public string DatabaseConnection { get; set; } = null!;
    public string RedisCacheConnectionStrings { get; set; } = null!;
    
}