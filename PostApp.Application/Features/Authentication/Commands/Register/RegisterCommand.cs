using MediatR;

namespace PostApp.Application.Features.Authentication.Commands.Register;

public class RegisterCommand : IRequest<RegisterResult>
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? ManagerNumber { get; set; }
    public string? DriverNumber { get; set; }
}