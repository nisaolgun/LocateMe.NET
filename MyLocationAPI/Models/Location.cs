namespace MyLocationAPI.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string? Name { get; set; } // Null atanabilir olarak değiştirildi
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
