using api.Models;

namespace api.Services.Interfaces
{
    public interface IFunctionalUnitService : IGenericService<FunctionalUnit, int>
    {
        List<FunctionalUnit> FindByConsortiumId(int consortiumId);
    }
}
