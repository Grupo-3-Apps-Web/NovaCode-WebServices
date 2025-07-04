using System.ComponentModel.DataAnnotations;

namespace NovaCode_Web_Services.Navigation.Interfaces.REST.Resources;

public class CreateReviewResource
{
    [Range(1,5, ErrorMessage ="The score must be between 1 and 5")]
    public int Score { get; set; }
    
    public string Comment { get; set; }
    
    public int VehicleId { get; set; }
    
    public int UserId { get; set; }
}