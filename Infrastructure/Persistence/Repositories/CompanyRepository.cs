using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly ApplicationDbContext _context;

    public CompanyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task AddAsync(Company entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Company> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Company>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Company entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}