namespace NovaCode_Web_Services.Navigation.Interfaces.REST.Resources;

public record VehicleResource(int id, string model, string brand, string year, string description, string image, int price, string publishedDate);