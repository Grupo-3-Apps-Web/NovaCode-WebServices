using Microsoft.EntityFrameworkCore;
using NovaCode_Web_Services.Publications.Application.Internal.CommandServices;
using NovaCode_Web_Services.Publications.Application.Internal.QueryServices;
using NovaCode_Web_Services.Publications.Domain.Repositories;
using NovaCode_Web_Services.Publications.Domain.Services;
using NovaCode_Web_Services.Publications.Infrastructure.Persistence.EFC.Repositories;
using NovaCode_Web_Services.Shared.Domain.Repositories;
using NovaCode_Web_Services.Shared.Infrastructure.Interfaces.ASP.Configuration;
using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure Lower Case URLs
 builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Kebab Case Route Naming Convention
 builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnet/core/swashbuckle
 builder.Services.AddEndpointsApiExplorer();
 builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

 builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Publication Bounded Context Dependency Injection Configuration

 builder.Services.AddScoped<IPublicationRepository, PublicationRepository>();
 builder.Services.AddScoped<IPublicationCommandService, PublicationCommandService>();
 builder.Services.AddScoped<IPublicationQueryService, PublicationQueriesService>();

// Add Database Connection
 var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Verify if the connection string is not null or empty
 if (string.IsNullOrEmpty(connectionString))
 {
     throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");
 }

// Configure Database Context and Logging Level
 if (builder.Environment.IsDevelopment())
  builder.Services.AddDbContext<AppDbContext>(options =>
  {
   options.UseMySQL(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors();
  });
 else  if (builder.Environment.IsProduction())
  builder.Services.AddDbContext<AppDbContext>(options =>
  {
   options.UseMySQL(connectionString)
    .LogTo(Console.WriteLine, LogLevel.Error)
    .EnableDetailedErrors();
  }); 
 
// Configure Dependency Injection
 
// Shared Bounded Context Injection Configuration
  builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// ************* Bounded Context Injection Configuration


var app = builder.Build();

// Verify if the database is created and apply migrations
using (var scope = app.Services.CreateScope())
{
   var services = scope.ServiceProvider;
   var context = services.GetRequiredService<AppDbContext>();
   context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//  app.MapOpenApi();
//}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
