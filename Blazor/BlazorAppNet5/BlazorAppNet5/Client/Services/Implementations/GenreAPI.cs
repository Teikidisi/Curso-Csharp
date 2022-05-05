using BlazorAppNet5.Client.Services.Abstractions;
using BlazorAppNet5.Shared.DTO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorAppNet5.Client.Services.Implementations
{
    public class GenreAPI : IGenreAPI
    {
        private readonly string _endpoint = "api/genre";
        private readonly HttpClient _httpClient;

        public GenreAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Add(GenreDTO model)
        {
            var result = await _httpClient.PostAsJsonAsync(_endpoint,model);

            if (!result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsStringAsync();
            }
            return null;
        }
    }
}
