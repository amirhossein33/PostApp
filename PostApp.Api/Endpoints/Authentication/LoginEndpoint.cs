using MediatR;
using Microsoft.AspNetCore.Mvc;
using PostApp.Api.Common;
using PostApp.Api.Contract;
using PostApp.Api.Contract.Authentication;
using PostApp.Application.Features.Authentication.Commands.Login;
using PostApp.Domain.Constants;

namespace PostApp.Api.Endpoints.Authentication;

public static class LoginEndpoint
{
    public class EndPoint : BaseEndpoint, IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost($"{ApiInfo.Prefix}/auth/login", handler: async (
                IMediator mediator,
                [FromBody] LoginRequestDto request,
                HttpContext context
            ) =>
            {
                try
                {
                    var command = new LoginCommand
                    {
                        Username = request.Username,
                        Password = request.Password,
                        Role = request.Role
                    };

                    var result = await mediator.Send(command);

                    var response = new LoginResponseDto
                    {
                        Token = result.Token,
                        RefreshToken = result.RefreshToken,
                        ExpiresAt = result.ExpiresAt,
                        Role = result.Role,
                        Username = result.Username,
                        UserId = result.UserId,
                        Name = result.Name,
                        Success = true,
                        Message = "Login successful"
                    };

                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Login failed: {ex.Message}");
                }
            })
            .WithTags(ApiInfo.Tag)
            .WithName("Login")
            .WithSummary("User login")
            .WithDescription("Authenticate user and return JWT token");
        }
    }
}