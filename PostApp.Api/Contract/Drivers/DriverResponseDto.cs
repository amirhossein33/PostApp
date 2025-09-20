namespace PostApp.Api.Contract.Drivers;

public class DriverResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string DriverNumber { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? LastLoginAt { get; set; }
    public bool IsRunning { get; set; }
    public bool Active { get; set; }
    public int MissionCount { get; set; }
}