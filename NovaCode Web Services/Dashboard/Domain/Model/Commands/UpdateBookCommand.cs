namespace NovaCode_Web_Services.Dashboard.Domain.Model.Commands;

public record UpdateBookCommand(
    string Model,
    string Brand,
    string Year,
    string Description,
    string Image,
    int Price,
    string Rating
    );