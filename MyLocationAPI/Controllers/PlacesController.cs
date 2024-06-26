using Microsoft.AspNetCore.Mvc;

[Route("api/places")]
[ApiController]
public class PlacesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetNearbyPlaces(double latitude, double longitude)
    {
        
        var places = new[]
        {
            new { Name = "Museum of Modern Art", Address = "11 W 53rd St, New York, NY 10019", Category = "Art Museum" },
            new { Name = "Central Park", Address = "New York, NY 10024", Category = "Park" }
        };
        return Ok(places); 
    }
}
