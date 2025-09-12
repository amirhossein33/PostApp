namespace PostApp.Domain.Entities;

public class Driver : BaseEntity
{
    public required string Name { get; set; }
    public required string DriverNumber { get; set; }
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? LastLoginAt { get; set; }
    public bool IsRunning { get; set; }
    public bool Active { get; set; }
    public ICollection<Mission> Missions { get; set; } = new List<Mission>();
}
