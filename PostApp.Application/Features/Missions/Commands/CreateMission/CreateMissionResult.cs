namespace PostApp.Application.Features.Missions.Commands.CreateMission;

public class CreateMissionResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public int MissionId { get; set; }
}