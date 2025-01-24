namespace Domain.Entities;


public class Address
{
    public int AddressId { get; set; }
    
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    
    public decimal? Latitude { get; set; } // GPS latitude
    public decimal? Longitude { get; set; } // GPS longitude
    
    public int BranchId { get; set; }
    public Branch Branch { get; set; }
}