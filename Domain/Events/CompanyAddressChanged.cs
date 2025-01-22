using Domain.Entities;

namespace Domain.Events;

public class CompanyAddressChanged
{
    public Guid CompanyId { get; }
    public Address OldAddress { get; }
    public Address NewAddress { get; }
    public DateTime ChangedAt { get; }

    public CompanyAddressChanged(Guid companyId, Address oldAddress, Address newAddress, DateTime changedAt)
    {
        CompanyId = companyId;
        OldAddress = oldAddress;
        NewAddress = newAddress;
        ChangedAt = changedAt;
    }
}
