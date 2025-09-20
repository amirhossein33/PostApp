namespace PostApp.Api.Contract.Missions;

public class CreateMissionRequestDto
{
    public string Description { get; set; } = string.Empty;
    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public int DriverId { get; set; }
}