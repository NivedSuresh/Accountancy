using Domain.ValueObjects;
using FluentValidation;

namespace Application.Commands;

public class AddressValueValidator : AbstractValidator<AddressValue>
{
    public AddressValueValidator()
    {
        RuleFor(x => x.Street).NotEmpty().WithMessage("Street is required.");
        RuleFor(x => x.Street).NotNull().WithMessage("Street is required.");
        
        RuleFor(x => x.City).NotEmpty().WithMessage("City is required.");
        RuleFor(x => x.State).NotEmpty().WithMessage("State is required.");
        RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required.");

    }
}