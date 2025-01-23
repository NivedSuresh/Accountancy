namespace Application.Commands;

using System.ComponentModel.DataAnnotations;
using Domain.ValueObjects;
using MediatR;

/**
 * Definition: A request to perform an action or modify the state of the system.
 * Purpose:
 *  - Change the application's state.
 *  - Typically involves write operations like creating, updating, or deleting data.
 */
public class CreateCompanyCommand : IRequest<Guid>
{

    public string Name { get; set; }
    
    public AddressValue Address { get; set; }

    public CreateCompanyCommand(string name, AddressValue address)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Address = address;
    }
}

