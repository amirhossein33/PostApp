namespace PostApp.Api.Contract.Missions;

public class CreateMissionResponseDto
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public int MissionId { get; set; }
}