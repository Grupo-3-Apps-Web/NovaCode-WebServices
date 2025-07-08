namespace NovaCode_Web_Services.Profile.Interfaces.REST.Resources;

public record UpdateProfileResource(
    string FullName,
    string Email,
    string Phone,
    string Address,
    string Birthday,
    string Dni,
    string ImageProfile
);