namespace Domain.Entities;

using System.Collections.Generic;

public class Company
{
    public int CompanyId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Type { get; set; }
    
    public string RegistrationNumber { get; set; }
    public string TaxId { get; set; } 
    
    public ICollection<Branch> Branches { get; set; } = new List<Branch>();
    public ICollection<ContactAssociation> ContactAssociations { get; set; } = new List<ContactAssociation>();
}

