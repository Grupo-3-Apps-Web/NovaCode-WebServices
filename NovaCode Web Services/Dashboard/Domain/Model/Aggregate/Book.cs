namespace NovaCode_Web_Services.Dashboard.Domain.Model.Aggregate;

public class Book
{
    public int Id { get; }
    public string Model { get; private set; } = string.Empty;
    public string Brand { get; private set; } = string.Empty;
    public string Year { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Image { get; private set; } = string.Empty;
    public int Price { get; private set; } = 0;
    public string Rating { get; private set; } = string.Empty;
    
    public Book() {}
    
    public Book(string model, string brand, string year, string description, string image, int price, string rating)
    {
        Model = model;
        Brand = brand;
        Year = year;
        Description = description;
        Image = image;
        Price = price;
        Rating = rating;
    }
    
    public void UpdatePublication(string model, string brand, string year, string description, string image, int price, string rating)
    {
        Model = model;
        Brand = brand;
        Year = year;
        Description = description;
        Image = image;
        Price = price;
        Rating = rating;
    }
    
}