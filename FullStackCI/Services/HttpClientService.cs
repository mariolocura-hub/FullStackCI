using FullStackCI.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FullStackCI.Services
{
    public class HttpClientService (IHttpClientFactory httpClientFactory)
    {

        private readonly IHttpClientFactory _httpClient = httpClientFactory;

        public async Task<RespuestaHaciendaDTO> GetHaciendaResponse(string cedula)
        {
            try
            {
                var _client = _httpClient.CreateClient("HaciendaApi");
                var response = await _client.GetAsync($"https://api.hacienda.go.cr/fe/ae?identificacion={cedula}");

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<RespuestaHaciendaDTO>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return data;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
