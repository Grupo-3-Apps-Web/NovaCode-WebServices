using NovaCode_Web_Services.IAM.Domain.Model.Aggregates;
using NovaCode_Web_Services.Navigation.Domain.Model.Aggregate;

namespace NovaCode_Web_Services.Navigation.Domain.Model.Entities;

public class Reservation
{
    public int Id { get; set; }
    
    public User User { get; set; }
    public int UserId { get; set; }
    public DateTime ReservedAt { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
}