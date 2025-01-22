namespace Domain.Entities;

public class Company
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Guid AddressId { get; set; }
    public Address Address { get; private set; }

    private Company() { } 
    
    public Company(Guid id, string name, Address address)
    {
        Id = id;
        Name = name;
        AddressId = address.Id;
        Address = address;
    }

    public void UpdateName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Company name cannot be empty.");
        
        Name = newName;
    }
}
