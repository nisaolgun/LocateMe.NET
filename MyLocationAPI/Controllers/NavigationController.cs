using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyLocationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NavigationController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public NavigationController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet("directions")]
        public async Task<IActionResult> GetDirections(double startLatitude, double startLongitude, double endLatitude, double endLongitude)
        {
           
            var httpClient = _clientFactory.CreateClient();

          
            var apiKey = "YOUR_GOOGLE_MAPS_API_KEY";

            var url = $"https://maps.googleapis.com/maps/api/directions/json?origin={startLatitude},{startLongitude}&destination={endLatitude},{endLongitude}&key={apiKey}";

           
            var response = await httpClient.GetAsync(url);

            
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Failed to get directions from Google Maps API.");
            }

          
            var jsonString = await response.Content.ReadAsStringAsync();

            return Ok(jsonString);
        }
    }
}
