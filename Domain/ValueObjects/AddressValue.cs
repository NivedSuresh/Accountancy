using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public class AddressValue
{
    public string Street { get; }
    
    public string City { get; }
        
    public string State { get; }
        
    public string Country { get; }

    // Constructor to initialize the Address
    public AddressValue(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }
        
}