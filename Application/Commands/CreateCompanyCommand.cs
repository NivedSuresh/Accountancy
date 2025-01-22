using Application.DTOs;
using MediatR;

namespace Application.Commands;


/**
 * Definition: A request to perform an action or modify the state of the system.
 * Purpose:
 *  - Change the application's state.
 *  - Typically involves write operations like creating, updating, or deleting data.
 */


public class CreateCompanyCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public AddressDTO Address { get; set; }

    public CreateCompanyCommand(string name, AddressDTO address)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }
}

