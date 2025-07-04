namespace NovaCode_Web_Services.Navigation.Interfaces.REST.Resources;

public record VehicleResource(int Id, string Model, string Brand, int Year, string Description, string Image, double Price, int Rating);