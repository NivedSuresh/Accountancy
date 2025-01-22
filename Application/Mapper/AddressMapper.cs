using Application.DTOs;
using Domain.Entities;

namespace Application.Mapper;

public class AddressMapper
{
    public static AddressDTO ToDTO(Address address)
    {
        return new AddressDTO(address.Id, address.Street, address.City, address.State, address.Country);
    }
    
    public static Address ToEntity(AddressDTO addressDTO)
    {
        return new Address(addressDTO.id, addressDTO.Street, addressDTO.City, addressDTO.State, addressDTO.Country);
    }
}