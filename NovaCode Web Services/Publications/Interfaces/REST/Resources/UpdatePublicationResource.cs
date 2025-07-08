namespace NovaCode_Web_Services.Publications.Interfaces.REST.Resources;

public record UpdatePublicationResource(string Model, 
    string Brand, 
    string Year, 
    string Description, string Image, int Price, string PublishedDate);