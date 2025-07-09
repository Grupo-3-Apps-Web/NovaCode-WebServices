using NovaCode_Web_Services.Navigation.Domain.Model.Entities;
using NovaCode_Web_Services.Navigation.Domain.Model.Commands;

namespace NovaCode_Web_Services.Navigation.Domain.Services;

public interface IReviewCommandService
{
    Task<Review?> Handle(CreateReviewCommand command);
    Task<Review?> Handle(UpdateReviewCommand command);
}