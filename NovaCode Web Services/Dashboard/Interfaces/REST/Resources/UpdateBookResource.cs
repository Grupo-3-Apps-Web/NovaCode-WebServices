namespace NovaCode_Web_Services.Dashboard.Interfaces.REST.Resources;

public record UpdateBookResource(string Model, string Brand, string Year, string Description, string Image,
    int Price, string Rating);