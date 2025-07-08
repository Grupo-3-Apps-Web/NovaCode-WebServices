namespace NovaCode_Web_Services.Publications.Interfaces.REST.Resources;

public record CreatePublicationResource(
    string Model, 
    string Brand, 
    string Year, 
    string Description, string Image, int Price, string PublishedDate);