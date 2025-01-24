using Application.Commands;
using Application.Mapper;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers;

public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Guid>
{
    private readonly ICompanyRepository _companyRepository;

    public CreateCompanyCommandHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<Guid> Handle(CreateCompanyCommand createCompany, CancellationToken cancellationToken)
    {
        return Guid.Empty;
    }
}


