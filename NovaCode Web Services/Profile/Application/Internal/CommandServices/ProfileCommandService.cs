using NovaCode_Web_Services.Profile.Domain.Model.Aggregate;
using NovaCode_Web_Services.Profile.Domain.Model.Commands;
using NovaCode_Web_Services.Profile.Domain.Repositories;
using NovaCode_Web_Services.Profile.Domain.Services;
using NovaCode_Web_Services.Shared.Domain.Repositories;

namespace NovaCode_Web_Services.Profile.Application.Internal.CommandServices;

public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork) : IProfileCommandService
{
    public async Task<Domain.Model.Aggregate.Profile> Handle(CreateProfileCommand command)
    {
        var user = new Domain.Model.Aggregate.Profile(
            command.FullName,
            command.Email,
            command.Phone,
            command.Address,
            command.Birthday,
            command.Dni,
            command.ImageProfile
        );
        
        try
        {
            await profileRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
            return user;
        }
        catch (Exception ex)
        {
            throw new Exception("Error creating new user", ex);
        }
    }

    public async Task<Domain.Model.Aggregate.Profile?> Handle(int id, UpdateProfileCommand command)
    {
        var user = await profileRepository.FindByIdAsync(id);

        if (user == null)
        {
            return null;
        }

        user.UpdateUser(
            command.FullName,
            command.Email,
            command.Phone,
            command.Address,
            command.Birthday,
            command.Dni,
            command.ImageProfile
        );
        
        try
        {
            await unitOfWork.UpdateAsync(user);
            await unitOfWork.CompleteAsync();

            return user;
        }
        catch (Exception ex)
        {
            throw new Exception("Error updating user info", ex);
        }
    }

    public async Task<bool?> Handle(DeleteProfileCommand command)
    {
        var user = await profileRepository.FindByIdAsync(command.Id);

        if (user == null)
        {
            return false;
        }

        try
        {
            await unitOfWork.RemoveAsync(user);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception)
        {
            return null;
        }
    }
}
