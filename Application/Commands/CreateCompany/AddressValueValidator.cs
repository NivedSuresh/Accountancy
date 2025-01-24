using Domain.ValueObjects;
using FluentValidation;

namespace Application.Commands;

public class AddressValueValidator : AbstractValidator<AddressValue>
{
    public AddressValueValidator()
    {
    }
}