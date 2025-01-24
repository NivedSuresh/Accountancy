namespace Domain.Entities;


public class Branch
{
    public int BranchId { get; set; }
    public string Name { get; set; }
    
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    
    public bool IsActive { get; set; } = true;
    
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
    public ICollection<ContactAssociation> ContactAssociations { get; set; } = new List<ContactAssociation>();
}