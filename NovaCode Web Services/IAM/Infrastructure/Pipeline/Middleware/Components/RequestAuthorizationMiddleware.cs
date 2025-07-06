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
        var allowAnonymous = endpoint != null &&
                             endpoint.Metadata?.Any(m => m.GetType() == typeof(AllowAnonymousAttribute)) == true;

        var path = context.Request.Path.Value?.ToLower();
        if (allowAnonymous || (path != null && path.Contains("/swagger")))
        {
            Console.WriteLine("🔓 Skipping authorization for anonymous or Swagger route.");
            await next(context);
            return;
        }

        Console.WriteLine("🔐 Performing authorization...");
        var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
        var token = authHeader?.Split(" ").Last();

        if (string.IsNullOrWhiteSpace(token))
        {
            Console.WriteLine("❌ Authorization header is missing or malformed.");
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized: Null or invalid token");
            return;
        }

        var userId = await tokenService.ValidateToken(token);
        if (userId is null)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized: Invalid token");
            return;
        }

        var getUserByIdQuery = new GetUserByIdQuery(userId.Value);
        var user = await userQueryService.Handle(getUserByIdQuery);
        context.Items["User"] = user;
        await next(context);
    }
}

