namespace NovaCode_Web_Services.Navigation.Domain.Model.Aggregate;

public class Vehicle
{
    public int Id { get; set; }
    public string Model { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int Price { get; set; } = 0;
    public string PublishedDate { get; set; } = string.Empty;
    
    public Vehicle(int id, string model, string brand, string year, string description, string image, int price, string publishedDate)
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

    public Vehicle() {}
}