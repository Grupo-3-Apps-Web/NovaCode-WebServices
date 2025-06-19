using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using NovaCode_Web_Services.Publications.Domain.Model.Aggregate;

namespace NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Publication Context
        builder.Entity<Publication>().ToTable("Publications");
        builder.Entity<Publication>().HasKey(e => e.Id);
        builder.Entity<Publication>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Publication>().Property(e => e.Model).IsRequired();
        builder.Entity<Publication>().Property(e => e.Brand).IsRequired();
        builder.Entity<Publication>().Property(e => e.Year).IsRequired();
        builder.Entity<Publication>().Property(e => e.Description).IsRequired();
        builder.Entity<Publication>().Property(e => e.Image).IsRequired();
        builder.Entity<Publication>().Property(e => e.Price).IsRequired();
        builder.Entity<Publication>().Property(e => e.PublishedDate).IsRequired();




        
        builder.UseSnakeCaseNamingConvention();
    }
}