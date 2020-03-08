using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Data
{
    public class HttpLocationService : ILocationService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration configuration;

        public HttpLocationService(IConfiguration configuration)
        {
            this.configuration = configuration;
            _httpClient = new HttpClient();
            string baseUrl = configuration["HttpLocationServiceUrl"];
            
            if (String.IsNullOrWhiteSpace(baseUrl))
                throw new InvalidOperationException("Can not work without HttpLocationServiceUrl on appsettings.json");

            _httpClient.BaseAddress = new Uri(baseUrl);
            _httpClient.Timeout = new TimeSpan(0, 2, 0);
            

        }
        public async Task<Location> GetLocationByIdAsync(int id)
        {
            var locations = await GetLocationsAsync();
            if (locations == null)
                throw new NullReferenceException("Locations API can not be queried at the moment.");
            var location = locations.FirstOrDefault(b => b.Id == id);
            return location;
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            var response = await _httpClient.GetAsync("location");
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var result = JsonConvert.DeserializeObject<IEnumerable<Location>>(content);
                return result.OrderBy(a => a.Name);
            }
            catch(JsonSerializationException jse)
            {
                //Do some logging here
                throw;
            }
        }
    }
}
