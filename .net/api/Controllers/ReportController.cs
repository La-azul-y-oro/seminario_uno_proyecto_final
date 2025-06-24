using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("financial/{consortiumId}")]
        public async Task<IActionResult> GetFinancialReport(
        [FromRoute] int consortiumId,
        [FromQuery] int year,
        [FromQuery] int month = 0,
        [FromQuery] string format = "pdf")
        {
            var reportBytes = await _reportService.GenerateFinancialReport(consortiumId, month, year, format);

            var contentType = format.ToLower() == "excel"
                ? "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                : "application/pdf";

            string fileName;
            if(month <= 0 || month >12){
                fileName = $"reporte_financiero_{year}.{(format == "excel" ? "xlsx" : "pdf")}";
            } else{
                fileName = $"reporte_financiero_{month}_{year}.{(format == "excel" ? "xlsx" : "pdf")}";
            }

            return File(reportBytes, contentType, fileName);
        }

        [HttpGet("consortium/expenses/{consortiumId}")]
        public async Task<IActionResult> GetExpensesReport(
        [FromRoute] int consortiumId,
        [FromQuery] int year,
        [FromQuery] int month)
        {
            var reportBytes = await _reportService.GenerateExpensesReportByConsortium(consortiumId, month, year);

            var contentType = "application/pdf";

            string fileName = $"liquidacion_expensas_consorcio_{month}_{year}.pdf";

            return File(reportBytes, contentType, fileName);
        }

        [HttpGet("functional-unit/expenses/{functionalUnitId}")]
        public async Task<IActionResult> GetExpensesByFunctionalUnitReport(
        [FromRoute] int functionalUnitId,
        [FromQuery] int year,
        [FromQuery] int month)
        {
            var reportBytes = await _reportService.GenerateExpensesReportByFunctionalUnit(functionalUnitId, month, year);

            var contentType = "application/pdf";

            string fileName = $"liquidacion_expensas_{month}_{year}.pdf";

            return File(reportBytes, contentType, fileName);
        }
    }
}
