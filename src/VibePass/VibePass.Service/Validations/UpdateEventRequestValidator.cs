using FluentValidation;
using VibePass.Core.Models.Eventy;

namespace VibePass.Service.Validations;

public sealed class UpdateEventRequestValidator : AbstractValidator<UpdateEventyRequest>
{
    public UpdateEventRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
                .WithMessage("Name is required.");
        
        RuleFor(x => x.Description)
            .MaximumLength(500)
                .WithMessage("Description must not exceed 500 characters.");
        RuleFor(x => x.StartDate)
            .NotEmpty()
                .WithMessage("StartDate is required.");
        
        RuleFor(x => x.EndDate)
            .NotEmpty()
            .WithMessage("EndDate is required.");
        
        RuleFor(x => x.Location)
            .NotEmpty()
            .WithMessage("Location is required.");

    }
}
