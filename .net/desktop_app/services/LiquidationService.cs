using System;
using desktop_app.auth;
using desktop_app.dto;
using desktop_app.models;
using desktop_app.utils;

namespace desktop_app.services
{
    public class LiquidationService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;
        private readonly string _baseUrl = "https://localhost:7057/api/liquidation";

        public LiquidationService(AuthService authService)
        {
            _authService = authService;
            _httpClient = new HttpClient { BaseAddress = new Uri(_baseUrl) };
        }

        public async Task<HttpResponseMessage> GenerateLiquidationAsync(LiquidationRequest request)
        {
            _authService.AddAuthorizationHeader(_httpClient);

            HttpContent content = JsonUtil.Serialize(request);

            HttpResponseMessage response = await _httpClient.PostAsync(_baseUrl, content);
            response.EnsureSuccessStatusCode();

            return response;
        }

        public async Task<List<Liquidation>> GetAllByConsortiumIdAsync(int consortiumId)
        {
            _authService.AddAuthorizationHeader(_httpClient);

            HttpResponseMessage response = await _httpClient.GetAsync($"{_baseUrl}/consortium/{consortiumId}");            

            response.EnsureSuccessStatusCode();

            return await JsonUtil.Deserialize<List<Liquidation>>(response);
        }
    }
}
