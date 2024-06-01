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
            // Google Haritalar API'ye bir istek göndermek için HttpClient kullanın
            var httpClient = _clientFactory.CreateClient();

            // API anahtarınızı veya diğer yetkilendirme bilgilerinizi buraya ekleyin
            var apiKey = "YOUR_GOOGLE_MAPS_API_KEY";

            // API'ye gönderilecek isteğin URL'sini oluşturun
            var url = $"https://maps.googleapis.com/maps/api/directions/json?origin={startLatitude},{startLongitude}&destination={endLatitude},{endLongitude}&key={apiKey}";

            // API'ye GET isteği gönderin
            var response = await httpClient.GetAsync(url);

            // Yanıtı kontrol edin
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Failed to get directions from Google Maps API.");
            }

            // Yanıtı JSON olarak okuyun
            var jsonString = await response.Content.ReadAsStringAsync();

            // İsteği yeniden JSON formatına dönüştürün ve istemciye gönderin
            return Ok(jsonString);
        }
    }
}
