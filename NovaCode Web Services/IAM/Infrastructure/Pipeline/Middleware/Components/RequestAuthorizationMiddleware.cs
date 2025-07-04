using NovaCode_Web_Services.IAM.Application.Internal.OutboundServices;
using NovaCode_Web_Services.IAM.Domain.Model.Queries;
using NovaCode_Web_Services.IAM.Domain.Services;
using NovaCode_Web_Services.IAM.Infrastructure.Pipeline.Middleware.Attributes;

namespace NovaCode_Web_Services.IAM.Infrastructure.Pipeline.Middleware.Components;

/// <summary>
/// Request authorization middleware
/// </summary>
/// <param name="next">
/// <see cref="RequestDelegate"/> Next middleware in pipeline
/// </param>
public class RequestAuthorizationMiddleware(RequestDelegate next)
{
    /// <summary>
    /// Invoke middleware 
    /// </summary>
    public async Task InvokeAsync(
        HttpContext context,
        IUserQueryService userQueryService,
        ITokenService tokenService)
    {
        Console.WriteLine("➡️ RequestAuthorizationMiddleware: Start");

        var endpoint = context.Request.HttpContext.GetEndpoint();
        var allowAnonymous = endpoint?.Metadata.Any(m => m.GetType() == typeof(AllowAnonymousAttribute)) ?? false;

        var path = context.Request.Path.Value?.ToLower() ?? "";

        var isSwaggerRequest =
            path.StartsWith("/swagger") ||
            path.Contains("swagger.json") ||
            path.Contains("swagger/index.html");

        if (allowAnonymous || isSwaggerRequest)
        {
            Console.WriteLine("✅ Skipping authorization (Swagger or [AllowAnonymous])");
            await next(context);
            return;
        }

        Console.WriteLine("🔐 Performing authorization...");

        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (string.IsNullOrEmpty(token))
        {
            Console.WriteLine("❌ Authorization header is missing or malformed.");
            throw new Exception("Null or invalid token");
        }

        var userId = await tokenService.ValidateToken(token);

        if (userId is null)
        {
            Console.WriteLine("❌ Token validation failed.");
            throw new Exception("Invalid token");
        }

        var getUserByIdQuery = new GetUserByIdQuery(userId.Value);
        var user = await userQueryService.Handle(getUserByIdQuery);

        Console.WriteLine("✅ Authorized. User context updated.");
        context.Items["User"] = user;

        await next(context);
    }
}

