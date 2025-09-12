namespace PostApp.Application.Features.Authentication.Commands.Register;

public class RegisterResult
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public int UserId { get; set; }
}