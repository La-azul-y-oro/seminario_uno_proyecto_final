using api.Dto;
using api.Models;

namespace api.Services.Interfaces
{
    public interface IFunctionalUnitService : IGenericService<FunctionalUnit, int>
    {
        List<FunctionalUnitResponse> FindByConsortiumId(int consortiumId);
        void UpdateBalance(int id, decimal amount);
        void UpdateClientsToFunctionalUnit(int FunctionalId, List<int> ClientsIds);
        List<ClientFunctionalUnit> GetByClientId(int ClientId);
        Task ProcessBatchOperations(FunctionalUnitBatchRequest request);
    }
}
