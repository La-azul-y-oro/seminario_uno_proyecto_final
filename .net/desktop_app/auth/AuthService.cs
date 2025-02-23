using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using api.Auth;
using desktop_app.utils;

namespace desktop_app.auth
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7057/api/auth/";
        public string Token { get; set; } = string.Empty;
        public string? Name { get; private set; }
        public string? LastName { get; private set; }
        public string? Role { get; private set; }

        public AuthService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(_baseUrl) };
        }

        public async Task<string?> LoginAsync(LoginDto loginDto)
        {
            HttpContent content = JsonUtil.Serialize(loginDto);

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync("login", content);

                if ((int)response.StatusCode >= 400 && (int)response.StatusCode < 500)
                    return string.Empty;

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while trying login: {ex.Message}");
            }
        }


        public void SetToken(string token)
        {
            Token = token;
            DecodeToken();
        }

        private void DecodeToken()
        {
            if (string.IsNullOrWhiteSpace(Token))
                return;

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(Token);

            Name = jwtToken.Claims.FirstOrDefault(c => c.Type == "name")?.Value;
            LastName = jwtToken.Claims.FirstOrDefault(c => c.Type == "lastName")?.Value;
            Role = jwtToken.Claims.FirstOrDefault(c => c.Type == "role")?.Value;
        }

        public string GetUserInfo()
        {
            return $"{Name} {LastName} {(string.IsNullOrWhiteSpace(Role) ? "" : "- " + Role)}";
        }


    }

}
