using MediatR;
using Microsoft.AspNetCore.Mvc;
using PostApp.Api.Common;
using PostApp.Api.Contract;
using PostApp.Api.Contract.Missions;
using PostApp.Application.Features.Missions.Commands.CreateMission;
using System.Security.Claims;

namespace PostApp.Api.Endpoints.Missions;

public static class CreateMissionEndpoint
{
    public class EndPoint : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost($"{ApiInfo.Prefix}/missions", handler: async (
                IMediator mediator,
                [FromBody] CreateMissionRequestDto request,
                HttpContext context
            ) =>
            {
                try
                {
                    var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier);
                    var roleClaim = context.User.FindFirst(ClaimTypes.Role);

                    if (userIdClaim == null || roleClaim?.Value != "Manager")
                    {
                        return Unauthorized("Only managers can create missions");
                    }

                    if (!int.TryParse(userIdClaim.Value, out int managerId))
                    {
                        return BadRequest("Invalid manager ID");
                    }

                    var command = new CreateMissionCommand
                    {
                        Description = request.Description,
                        Origin = request.Origin,
                        Destination = request.Destination,
                        DriverId = request.DriverId,
                        ManagerId = managerId
                    };

                    var result = await mediator.Send(command);

                    var response = new CreateMissionResponseDto
                    {
                        Success = result.Success,
                        Message = result.Message,
                        MissionId = result.MissionId
                    };

                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Mission creation failed: {ex.Message}");
                }
            })
            .WithTags(ApiInfo.Tag)
            .WithName("CreateMission")
            .WithSummary("Create Mission")
            .WithDescription("Create a new mission and assign it to a driver");
        }
    }
}