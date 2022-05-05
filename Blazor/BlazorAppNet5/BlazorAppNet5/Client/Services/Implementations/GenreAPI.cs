using BlazorAppNet5.Client.Services.Abstractions;
using BlazorAppNet5.Shared.DTO;
using System.Collections.Generic;
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
            var result = await _httpClient.PostAsJsonAsync(_endpoint, model);

            if (!result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsStringAsync();
            }
            return null;
        }

        public async Task<List<GenreDTO>> GetAll()
        {

            return await _httpClient.GetFromJsonAsync<List<GenreDTO>>($"{_endpoint}/all"); //_endpoint es la ruta URL por lo que puedes expandirla
        }

        public async Task<GenreDTO> GetById(int id)
        {
            return await _httpClient.GetFromJsonAsync<GenreDTO>($"{_endpoint}/{id}"); //la ruta al GenreController, alla le asignamos el httpget({id})
            //no es necesario poner la ruta entera html del cliente
        }

        public async Task<string> Update(GenreDTO model)
        {
            var result = await _httpClient.PutAsJsonAsync<GenreDTO>(_endpoint, model);
            if (!result.IsSuccessStatusCode)
            {
                return await result.Content.ReadAsStringAsync();
            }
            return null;
        }
    }
}
