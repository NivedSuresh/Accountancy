namespace Application.DTOs;

public class CompanyDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public AddressDTO Address { get; set; }

    public CompanyDTO() { }

    public CompanyDTO(Guid id, string name, AddressDTO address)
    {
        Id = id;
        Name = name;
        Address = address;
    }
}
