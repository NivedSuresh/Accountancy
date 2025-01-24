using Application.DTOs;
using Domain.Entities;
using MediatR;

namespace Application.Queries;


/**
 * Definition: A request to retrieve data or information from the system without changing its state.
 *   Purpose:
 *      - Fetch or read data.
 *      - Typically involves read operations.
 */
public class GetCompanyQuery : IRequest<CompanyDTO>
{
    public Guid CompanyId { get; set; }

    public GetCompanyQuery(Guid companyId)
    {
        CompanyId = companyId;
    }
}
