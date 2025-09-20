using FluentValidation;

namespace PostApp.Application.Features.Missions.Commands.CreateMission;

public class CreateMissionCommandValidator : AbstractValidator<CreateMissionCommand>
{
    public CreateMissionCommandValidator()
    {
        RuleFor(x => x.Origin)
            .NotEmpty()
            .WithMessage("Origin is required")
            .MaximumLength(200)
            .WithMessage("Origin must not exceed 200 characters");

        RuleFor(x => x.Destination)
            .NotEmpty()
            .WithMessage("Destination is required")
            .MaximumLength(200)
            .WithMessage("Destination must not exceed 200 characters");

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .WithMessage("Description must not exceed 500 characters");

        RuleFor(x => x.DriverId)
            .GreaterThan(0)
            .WithMessage("Valid Driver ID is required");

        RuleFor(x => x.ManagerId)
            .GreaterThan(0)
            .WithMessage("Valid Manager ID is required");
    }
}