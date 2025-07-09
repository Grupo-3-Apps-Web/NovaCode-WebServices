namespace NovaCode_Web_Services.Shared.Domain.Model.Events;

public class PublicationCreatedEvent : IEvent
{
    public int Id { get; }
    public string Model { get; }
    public string Brand { get; }
    public string Year { get; }
    public string Description { get; }
    public string Image { get; }
    public int Price { get; }
    public string PublishedDate { get; }

    public PublicationCreatedEvent(int id, string model, string brand, string year, string description, string image, int price,
        string publishedDate)
    {
        Id = id;
        Model = model;
        Brand = brand;
        Year = year;
        Description = description;
        Image = image;
        Price = price;
        PublishedDate = publishedDate;
    }
}