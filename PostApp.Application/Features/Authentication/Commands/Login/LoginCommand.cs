using MediatR;

namespace PostApp.Application.Features.Authentication.Commands.Login;

public class LoginCommand : IRequest<LoginResult>
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
}