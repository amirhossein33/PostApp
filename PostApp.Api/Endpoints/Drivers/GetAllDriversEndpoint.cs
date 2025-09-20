using MediatR;
using PostApp.Api.Common;
using PostApp.Api.Contract;
using PostApp.Api.Contract.Drivers;
using PostApp.Application.Features.Drivers.Queries.GetAllDrivers;
using System.Security.Claims;

namespace PostApp.Api.Endpoints.Drivers;

public static class GetAllDriversEndpoint
{
    public class EndPoint : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet($"{ApiInfo.Prefix}/drivers", handler: async (
                IMediator mediator,
                HttpContext context
            ) =>
            {
                try
                {
                    var roleClaim = context.User.FindFirst(ClaimTypes.Role);

                    if (roleClaim?.Value != "Manager")
                    {
                        return Unauthorized("Only managers can view all drivers");
                    }

                    var query = new GetAllDriversQuery();
                    var result = await mediator.Send(query);

                    var response = new GetAllDriversResponseDto
                    {
                        Drivers = result.Drivers.Select(d => new DriverResponseDto
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
                            MissionCount = d.MissionCount
                        })
                    };

                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Failed to retrieve drivers: {ex.Message}");
                }
            })
            .WithTags(ApiInfo.Tag)
            .WithName("GetAllDrivers")
            .WithSummary("Get All Drivers")
            .WithDescription("Retrieve all drivers in the system");
        }
    }
}