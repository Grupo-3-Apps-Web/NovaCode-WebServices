namespace NovaCode_Web_Services.Profile.Domain.Model.Commands;

public record UpdateProfileCommand(
    string FullName,
    string Email,
    string Phone,
    string Address,
    string Birthday,
    string Dni,
    string ImageProfile
);