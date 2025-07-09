using NovaCode_Web_Services.Profile.Domain.Model.Aggregate;
using NovaCode_Web_Services.Profile.Domain.Model.Commands;

namespace NovaCode_Web_Services.Profile.Domain.Services;

public interface IProfileCommandService
{
    Task<ProfileAggregate> Handle(CreateProfileCommand command);
    Task<ProfileAggregate?> Handle(int id, UpdateProfileCommand command);
    Task<bool?> Handle(DeleteProfileCommand command);
}