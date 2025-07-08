using NovaCode_Web_Services.IAM.Domain.Repositories;
using NovaCode_Web_Services.Navigation.Domain.Model.Entities;
using NovaCode_Web_Services.Navigation.Domain.Model.Commands;
using NovaCode_Web_Services.Navigation.Domain.Repositories;
using NovaCode_Web_Services.Navigation.Domain.Services;
using NovaCode_Web_Services.Shared.Domain.Repositories;

namespace NovaCode_Web_Services.Navigation.Application.Internal.CommandServices;

public class ReviewCommandService(IReviewRepository reviewRepository,
    IVehicleRepository vehicleRepository, IUserRepository userRepository,
    IUnitOfWork unitOfWork) : IReviewCommandService
{
    public async Task<Review?> Handle(CreateReviewCommand command)
    {
        var vehicle = await vehicleRepository.FindByIdAsync(command.VehicleId);
        if (vehicle == null) throw new Exception("Vehicle not found");
        var user = await userRepository.FindByIdAsync(command.UserId);
        if (user == null) throw new Exception("User not found");
        var review = new Review(command);
        await reviewRepository.AddAsync(review);
        await unitOfWork.CompleteAsync();
        review.Vehicle = vehicle;
        review.User = user;
        return review;
    }

    public async Task<Review?> Handle(UpdateReviewCommand command)
    {
        var review =await reviewRepository.FindByIdAsync(command.Id);
        if (review == null) throw new Exception("Review not found");
        var vehicle = await vehicleRepository.FindByIdAsync(command.VehicleId);
        if (vehicle == null) throw new Exception("Vehicle not found");
        var user = await userRepository.FindByIdAsync(command.UserId);
        if (user == null) throw new Exception("User not found");
        review.Update(command);
        await unitOfWork.CompleteAsync();
        return review;
    }
}