using FluentValidation;
using VibePass.Core.Models.Ticket;

namespace VibePass.Service.Validations;

public sealed class UpdateTicketRequestValidator : AbstractValidator<UpdateTicketRequest>
{
    public UpdateTicketRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
                .WithMessage("Name is required.");
        RuleFor(x => x.Price)
            .NotEmpty()
                .WithMessage("Price is required.");
        RuleFor(x => x.Quantity)
            .NotEmpty()
                .WithMessage("Quantity is required.");

        RuleFor(x => x.Description)
            .MaximumLength(500)
                .WithMessage("Description must not exceed 500 characters.");

    }
}
