namespace api.Services.Interfaces
{
    public interface IReportService
    {
        Task<byte[]> GenerateFinancialReport(int consortiumId, int month, int year, string format);
        Task<byte[]> GenerateExpensesReportByFunctionalUnit(int functionalUnitId, int month, int year);
        Task<byte[]> GenerateExpensesReportByConsortium(int consortiumId, int month, int year);
    }

}
