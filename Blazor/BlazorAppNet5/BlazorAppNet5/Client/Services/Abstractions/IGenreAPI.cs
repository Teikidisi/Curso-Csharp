using BlazorAppNet5.Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorAppNet5.Client.Services.Abstractions
{
    public interface IGenreAPI
    {
        Task<string> Add(GenreDTO model);
        Task<List<GenreDTO>> GetAll();
        Task<GenreDTO> GetById(int id);
        Task<string> Update(GenreDTO model);
    }
}
