using api.Dto;
using api.Models;
using api.Services.Interfaces;
using ClosedXML.Excel;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace api.Services.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IMovementService _movementService;
        private readonly IConsortiumService _consortiumService;
        private readonly IFunctionalUnitService _functionalUnitService;

        private static readonly string[] _headersFinancialIncomes = ["Fecha", "Concepto", "Monto", "Comentario"];
        private static readonly string[] _headersFinancialExpenses = ["Fecha", "Proveedor", "Concepto", "Monto", "Comentario"];
        private static readonly string[] _headersFunctionalUnits = ["Unidad", "Factor", "A abonar"];

        public ReportService(IMovementService movementService, IConsortiumService consortiumService, IFunctionalUnitService functionalUnitService)
        {
            _movementService = movementService;
            _consortiumService = consortiumService;
            _functionalUnitService = functionalUnitService;
        }

        public async Task<byte[]> GenerateFinancialReport(int consortiumId, int month, int year, string format)
        {
            string consortiumName = _consortiumService.GetById(consortiumId).Name;
            string reportTitle;
            List<Movement> movements;

            if (month <= 0 || month > 12)
            {
                movements = _movementService.GetByConsortiumAndYear(consortiumId, year);
                reportTitle = $"Reporte Financiero Anual - {year}";
            }
            else
            {
                movements = _movementService.GetByConsortiumAndMonthAndYear(consortiumId, month, year);
                reportTitle = $"Reporte Financiero Mensual - {month:D2}/{year}";
            }

            var incomes = movements.Where(m => m.Type == MovementType.INGRESO).ToList();
            var expenses = movements.Where(m => m.Type == MovementType.EGRESO).ToList();

            var sumIncomes = incomes.Sum(m => m.Amount);
            var sumExpenses = expenses.Sum(m => m.Amount);

            var balance = sumIncomes - sumExpenses;

            var reportContent = new FinancialReportContent()
            {
                ReportTitle = reportTitle,
                ConsortiumName = consortiumName,
                Incomes = incomes,
                Expenses = expenses,
                SumIncomes = sumIncomes,
                SumExpenses = sumExpenses,
                Balance = balance
            };

            return (format.ToLower() == "excel") ? GenerateFinancialExcel(reportContent) : GenerateFinancialPdf(reportContent);
        }

        public async Task<byte[]> GenerateExpensesReportByFunctionalUnit(int functionalUnitId, int month, int year)
        {
            var functionalUnit = _functionalUnitService.GetById(functionalUnitId);
            var movements = _movementService.GetByConsortiumAndMonthAndYear(functionalUnit.ConsortiumId, month, year);
            var consortiumName = functionalUnit.Consortium.Name;
            var reportTitle = $"Liquidación expensas - Unidad {functionalUnit.Name} - Consorcio: {consortiumName} - Período: {month:D2}/{year}";

            var expenses = movements.Where(m => m.Type == MovementType.EGRESO).ToList();
            var sumExpenses = expenses.Sum(m => m.Amount);
            var toPay = (sumExpenses * (functionalUnit.Factor / 100));

            var reportContent = new ExpensesForFunctionalUnitReportContent()
            {
                ReportTitle = reportTitle,
                ConsortiumName = consortiumName,
                Expenses = expenses,
                SumExpenses = sumExpenses,
                Factor = functionalUnit.Factor,
                ToPay = toPay
            };

            return GenerateExpensesByFunctionalUnitPdf(reportContent);
        }

        /// <summary>
        /// Obtiene el PDF de liquidación guardado en la base de datos
        /// </summary>
        public async Task<byte[]> GenerateExpensesReportByConsortium(Liquidation liquidation)
        {
            if (liquidation == null)
            {
                throw new Exception("Liquidación no encontrada para el período indicado");
            }

            if (liquidation.PdfDocument == null || liquidation.PdfDocument.Length == 0)
            {
                throw new Exception("El PDF de la liquidación no está disponible");
            }

            return liquidation.PdfDocument;
        }

        /// <summary>
        /// Genera el PDF de liquidación al momento de crear la liquidación.
        /// Este método es llamado por LiquidationService.
        /// </summary>
        public byte[] CreateExpensesReportPdf(int consortiumId, int month, int year,
            decimal sumExpenses, DateTime expirationDate, List<Movement> expenses)
        {
            var consortium = _consortiumService.GetById(consortiumId);
            var functionalUnits = _functionalUnitService.FindByConsortiumId(consortiumId);
            var consortiumName = consortium.Name;
            var reportTitle = $"Liquidación expensas - Consorcio: {consortiumName} - Período: {month:D2}/{year}";

            var reportContent = new ExpensesForConsoritumReportContent()
            {
                ReportTitle = reportTitle,
                ConsortiumName = consortiumName,
                Expenses = expenses,
                SumExpenses = sumExpenses,
                FunctionalUnits = functionalUnits,
                ExpirationDate = expirationDate
            };

            return GenerateExpensesByConsortiumPdf(reportContent);
        }

        private static byte[] GenerateFinancialPdf(FinancialReportContent reportContent)
        {
            var document = Document.Create(container =>
            {
                _ = container.Page(page =>
                {
                    page.Margin(30);

                    page.Header().Column(header =>
                    {
                        header.Item().Text(reportContent.ConsortiumName).Bold().FontSize(16).AlignCenter();
                        header.Item().Text(reportContent.ReportTitle).FontSize(12).AlignCenter();
                    });
                    page.Content().PaddingVertical(10).Element(content =>
                    {
                        if (!reportContent.Incomes.Any() && !reportContent.Expenses.Any())
                        {
                            PdfAddMessageNoData(content);
                        }
                        else
                        {
                            content.Column(column =>
                            {
                                PdfAddTableIncomes("Ingresos", reportContent.Incomes, column);

                                column.Item().PaddingTop(8).Text($"Total Ingresos: ${reportContent.SumIncomes:N2}")
                                        .Bold().FontSize(12).AlignRight();

                                PdfAddTableExpenses("Egresos", reportContent.Expenses, column);

                                column.Item().PaddingTop(8).Text($"Total Egresos: ${reportContent.SumExpenses:N2}")
                                      .Bold().FontSize(12).AlignRight();

                                column.Item().PaddingTop(16).PaddingBottom(8).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                                column.Item().Text($"Balance: ${reportContent.Balance:N2}")
                                    .Bold().FontSize(12).AlignRight();
                            });
                        }
                    });

                    PdfBuildFooter(page);
                });
            });

            return document.GeneratePdf();
        }

        private static byte[] GenerateFinancialExcel(FinancialReportContent reportContent)
        {
            using var workbook = new XLWorkbook();
            var sheet = workbook.Worksheets.Add("Reporte");

            int row = 1;

            sheet.Cell(row++, 1).Value = reportContent.ConsortiumName;
            sheet.Cell(row++, 1).Value = reportContent.ReportTitle;
            row++;

            bool hasIncomes = reportContent.Incomes?.Any() == true;
            bool hasExpenses = reportContent.Expenses?.Any() == true;

            if (!hasIncomes && !hasExpenses)
            {
                // Leyenda si no hay datos
                var messageCell = sheet.Cell(row++, 1);
                messageCell.Value = "NO EXISTEN DATOS PARA EL PERÍODO SELECCIONADO.";
                messageCell.Style.Font.Italic = true;
                messageCell.Style.Font.FontColor = XLColor.Gray;
                sheet.Range(row - 1, 1, row - 1, 4).Merge();
            }
            else
            {
                row = ExcelAddSectionIncomes("Ingresos", reportContent.Incomes, sheet, row);
                sheet.Cell(row, 3).Value = "Total Ingresos:";
                sheet.Cell(row, 4).Value = reportContent.SumIncomes;
                sheet.Cell(row, 3).Style.Font.Bold = true;
                sheet.Cell(row, 4).Style.Font.Bold = true;
                row += 2;

                row = ExcelAddSectionExpenses("Egresos", reportContent.Expenses, sheet, row);
                sheet.Cell(row, 4).Value = "Total Egresos:";
                sheet.Cell(row, 5).Value = reportContent.SumExpenses;
                sheet.Cell(row, 4).Style.Font.Bold = true;
                sheet.Cell(row, 5).Style.Font.Bold = true;
                row += 2;

                sheet.Cell(row, 4).Value = "Balance:";
                sheet.Cell(row, 5).Value = reportContent.Balance;
                sheet.Cell(row, 4).Style.Font.Bold = true;
                sheet.Cell(row, 5).Style.Font.Bold = true;
            }

            sheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        private static byte[] GenerateExpensesByFunctionalUnitPdf(ExpensesForFunctionalUnitReportContent reportContent)
        {
            var document = Document.Create(container =>
            {
                _ = container.Page(page =>
                {
                    page.Margin(30);

                    page.Header().Column(header =>
                    {
                        header.Item().Text(reportContent.ConsortiumName).Bold().FontSize(16).AlignCenter();

                        header.Item().Row(row =>
                        {
                            row.RelativeItem().AlignCenter().Container().MaxWidth(400).Text(reportContent.ReportTitle).AlignCenter().FontSize(12);
                        });
                    });

                    page.Content().PaddingVertical(10).Element(content =>
                    {
                        if (!reportContent.Expenses.Any())
                        {
                            PdfAddMessageNoData(content);
                        }
                        else
                        {
                            content.Column(column =>
                            {
                                PdfAddTableExpenses("Gastos", reportContent.Expenses, column);

                                column.Item().PaddingTop(8).Text($"Total Egresos: ${reportContent.SumExpenses:N2}")
                                      .Bold().FontSize(12).AlignRight();

                                column.Item().PaddingTop(16).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                                column.Item().PaddingVertical(8).Text($"Proporcional unidad: {reportContent.Factor:N2}%")
                                    .Bold().FontSize(12).AlignRight();

                                column.Item().Text($"A abonar: ${reportContent.ToPay:N2}")
                                    .Bold().FontSize(12).AlignRight();
                            });
                        }
                    });

                    PdfBuildFooter(page);
                });
            });

            return document.GeneratePdf();
        }

        private static byte[] GenerateExpensesByConsortiumPdf(ExpensesForConsoritumReportContent reportContent)
        {
            var document = Document.Create(container =>
            {
                _ = container.Page(page =>
                {
                    page.Margin(30);

                    page.Header().Column(header =>
                    {
                        header.Item().Text(reportContent.ConsortiumName).Bold().FontSize(16).AlignCenter();

                        header.Item().Row(row =>
                        {
                            row.RelativeItem().AlignCenter().Container().MaxWidth(400).Text(reportContent.ReportTitle).AlignCenter().FontSize(12);
                        });
                        header.Item().Row(row =>
                        {
                            row.RelativeItem().AlignCenter().Container().MaxWidth(400).PaddingTop(10).Text("Fecha vencimiento: " + reportContent.ExpirationDate.ToShortDateString()).AlignCenter().FontSize(12);
                        });
                    });

                    page.Content().PaddingVertical(10).Element(content =>
                    {
                        if (!reportContent.Expenses.Any())
                        {
                            PdfAddMessageNoData(content);
                        }
                        else
                        {
                            content.Column(column =>
                            {
                                PdfAddTableExpenses("Gastos", reportContent.Expenses, column);

                                column.Item().PaddingTop(8).Text($"Total Egresos: ${reportContent.SumExpenses:N2}")
                                      .Bold().FontSize(12).AlignRight();

                                PdfAddTableFunctionalUnits("Unidades funcionales", reportContent, column);
                            });
                        }
                    });

                    PdfBuildFooter(page);
                });
            });

            return document.GeneratePdf();
        }

        private static void PdfAddTableIncomes(string title, List<Movement> data, ColumnDescriptor column)
        {
            column.Item().PaddingTop(20).Text(title).Bold().FontSize(14); // Espacio entre secciones

            column.Item().PaddingTop(10).Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(90); // Fecha
                    columns.RelativeColumn();   // Concepto
                    columns.ConstantColumn(80); // Monto
                    columns.RelativeColumn();   // Descripción
                });

                // Encabezado con fondo gris claro y padding
                table.Header(header =>
                {
                    void HeaderCell(string text) => header.Cell().Background("#F0F0F0").Border(1)
                        .Padding(4).Text(text).Bold();

                    foreach (var item in _headersFinancialIncomes)
                    {
                        HeaderCell(item);
                    }
                });

                // Filas de datos con padding y bordes
                foreach (var m in data)
                {
                    void DataCell(string text) => table.Cell().Border(1)
                        .Padding(4).Text(text);

                    DataCell(m.Date.ToShortDateString());
                    DataCell(m.Concept.Name);
                    DataCell($"${m.Amount:N2}");
                    DataCell((m.Comment != null) ? m.Comment.ToString() : "");
                }
            });
        }

        private static void PdfAddTableExpenses(string title, List<Movement> data, ColumnDescriptor column){
            column.Item().PaddingTop(20).Text(title).Bold().FontSize(14); // Espacio entre secciones

            column.Item().PaddingTop(10).Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(90); // Fecha
                    columns.RelativeColumn();   // Concepto
                    columns.RelativeColumn();   // Proveedor
                    columns.ConstantColumn(80); // Monto
                    columns.RelativeColumn();   // Descripción
                });

                // Encabezado con fondo gris claro y padding
                table.Header(header =>
                {
                    void HeaderCell(string text) => header.Cell().Background("#F0F0F0").Border(1)
                        .Padding(4).Text(text).Bold();

                    foreach (var item in _headersFinancialExpenses)
                    {
                        HeaderCell(item);
                    }
                });

                // Filas de datos con padding y bordes
                foreach (var m in data)
                {
                    void DataCell(string text) => table.Cell().Border(1)
                        .Padding(4).Text(text);

                    DataCell(m.Date.ToShortDateString());
                    DataCell((m.Supplier != null) ? m.Supplier.Name : "");
                    DataCell(m.Concept.Name);
                    DataCell($"${m.Amount:N2}");
                    DataCell((m.Comment != null) ? m.Comment.ToString() : "");
                }
            });
        }

        private static void PdfAddTableFunctionalUnits(string title, ExpensesForConsoritumReportContent reportContent, ColumnDescriptor column)
        {
            var totalExpenses = reportContent.SumExpenses;

            column.Item().PaddingTop(20).Text(title).Bold().FontSize(14); // Espacio entre secciones

            column.Item().PaddingTop(10).Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(); // Unidad
                    columns.RelativeColumn();   // Factor
                    columns.RelativeColumn(); // A Abonar
                });

                // Encabezado con fondo gris claro y padding
                table.Header(header =>
                {
                    void HeaderCell(string text) => header.Cell().Background("#F0F0F0").Border(1)
                        .Padding(4).Text(text).Bold();

                    foreach (var item in _headersFunctionalUnits)
                    {
                        HeaderCell(item);
                    }
                });

                // Filas de datos con padding y bordes
                foreach (var m in reportContent.FunctionalUnits)
                {
                    var factorPercent = (m.Factor).ToString("F2") + "%";
                    var toPay = "$" + (totalExpenses * (m.Factor / 100)).ToString("F2");

                    void DataCell(string text) => table.Cell().Border(1)
                        .Padding(4).Text(text);

                    DataCell(m.Name);
                    DataCell(factorPercent);
                    DataCell(toPay);
                }
            });
        }

        private static int ExcelAddSectionIncomes(string title, List<Movement> data, IXLWorksheet sheet, int row)
        {
            sheet.Cell(row++, 1).Value = title;
            for (int i = 0; i < _headersFinancialIncomes.Length; i++)
            {
                var cell = sheet.Cell(row, i + 1);
                cell.Value = _headersFinancialIncomes[i];
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            }
            row++;

            foreach (var m in data)
            {
                sheet.Cell(row, 1).Value = m.Date.ToShortDateString();
                sheet.Cell(row, 2).Value = m.Concept.Name;
                sheet.Cell(row, 3).Value = m.Amount;
                sheet.Cell(row, 4).Value = (m.Comment != null) ? m.Comment.ToString() : "";

                for (int i = 1; i <= 4; i++)
                    sheet.Cell(row, i).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                row++;
            }
            return row;
        }

        private static int ExcelAddSectionExpenses(string title, List<Movement> data, IXLWorksheet sheet, int row)
        {
            sheet.Cell(row++, 1).Value = title;
            for (int i = 0; i < _headersFinancialExpenses.Length; i++)
            {
                var cell = sheet.Cell(row, i + 1);
                cell.Value = _headersFinancialExpenses[i];
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            }
            row++;

            foreach (var m in data)
            {
                sheet.Cell(row, 1).Value = m.Date.ToShortDateString();
                sheet.Cell(row, 2).Value = (m.Supplier != null) ? m.Supplier.Name : "";
                sheet.Cell(row, 3).Value = m.Concept.Name;
                sheet.Cell(row, 4).Value = m.Amount;
                sheet.Cell(row, 5).Value = (m.Comment != null) ? m.Comment.ToString() : "";

                for (int i = 1; i <= 5; i++)
                    sheet.Cell(row, i).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                row++;
            }
            return row;
        }

        private static void PdfAddMessageNoData(IContainer content)
        {
            content.Column(column =>
            {
                column.Item().PaddingTop(32).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                column.Item().PaddingVertical(10).Text("NO EXISTEN DATOS PARA EL PERÍODO SELECCIONADO")
                    .FontSize(15)
                    .FontColor(Colors.Grey.Darken2)
                    .AlignCenter();

                column.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
            });
        }

        private static void PdfBuildFooter(PageDescriptor page)
        {
            page.Footer().Column(column =>
            {
                // Línea superior como separador
                column.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                // Leyenda centrada
                column.Item().AlignCenter().Text("Generado por el sistema de consorcio")
                    .FontSize(10)
                    .FontColor(Colors.Grey.Darken1);

                // Número de página alineado a la derecha
                column.Item().AlignRight().Text(text =>
                {
                    text.Span("Página ")
                        .FontSize(10)
                        .FontColor(Colors.Grey.Darken1);

                    text.CurrentPageNumber()
                        .FontSize(10)
                        .FontColor(Colors.Grey.Darken1);

                    text.Span(" de ")
                        .FontSize(10)
                        .FontColor(Colors.Grey.Darken1);

                    text.TotalPages()
                        .FontSize(10)
                        .FontColor(Colors.Grey.Darken1);
                });
            });
        }

        private sealed class FinancialReportContent
        {
            public required string ReportTitle { get; set; }
            public required string ConsortiumName { get; set; }
            public required List<Movement> Incomes { get; set; }
            public required List<Movement> Expenses { get; set; }
            public decimal SumIncomes { get; set; }
            public decimal SumExpenses { get; set; }
            public decimal Balance { get; set; }
        }

        private sealed class ExpensesForFunctionalUnitReportContent
        {
            public required string ReportTitle { get; set; }
            public required string ConsortiumName { get; set; }
            public required List<Movement> Expenses { get; set; }
            public decimal SumExpenses { get; set; }
            public decimal Factor { get; set; }
            public decimal ToPay { get; set; }
        }

        private sealed class ExpensesForConsoritumReportContent
        {
            public required string ReportTitle { get; set; }
            public required string ConsortiumName { get; set; }
            public required List<Movement> Expenses { get; set; }
            public decimal SumExpenses { get; set; }
            public required List<FunctionalUnitResponse> FunctionalUnits { get; set; }
            public DateTime ExpirationDate { get; set; }
        }
    }
}