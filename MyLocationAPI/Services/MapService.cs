using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyLocationAPI.Services
{
    public class MapService
    {
        private readonly HttpClient _httpClient;

        public MapService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string> GetLocationDetailsAsync(double latitude, double longitude)
        {
            

            string requestUri = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={latitude},{longitude}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(requestUri);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                   
                    return json;
                }
                else
                {
                  
                    return $"HTTP hata kodu: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
              
                return $"Hata: {ex.Message}";
            }
        }
    }
}
