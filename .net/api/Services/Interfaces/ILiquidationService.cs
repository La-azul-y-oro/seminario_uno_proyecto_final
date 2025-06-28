using api.Models;

namespace api.Services.Interfaces
{
    public interface ILiquidationService
    {
        void GenerateLiquidation(int consortiumId, int month, int year, DateTime expirationDate);

        IEnumerable<Liquidation> GetAllByConsortiumId(int consortiumId);

        Liquidation GetByPeriodAndConsortiumId(String period, int consortiumId);
    }
}
