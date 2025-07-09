namespace NovaCode_Web_Services.Dashboard.Domain.Model.Aggregate;

public class Book
{
    public int Id { get; set; }
    public int VehicleId { get; set; }
    public int UserId { get; set; }
    public DateTime ReservedAt { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public string Year { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public int Price { get; set; }
    public string PublishedDate { get; set; }
    
    public Book() {}
    
    public Book(string model, string brand, string year, string description, string image, int price, string publishedDate)
    {
        Model = model;
        Brand = brand;
        Year = year;
        Description = description;
        Image = image;
        Price = price;
        PublishedDate = publishedDate;
    }
}