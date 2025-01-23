using Application.Commands;
using Application.DTOs;
using Domain.Entities;

namespace Application.Mapper;

public static class CompanyMapper
{
    
    public static CompanyDTO ToDTO(Company company)
    {
        return new CompanyDTO(company.Id ?? Guid.Empty, company.Name, AddressMapper.ToDTO(company.Address));
    }
    
    public static Company ToEntity(CompanyDTO companyDTO)
    {
        return new Company(companyDTO.Id, companyDTO.Name, AddressMapper.ToEntity(companyDTO.Address));
    }

    public static Company ToEntity(CreateCompanyCommand createCompanyCommand)
    {
        var address = AddressMapper.ToEntity(createCompanyCommand.Address);
        return new Company(null, createCompanyCommand.Name, address);
    }
}
