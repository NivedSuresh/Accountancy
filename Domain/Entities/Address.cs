namespace Domain.Entities;

public class Address
{
    public Guid? Id { get; private set; } // Add a primary key
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }


    private Address() { } // Parameterless constructor for EF Core

    public Address(Guid? id, string street, string city, string state, string country)
    {
        Id = id;
        Street = street;
        City = city;
        State = state;
        Country = country;
    }
}
