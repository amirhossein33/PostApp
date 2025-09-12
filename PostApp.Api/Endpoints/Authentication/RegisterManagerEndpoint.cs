using MediatR;
using Microsoft.AspNetCore.Mvc;
using PostApp.Api.Common;
using PostApp.Api.Contract;
using PostApp.Api.Contract.Authentication;
using PostApp.Application.Features.Authentication.Commands.Register;
using PostApp.Domain.Constants;

namespace PostApp.Api.Endpoints.Authentication;

public static class RegisterManagerEndpoint
{
    public class EndPoint : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost($"{ApiInfo.Prefix}/auth/register/manager", handler: async (
                IMediator mediator,
                [FromBody] RegisterManagerRequestDto request,
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
                        Role = UserRoles.Manager,
                        ManagerNumber = request.ManagerNumber
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
                    return BadRequest($"Manager registration failed: {ex.Message}");
                }
            })
            .WithTags(ApiInfo.Tag)
            .WithName("RegisterManager")
            .WithSummary("Register Manager")
            .WithDescription("Register a new manager in the system");
        }
    }
}