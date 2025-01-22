using Domain.Entities;

namespace Domain.Services;



public class CompanyAddressService
{
    
    /**
     * Check if the company resides in the provided country
     */
    public bool IsCompanyInCountry(Company company, string country)
    {
        if (company == null)
            throw new ArgumentNullException(nameof(company));
        
        return string.Equals(company.Address.Country, country, StringComparison.OrdinalIgnoreCase);
    }

    /**
     * Check if both companies are from same city
     */
    public bool AreCompaniesInSameCity(Company company1, Company company2)
    {
        if (company1 == null || company2 == null)
            throw new ArgumentNullException("Companies cannot be null.");
        
        return string.Equals(company1.Address.City, company2.Address.City, StringComparison.OrdinalIgnoreCase);
    }

    /**
     * Update the company with the new provided address
     */
    public Company UpdateCompanyAddress(Company company, Address newAddress)
    {
        if (company == null)
            throw new ArgumentNullException(nameof(company));
        if (newAddress == null)
            throw new ArgumentNullException(nameof(newAddress));

        return new Company(company.Id, company.Name, newAddress);
    }

    /**
     * Return company address as string
     */
    public string GetFullAddress(Company company)
    {
        if (company == null)
            throw new ArgumentNullException(nameof(company));
        
        return $"{company.Address.Street}, {company.Address.City}, {company.Address.State}, {company.Address.Country}";
    }
}
