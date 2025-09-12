using MediatR;
using Microsoft.AspNetCore.Mvc;
using PostApp.Api.Common;
using PostApp.Api.Contract;
using PostApp.Api.Contract.Authentication;
using PostApp.Application.Features.Authentication.Commands.Register;
using PostApp.Domain.Constants;

namespace PostApp.Api.Endpoints.Authentication;

public static class RegisterDriverEndpoint
{
    public class EndPoint : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost($"{ApiInfo.Prefix}/auth/register/driver", handler: async (
                IMediator mediator,
                [FromBody] RegisterDriverRequestDto request,
                HttpContext context
            ) =>
            {
                try
                {
                    var command = new RegisterCommand
                    {
                        Username = request.Username,
                        Password = request.Password,
                        Email = request.Email,
                        Name = request.Name,
                        Role = UserRoles.Driver,
                        DriverNumber = request.DriverNumber
                    };

                    var result = await mediator.Send(command);

                    var response = new RegisterResponseDto
                    {
                        Success = result.Success,
                        Message = result.Message,
                        UserId = result.UserId
                    };

                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Driver registration failed: {ex.Message}");
                }
            })
            .WithTags(ApiInfo.Tag)
            .WithName("RegisterDriver")
            .WithSummary("Register Driver")
            .WithDescription("Register a new driver in the system");
        }
    }
}