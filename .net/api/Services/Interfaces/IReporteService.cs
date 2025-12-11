using api.Models;

namespace api.Services.Interfaces
{
    public interface IReportService
    {
        Task<byte[]> GenerateFinancialReport(int consortiumId, int month, int year, string format);
        Task<byte[]> GenerateExpensesReportByFunctionalUnit(int functionalUnitId, int month, int year);
        Task<byte[]> GenerateExpensesReportByConsortium(Liquidation liquidation);
        byte[] CreateExpensesReportPdf(int consortiumId, int month, int year, decimal sumExpenses, DateTime expirationDate, List<Movement> expenses);
    }

}
