using System.Text.Json;
using System.Text;
using desktop_app.auth;
using desktop_app.dto;
using desktop_app.utils;

namespace desktop_app.services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;
        private readonly string _baseUrl = "https://localhost:7057/api/user";

        public UserService(AuthService authService)
        {
            _authService = authService;
            _httpClient = new HttpClient { BaseAddress = new Uri(_baseUrl) };
        }

        public async Task<List<Client>> GetAllClients()
        {
            _authService.AddAuthorizationHeader(_httpClient);

            var url = $"{_baseUrl}/clients";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await JsonUtil.Deserialize<List<Client>>(response);
        }
    }
}
