using desktop_app.auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desktop_app.services
{
    internal class MovementService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthService _authService;
        private readonly string _baseUrl = "https://localhost:7057/api/movement";

        public MovementService(AuthService authService) {
            _authService = authService;
            _httpClient = new HttpClient { BaseAddress = new Uri(_baseUrl) };
        }
    }
}
