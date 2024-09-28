using FluentValidation;
using VibePod.Core.Models.Request;

namespace VibePod.Service.Validators;

public class CreatePlanRequestValidator : AbstractValidator<CreatePlanRequest>
{
    public CreatePlanRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
                .WithMessage("{PropertyName} boş olamaz.");

        RuleFor(x => x.Description)
            .MaximumLength(500)
                .WithMessage("Description can be maximum 500 characters");

        RuleFor(x => x.Price)
            .NotEmpty()
                .WithMessage("Price is required")
            .GreaterThanOrEqualTo(0)
                .WithMessage("Price must be greater than or equal to 0");
    }
}
