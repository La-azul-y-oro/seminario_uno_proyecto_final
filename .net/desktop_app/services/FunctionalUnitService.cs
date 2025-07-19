using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using desktop_app.auth;
using desktop_app.dto;
using desktop_app.utils;

namespace desktop_app.services
{
    public class FunctionalUnitService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;
        private readonly string _baseUrl = "https://localhost:7057/api/functionalunit";

        public FunctionalUnitService(AuthService authService)
        {
            _authService = authService;
            _httpClient = new HttpClient { BaseAddress = new Uri(_baseUrl) };
        }

        public async Task<List<FunctionalUnitResponse>> ProcessBatchAsync(FunctionalUnitBatch batch)
        {
            _authService.AddAuthorizationHeader(_httpClient);

            var url = $"{_baseUrl}/update-units";

            var response = await _httpClient.PostAsJsonAsync(url, batch);
            response.EnsureSuccessStatusCode();

            return await JsonUtil.Deserialize<List<FunctionalUnitResponse>>(response);
        }

        public async Task UpdateClientsAsync(AssignClientsRequest request)
        {
            _authService.AddAuthorizationHeader(_httpClient);
            var url = $"{_baseUrl}/assign-clients";

            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al actualizar clientes: {response.StatusCode} - {error}");
            }
        }

    }
}
