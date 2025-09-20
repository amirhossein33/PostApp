using MediatR;
using PostApp.Application.Common.Exceptions;
using PostApp.Application.Interfaces.Repositories;
using PostApp.Domain.Constants;
using PostApp.Domain.Entities;

namespace PostApp.Application.Features.Missions.Commands.CreateMission;

public class CreateMissionCommandHandler : IRequestHandler<CreateMissionCommand, CreateMissionResult>
{
    private readonly IMissionRepository _missionRepository;
    private readonly IDriverRepository _driverRepository;
    private readonly IManagerRepository _managerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateMissionCommandHandler(
        IMissionRepository missionRepository,
        IDriverRepository driverRepository,
        IManagerRepository managerRepository,
        IUnitOfWork unitOfWork)
    {
        _missionRepository = missionRepository;
        _driverRepository = driverRepository;
        _managerRepository = managerRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateMissionResult> Handle(CreateMissionCommand request, CancellationToken cancellationToken)
    {
        // Validate manager exists
        var manager = await _managerRepository.GetByIdAsync(request.ManagerId, cancellationToken);
        if (manager == null)
        {
            throw new ValidationException("Manager not found");
        }

        if (!manager.IsActive)
        {
            throw new ValidationException("Manager is not active");
        }

        // Validate driver exists
        var driver = await _driverRepository.GetByIdAsync(request.DriverId, cancellationToken);
        if (driver == null)
        {
            throw new ValidationException("Driver not found");
        }

        if (!driver.Active)
        {
            throw new ValidationException("Driver is not active");
        }

        // Create mission
        var mission = new Mission
        {
            Description = request.Description,
            Origin = request.Origin,
            Destination = request.Destination,
            DriverId = request.DriverId,
            ManagerId = request.ManagerId,
            CreatedDatetime = DateTime.UtcNow,
            MissionStatus = MissionStatus.Pending,
            Manager = manager,
            Driver = driver
        };

        await _missionRepository.AddAsync(mission, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateMissionResult
        {
            Success = true,
            Message = "Mission created successfully",
            MissionId = mission.Id
        };
    }
}