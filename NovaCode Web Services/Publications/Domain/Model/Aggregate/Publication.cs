namespace NovaCode_Web_Services.Publications.Domain.Model.Aggregate;

public class Publication
{
    public int Id { get; }
    public string Model { get; private set; } = string.Empty;
    public string Brand { get; private set; } = string.Empty;
    public string Year { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Image { get; private set; } = string.Empty;
    public int Price { get; private set; } = 0;
    public string PublishedDate { get; private set; } = string.Empty;
    
    public Publication() {}
    
    public Publication(string model, string brand, string year, string description, string image, int price, string publishedDate)
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