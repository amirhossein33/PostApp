namespace PostApp.Application.Features.Drivers.Queries.GetAllDrivers;

public class GetAllDriversResult
{
    public IEnumerable<DriverDto> Drivers { get; set; } = new List<DriverDto>();
}

public class DriverDto
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