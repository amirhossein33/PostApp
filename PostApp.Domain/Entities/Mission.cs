namespace PostApp.Domain.Entities;

public class Mission : BaseEntity
{
    public string Description { get; set; } = string.Empty;
    public required string Origin { get; set; }
    public required string Destination { get; set; }
    public DateTime CreatedDatetime { get; set; }
    public int ManagerId { get; set; }
    public int DriverId { get; set; }
    public required Manager Manager { get; set; }
    public required Driver Driver { get; set; }
}
