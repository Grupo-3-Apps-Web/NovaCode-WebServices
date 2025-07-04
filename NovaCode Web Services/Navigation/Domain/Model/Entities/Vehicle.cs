namespace NovaCode_Web_Services.Navigation.Domain.Model.Entities;

public class Vehicle
{
    public int Id { get; set; }
    
    public string Model {get; set;}
    
    public string Brand {get; set;}
    
    public int Year {get; set;}
    
    public string Description {get; set;}
    
    public string Image {get; set;}
    
    public double Price {get; set;}
    
    public int Rating {get; set;}

    public Vehicle(string model, string brand, int year, string description, string image, double price, int rating)
    {
        Model = model;
        Brand = brand;
        Year = year;
        Description = description;
        Image = image;
        Price = price;
        Rating = rating;
    }

    public Vehicle()
    {
        Model = string.Empty;
        Brand = string.Empty;
        Year = 0;
        Description = string.Empty;
        Image = string.Empty;
        Price = 0;
        Rating = 0;
    }
}