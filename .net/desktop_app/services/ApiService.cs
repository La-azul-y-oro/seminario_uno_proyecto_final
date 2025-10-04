using System.Net.Http.Headers;
using desktop_app.auth;
using desktop_app.utils;

namespace desktop_app.services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;
        private readonly string _baseUrl = "https://localhost:7057/api/";

        public ApiService(AuthService authService)
        {
            _authService = authService;
            _httpClient = new HttpClient { BaseAddress = new Uri(_baseUrl) };
        }

        public async Task<List<T>> GetAllAsync<T>(string endpoint)
        {
            try
            {
                _authService.AddAuthorizationHeader(_httpClient);
                HttpResponseMessage response = await _httpClient.GetAsync(endpoint);
                return await JsonUtil.Deserialize<List<T>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving data from {endpoint}: {ex.Message}");
            }
        }

        public async Task<T> GetByIdAsync<T>(string endpoint, int id)
        {
            try
            {
                _authService.AddAuthorizationHeader(_httpClient);
                HttpResponseMessage response = await _httpClient.GetAsync($"{endpoint}/{id}");
                return await JsonUtil.Deserialize<T>(response);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while retrieving data from {endpoint}/{id}: {ex.Message}");
            }
        }

        public async Task<bool> PostAsync<T>(string endpoint, T data)
        {
            _authService.AddAuthorizationHeader(_httpClient);
            HttpContent content = JsonUtil.Serialize(data);

            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync<T>(string endpoint, int id, T data)
        {
            try
            {
                _authService.AddAuthorizationHeader(_httpClient);
                HttpContent content = JsonUtil.Serialize(data);

                HttpResponseMessage response = await _httpClient.PutAsync($"{endpoint}/{id}", content);
                response.EnsureSuccessStatusCode();

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while updating data in {endpoint}/{id}: {ex.Message}");
            }
        }

        public async Task<bool> DeleteAsync(string endpoint, int id)
        {
            _authService.AddAuthorizationHeader(_httpClient);
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{endpoint}/{id}");
            response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;
        }
    }

}
