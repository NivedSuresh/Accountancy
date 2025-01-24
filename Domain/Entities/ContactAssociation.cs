namespace Domain.Entities;


public class ContactAssociation
{
    public int ContactAssociationId { get; set; }
    
    public int ContactId { get; set; }
    public Contact Contact { get; set; }
    
    public int? CompanyId { get; set; }
    public Company Company { get; set; }
    
    public int? BranchId { get; set; }
    public Branch Branch { get; set; }
}