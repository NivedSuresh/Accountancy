using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Persistence.Repositories;

public class AddressRepository: IAddressRepository
{
    public Task AddAsync(Address entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Address> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Address>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Address entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}