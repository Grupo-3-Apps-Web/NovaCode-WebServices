using NovaCode_Web_Services.Navigation.Domain.Model.Commands;
using NovaCode_Web_Services.Navigation.Interfaces.REST.Resources;

namespace NovaCode_Web_Services.Navigation.Interfaces.REST.Transform;

public class UpdateReviewCommandFromResourceAssembler
{
    public static UpdateReviewCommand ToCommandFromResource(UpdateReviewResource resource)
    {
        return new UpdateReviewCommand(resource.Id, resource.Score, resource.Comment, resource.VehicleId, resource.UserId);
    }
}