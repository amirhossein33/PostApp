using FluentValidation;
using PostApp.Domain.Constants;

namespace PostApp.Application.Features.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("Username is required")
            .MinimumLength(3)
            .WithMessage("Username must be at least 3 characters")
            .MaximumLength(50)
            .WithMessage("Username cannot exceed 50 characters");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(6)
            .WithMessage("Password must be at least 6 characters")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)")
            .WithMessage("Password must contain at least one lowercase letter, one uppercase letter, and one digit");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Email must be a valid email address");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .MinimumLength(2)
            .WithMessage("Name must be at least 2 characters")
            .MaximumLength(100)
            .WithMessage("Name cannot exceed 100 characters");

        RuleFor(x => x.Role)
            .NotEmpty()
            .WithMessage("Role is required")
            .Must(role => UserRoles.AllRoles.Contains(role))
            .WithMessage($"Role must be one of: {string.Join(", ", UserRoles.AllRoles)}");

        RuleFor(x => x.ManagerNumber)
            .NotEmpty()
            .WithMessage("Manager number is required")
            .When(x => x.Role == UserRoles.Manager);

        RuleFor(x => x.DriverNumber)
            .NotEmpty()
            .WithMessage("Driver number is required")
            .When(x => x.Role == UserRoles.Driver);
    }
}