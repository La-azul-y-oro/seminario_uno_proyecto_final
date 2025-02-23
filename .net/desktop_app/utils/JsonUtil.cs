using System.Text;
using System.Text.Json;

namespace desktop_app.utils
{
    internal class JsonUtil
    {
        public static HttpContent Serialize<T>(T data)
        {

            string json = JsonSerializer.Serialize(data);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            return content;
        }

        public static async Task<T?> Deserialize<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                return default;

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
