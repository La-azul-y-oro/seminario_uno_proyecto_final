namespace api.Services.Interfaces
{
    public interface ILiquidationService
    {
        void GenerateLiquidation(int consortiumId, int month, int year, DateTime expirationDate);
    }
}
