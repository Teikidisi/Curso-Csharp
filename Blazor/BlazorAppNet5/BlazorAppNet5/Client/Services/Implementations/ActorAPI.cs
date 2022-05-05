using BlazorAppNet5.Client.Services.Abstractions;
using BlazorAppNet5.Shared.DTO;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorAppNet5.Client.Services.Implementations
{
    public class ActorAPI : IActorAPI
    {
        private readonly string _endpoint = "api/Actor";
        private readonly HttpClient _httpClient;

        public ActorAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Add(ActorDTO actor)
        {
            var result = await _httpClient.PostAsJsonAsync(_endpoint, actor);
            if (!result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsStringAsync();
            }
            else
            {
                return null;
            }
        }

        public async Task<List<ActorDTO>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ActorDTO>>($"{_endpoint}/all");
            return result;
        }

        public async Task<ActorDTO> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ActorDTO>($"{_endpoint}/{id}");
        }

        public async Task<string> Update(ActorDTO actor)
        {
            var result = await _httpClient.PutAsJsonAsync(_endpoint, actor);
            if (!result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsStringAsync();
            }
            return null;
        }
    }
}
