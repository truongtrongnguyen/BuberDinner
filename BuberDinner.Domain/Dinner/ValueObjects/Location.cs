namespace BuberDinner.Domain.Dinner.ValueObjects;

public class Location
{
    public Location(
        string? name,
        string? address,
        double latitude,
        double longitude)
    {
        Name = name;
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public string? Name { get; set; }
    public string? Address { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}