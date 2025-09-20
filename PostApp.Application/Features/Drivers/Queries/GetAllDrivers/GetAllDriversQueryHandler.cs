using MediatR;
using PostApp.Application.Interfaces.Repositories;

namespace PostApp.Application.Features.Drivers.Queries.GetAllDrivers;

public class GetAllDriversQueryHandler : IRequestHandler<GetAllDriversQuery, GetAllDriversResult>
{
    private readonly IDriverRepository _driverRepository;

    public GetAllDriversQueryHandler(IDriverRepository driverRepository)
    {
        _driverRepository = driverRepository;
    }

    public async Task<GetAllDriversResult> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
    {
        var drivers = await _driverRepository.GetDriversWithMissionsAsync(cancellationToken);

        var driverDtos = drivers.Select(d => new DriverDto
        {
            Id = d.Id,
            Name = d.Name,
            DriverNumber = d.DriverNumber,
            Username = d.Username,
            Email = d.Email,
            CreatedAt = d.CreatedAt,
            LastLoginAt = d.LastLoginAt,
            IsRunning = d.IsRunning,
            Active = d.Active,
            MissionCount = d.Missions?.Count ?? 0
        });

        return new GetAllDriversResult
        {
            Drivers = driverDtos
        };
    }
}