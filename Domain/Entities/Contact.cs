namespace Domain.Entities;


public class Contact
{
    public int ContactId { get; set; }
    public string Name { get; set; }
    
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    
    public string ContactType { get; set; }
    
    // Optional: If Company
    public string RegistrationNumber { get; set; }
    public string Industry { get; set; }
    public string TaxId { get; set; }
    
    // Optional: If Individual
    public string Role { get; set; } 

    public bool IsActive { get; set; } = true;
    
    public ICollection<ContactAssociation> ContactAssociations { get; set; } = new List<ContactAssociation>();
}



