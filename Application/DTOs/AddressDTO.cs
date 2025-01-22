namespace Application.DTOs;

public class AddressDTO
{
    public Guid id { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    public AddressDTO() { }

    public AddressDTO(Guid id, string street, string city, string state, string country)
    {
        this.id = id;
        Street = street;
        City = city;
        State = state;
        Country = country;
    }
}
