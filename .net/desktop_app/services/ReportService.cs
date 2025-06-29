using System;
using desktop_app.auth;
using desktop_app.dto;
using desktop_app.models;
using desktop_app.utils;

namespace desktop_app.services
{
    public class ReportService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;
        private readonly string _baseUrl = "https://localhost:7057/api/report";
        
        public ReportService(AuthService authService)
        {
            _authService = authService;
            _httpClient = new HttpClient { BaseAddress = new Uri(_baseUrl) };
        }

        public async Task<byte[]> GetExpenseReportAsync(int consortiumId, int year, int month)
        {

            _authService.AddAuthorizationHeader(_httpClient);
            var url = $"{_baseUrl}/consortium/expenses/{consortiumId}?year={year}&month={month}";

            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsByteArrayAsync();
        }


        public async Task<byte[]> GetFinancialReportAsync(int consortiumId, int year, string format, int? month = null)
        {
            _authService.AddAuthorizationHeader(_httpClient);

            var query = $"year={year}&format={format}";
            if (month.HasValue)
                query += $"&month={month.Value}";

            var url = $"{_baseUrl}/financial/{consortiumId}?{query}";

            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}
