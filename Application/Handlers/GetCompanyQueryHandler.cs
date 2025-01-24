using Application.DTOs;
using Application.Queries;
using Domain.Entities;
using MediatR;

namespace Application.Handlers;

public class GetCompanyQueryHandler :IRequestHandler<GetCompanyQuery, CompanyDTO>
{
    public Task<CompanyDTO> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}