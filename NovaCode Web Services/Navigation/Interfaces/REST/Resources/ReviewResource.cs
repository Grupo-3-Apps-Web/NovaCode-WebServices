using NovaCode_Web_Services.IAM.Interfaces.REST.Resources;

namespace NovaCode_Web_Services.Navigation.Interfaces.REST.Resources;

public record ReviewResource(int Id, int Score, string Comment, VehicleResource Vehicle, UserResource User);