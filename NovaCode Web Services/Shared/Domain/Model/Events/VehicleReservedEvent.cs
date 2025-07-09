namespace NovaCode_Web_Services.Shared.Domain.Model.Events;

public class VehicleReservedEvent : IEvent
{
    public int UserId { get; }
    public int VehicleId { get; }
    public DateTime ReservedAt { get; }
    public string Model { get; }
    public string Brand { get; }
    public string Year { get; }
    public string Description { get; }
    public string Image { get; }
    public int Price { get; }
    public string PublishedDate { get; }

    public VehicleReservedEvent(int userId, int vehicleId, DateTime reservedAt, string model, string brand, string year, string description, string image, int price, string publishedDate)
    {
        UserId = userId;
        VehicleId = vehicleId;
        ReservedAt = reservedAt;
        Model = model;
        Brand = brand;
        Year = year;
        Description = description;
        Image = image;
        Price = price;
        PublishedDate = publishedDate;
    }
}