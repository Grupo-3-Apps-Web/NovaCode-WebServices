using System.Security.Claims;
using System.Text;
using NovaCode_Web_Services.IAM.Application.Internal.OutboundServices;
using NovaCode_Web_Services.IAM.Domain.Model.Aggregates;
using NovaCode_Web_Services.IAM.Infrastructure.Tokens.JWT.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace NovaCode_Web_Services.IAM.Infrastructure.Tokens.JWT.Services;

/// <summary>
/// Token service 
/// </summary>
/// <param name="tokenSettings">
/// <see cref="TokenSettings"/> Token settings
/// </param>
public class TokenService(IOptions<TokenSettings> tokenSettings) : ITokenService
{
    private readonly TokenSettings _tokenSettings = tokenSettings.Value;
    
    // <inheritdoc />
    public string GenerateToken(User user)
    {
        if (string.IsNullOrEmpty(_tokenSettings.Secret))
            throw new Exception("Token secret is not configured.");
        if (user == null) throw new ArgumentNullException(nameof(user), "User object cannot be null.");
        if (user.Id == 0) throw new Exception("User ID is invalid.");
        if (string.IsNullOrEmpty(user.Username)) throw new Exception("User username cannot be null or empty.");

        var secret = _tokenSettings.Secret;
        var key = Encoding.ASCII.GetBytes(secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            ]),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var tokenHandler = new JsonWebTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return token;
    }

    // <inheritdoc />
    public async Task<int?> ValidateToken(string token)
    {
        if (string.IsNullOrEmpty(token)) return null;
        var tokenHandler = new JsonWebTokenHandler();
        var secret = _tokenSettings.Secret;
        var key = Encoding.ASCII.GetBytes(secret);
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = true,
            ValidateLifetime = true
        };
        try
        {
            var tokenValidationResult = await tokenHandler.ValidateTokenAsync(token, tokenValidationParameters);
            if (tokenValidationResult.SecurityToken is not JsonWebToken jwtToken) return null;
            var userId = int.Parse(jwtToken.Claims.First(c => c.Type == ClaimTypes.Name).Value);
            return userId;
        }
        catch (Exception)
        {
            return null;
        }
    }
}