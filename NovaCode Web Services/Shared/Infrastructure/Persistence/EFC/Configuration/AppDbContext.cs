using NovaCode_Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using NovaCode_Web_Services.Dashboard.Domain.Model.Aggregate;
using NovaCode_Web_Services.IAM.Domain.Model.Aggregates;
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
        
        // DashBoard context
        builder.Entity<Book>().ToTable("Books");
        builder.Entity<Book>().HasKey(e => e.Id);
        builder.Entity<Book>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Book>().Property(e=>e.Model).IsRequired();
        builder.Entity<Book>().Property(e => e.Brand).IsRequired();
        builder.Entity<Book>().Property(e => e.Year).IsRequired();
        builder.Entity<Book>().Property(e => e.Description).IsRequired();
        builder.Entity<Book>().Property(e => e.Image).IsRequired();
        builder.Entity<Book>().Property(e => e.Price).IsRequired();
        builder.Entity<Book>().Property(e=>e.Rating).IsRequired();

        //IAM Context
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();


        
        builder.UseSnakeCaseNamingConvention();
    }
}