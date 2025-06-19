namespace NovaCode_Web_Services.Publications.Domain.Model.Commands;

public record CreatePublicationCommand(
    string Model,
    string Brand,
    string Year,
    string Description,
    string Image,
    int Price,
    string PublishedDate
    );