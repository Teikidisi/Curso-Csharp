using BlazorAppNet5.Shared.DTO;
using System.Threading.Tasks;

namespace BlazorAppNet5.Client.Services.Abstractions
{
    public interface IGenreAPI
    {
        Task<string> Add(GenreDTO model);
    }
}
