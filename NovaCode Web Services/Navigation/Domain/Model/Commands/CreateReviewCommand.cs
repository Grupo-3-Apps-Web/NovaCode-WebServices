namespace NovaCode_Web_Services.Navigation.Domain.Model.Commands;

public record CreateReviewCommand(int Score, string Comment, int VehicleId, int UserId);