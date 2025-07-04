using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NovaCode_Web_Services.IAM.Application.ACL.Services;
using NovaCode_Web_Services.IAM.Application.Internal.CommandServices;
using NovaCode_Web_Services.IAM.Application.Internal.OutboundServices;
using NovaCode_Web_Services.IAM.Application.Internal.QueryServices;
using NovaCode_Web_Services.IAM.Domain.Repositories;
using NovaCode_Web_Services.IAM.Domain.Services;
using NovaCode_Web_Services.IAM.Infrastructure.Hashing.BCrypt.Services;
using NovaCode_Web_Services.IAM.Infrastructure.Persistence.EFC.Repositories;
using NovaCode_Web_Services.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using NovaCode_Web_Services.IAM.Infrastructure.Tokens.JWT.Configuration;
using NovaCode_Web_Services.IAM.Infrastructure.Tokens.JWT.Services;
using NovaCode_Web_Services.IAM.Interfaces.ACL;
using NovaCode_Web_Services.Publications.Application.Internal.CommandServices;
using NovaCode_Web_Services.Publications.Application.Internal.QueryServices;
using NovaCode_Web_Services.Publications.Domain.Repositories;
using NovaCode_Web_Services.Publications.Domain.Services;
using NovaCode_Web_Services.Publications.Infrastructure.Persistence.EFC.Repositories;
using NovaCode_Web_Services.Shared.Domain.Repositories;
using NovaCode_Web_Services.Shared.Infrastructure.Interfaces.ASP.Configuration;
using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

// ... (usings sin cambios)

var builder = WebApplication.CreateBuilder(args);

// Apply Route Naming Convention
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => 
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
});

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString is null)
    throw new Exception("Database connection string is not set.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString);
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
    options.EnableAnnotations();
});

// Configuración de restricciones de tipo en rutas

builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("id", typeof(IntRouteConstraint)); // Solo agrega esta línea, sin duplicar "int"
});


// Configure Dependency Injection

// Shared Bounded Context Dependency Injection Configuration

// Dependency Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Publications
builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();
builder.Services.AddScoped<IPublicationCommandService, PublicationCommandService>();
builder.Services.AddScoped<IPublicationQueryService, PublicationQueriesService>();

// IAM
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

var app = builder.Build();

// Verify Database Objects are Created

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add Authorization Middleware to the Pipeline

app.UseCors("AllowAllPolicy");

app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
