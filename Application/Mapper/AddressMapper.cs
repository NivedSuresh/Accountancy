using Application.DTOs;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Mapper;

public class AddressMapper
{
    public static AddressDTO ToDTO(Address address)
    {
        return new AddressDTO(address.Id ?? Guid.Empty, address.Street, address.City, address.State, address.Country);
    }
    
    public static Address ToEntity(AddressValue addressValue)
    {
        return new Address(null, addressValue.Street, addressValue.City, addressValue.State, addressValue.Country);
    }

    public static Address ToEntity(AddressDTO addressDto)
    {
        return new Address(addressDto.id, addressDto.Street, addressDto.City, addressDto.State, addressDto.Country);
    }
}