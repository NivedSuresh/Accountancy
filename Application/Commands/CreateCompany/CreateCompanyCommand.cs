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
    
}

