using api.Models;

namespace api.Services.Interfaces
{
    public interface IMovementService : IGenericService<Movement, int>
    {
        List<Movement> GetByConsortiumAndMonthAndYear(int consortiumId, int month, int year);
        List<Movement> GetByConsortiumAndYear(int consortiumId, int year);

        Movement CreateAndReturn(Movement entity);
    }
}
