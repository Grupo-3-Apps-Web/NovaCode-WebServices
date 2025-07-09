namespace NovaCode_Web_Services.Navigation.Domain.Model.Commands;

public record UpdateReviewCommand(int Id, int Score, string Comment, int VehicleId, int UserId);