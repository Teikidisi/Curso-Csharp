using BlazorAppNet5.Shared.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorAppNet5.Client.Services.Abstractions
{
    public interface IActorAPI
    {
        Task<string> Add(ActorDTO actor);
        Task<List<ActorDTO>> GetAll();
        Task<ActorDTO> GetById(int id);
        Task<string> Update(ActorDTO actor);
    }
}
