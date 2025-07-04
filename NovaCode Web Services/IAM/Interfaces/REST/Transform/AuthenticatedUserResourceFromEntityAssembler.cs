using NovaCode_Web_Services.IAM.Domain.Model.Aggregates;
using NovaCode_Web_Services.IAM.Interfaces.REST.Resources;

namespace NovaCode_Web_Services.IAM.Interfaces.REST.Transform;

/// <summary>
/// Assembler for <see cref="AuthenticatedUserResource"/> from <see cref="User"/> 
/// </summary>
public static class AuthenticatedUserResourceFromEntityAssembler
{
    /// <summary>
    /// Assembles <see cref="AuthenticatedUserResource"/> from <see cref="User"/> 
    /// </summary>
    /// <param name="user">
    /// <see cref="User"/> User entity
    /// </param>
    /// <param name="token">
    /// <see cref="string"/> Token
    /// </param>
    /// <returns>
    /// <see cref="AuthenticatedUserResource"/> Authenticated user resource
    /// </returns>
    public static AuthenticatedUserResource ToResourceFromEntity(User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Username, token);
    }
    
}