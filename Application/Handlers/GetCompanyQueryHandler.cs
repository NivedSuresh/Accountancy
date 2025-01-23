using System.Net;
using Application.DTOs;
using Application.Mapper;
using Application.Queries;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers;

public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, CompanyDTO>
{
    private readonly ICompanyRepository _companyRepository;

    public GetCompanyQueryHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }
    

    public async Task<CompanyDTO> Handle(GetCompanyQuery query, CancellationToken cancellationToken)
    {
        if (Guid.Empty == query.CompanyId || query.CompanyId.ToString().StartsWith("0"))
        {
            throw new GlobalException("Invalid companyId", HttpStatusCode.BadRequest, ErrorCode.INVALID_PAYLOAD);
        }
        
        var company = await _companyRepository.GetByIdAsync(query.CompanyId);

        if (company == null)
            throw new KeyNotFoundException("Company not found.");

        return CompanyMapper.ToDTO(company);
    }
}
