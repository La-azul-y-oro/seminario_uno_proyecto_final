using api.Models;

namespace api.Services.Interfaces
{
    public interface IConceptService :  IGenericService<Concept, int>
    {
        List<Concept> GetByIds(List<int> ids);
    }
}
