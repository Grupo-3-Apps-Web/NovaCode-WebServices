using NovaCode_Web_Services.IAM.Interfaces.REST.Resources;

namespace NovaCode_Web_Services.Navigation.Interfaces.REST.Resources;

public record ReservationResource(int Id, UserResource User, VehicleResource Vehicle, DateTime ReservationTime);