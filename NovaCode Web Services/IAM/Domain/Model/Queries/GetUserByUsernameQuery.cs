namespace NovaCode_Web_Services.IAM.Domain.Model.Queries;

/// <summary>
/// Get user by username query 
/// </summary>
/// <param name="Username">
/// The username to get
/// </param>
public record GetUserByUsernameQuery(string Username);