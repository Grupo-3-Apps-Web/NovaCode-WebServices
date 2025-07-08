using NovaCode_Web_Services.IAM.Domain.Model.Aggregates;
using NovaCode_Web_Services.Navigation.Domain.Model.Commands;
using NovaCode_Web_Services.Navigation.Domain.Model.Aggregate;

namespace NovaCode_Web_Services.Navigation.Domain.Model.Entities;

public partial class Review
{
    public int Id { get; }
    
    public int Score { get; private set; }
    
    public string Comment { get; private set; }
    
    public Vehicle Vehicle { get; internal set; }
    
    public int VehicleId { get; private set; }
    
    public User User { get; internal set; }
    
    public int UserId { get; private set; }
    
    public Review(int score, string comment, int vehicleId, int userId)
    {
        Score = score;
        Comment = comment;
        VehicleId = vehicleId;
        UserId = userId;
    }
    
    public Review(CreateReviewCommand command) : this(command.Score, command.Comment, command.VehicleId, command.UserId){}

    public void Update(UpdateReviewCommand command)
    {
        Score = command.Score;
        Comment = command.Comment;
        VehicleId = command.VehicleId;
        UserId = command.UserId;
    }
}