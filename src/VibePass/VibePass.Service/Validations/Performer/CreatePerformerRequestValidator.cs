using FluentValidation;
using VibePass.Core.Models.Performer;

namespace VibePass.Service.Validations.Performer;

public class CreatePerformerRequestValidator : AbstractValidator<CreatePerformerRequest>
{
    public CreatePerformerRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("LastName is required");

        RuleFor(x => x.About)
            .MaximumLength(500)
            .WithMessage("About must not exceed 500 characters");
    }
}
