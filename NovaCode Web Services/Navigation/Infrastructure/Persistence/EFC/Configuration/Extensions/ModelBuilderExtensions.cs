using Microsoft.EntityFrameworkCore;
using NovaCode_Web_Services.Navigation.Domain.Model.Entities;

namespace NovaCode_Web_Services.Navigation.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyNavigationConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Review>().HasKey(r => r.Id);
        builder.Entity<Review>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Review>().Property(r => r.Score).IsRequired();
        builder.Entity<Review>().Property(r => r.Comment).IsRequired();
        builder.Entity<Review>().Property(r => r.VehicleId).IsRequired();
        builder.Entity<Review>().Property(r => r.UserId).IsRequired();
        
        builder.Entity<Reservation>().HasKey(re => re.Id);
        builder.Entity<Reservation>().Property(re => re.Id).IsRequired().ValueGeneratedOnAdd();
    }
}