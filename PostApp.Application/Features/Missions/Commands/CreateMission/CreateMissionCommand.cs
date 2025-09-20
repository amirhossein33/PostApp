using MediatR;

namespace PostApp.Application.Features.Missions.Commands.CreateMission;

public class CreateMissionCommand : IRequest<CreateMissionResult>
{
    public string Description { get; set; } = string.Empty;
    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public int DriverId { get; set; }
    public int ManagerId { get; set; }
}