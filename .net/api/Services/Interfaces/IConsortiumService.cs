using api.Dto;
using api.Models;

namespace api.Services.Interfaces
{
    public interface IConsortiumService : IGenericService<Consortium, int>
    {
        IEnumerable<ConsortiumResponse> FindAll();
    }
}
