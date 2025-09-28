using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using api.Auth;
using desktop_app.dto;
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

        public async Task<bool> ChangePasswordAsync(ChangePasswordRequest changePasswordDto)
        {
            HttpContent content = JsonUtil.Serialize(changePasswordDto);

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                HttpResponseMessage response = await _httpClient.PostAsync("change-password", content);

                if ((int)response.StatusCode >= 400 && (int)response.StatusCode < 500)
                    return false;

                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while changing password: {ex.Message}");
            }
        }

        public async Task ResetPasswordAsync(ResetPasswordRequest changePasswordDto)
        {
            HttpContent content = JsonUtil.Serialize(changePasswordDto);

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync("reset-password", content);

                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while reset password: {ex.Message}");
            }
        }


        public async Task ForgotPasswordAsync(ForgotPasswordRequest forgotPasswordDto)
        {
            HttpContent content = JsonUtil.Serialize(forgotPasswordDto);

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync("forgot-password", content);

                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while getting token: {ex.Message}");
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
            Role = jwtToken.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;
        }

        public string GetRole(string token){
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            return jwtToken.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;
        } 

        public string GetUserInfo()
        {
            return $"{Name} {LastName} {(string.IsNullOrWhiteSpace(Role) ? "" : "- " + Role)}";
        }
        
        public void AddAuthorizationHeader(HttpClient _httpClient)
        {
            if (!string.IsNullOrWhiteSpace(Token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Token);
            }
        }

    }

}
