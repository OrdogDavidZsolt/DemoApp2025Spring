using System.Net.Http.Json;
using DemoApp2025Spring.Shared;

namespace DemoApp2025Spring.UI.Services
{
    public class ReadersService : IReadersService
    {
        private readonly HttpClient _httpClient;
        public ReadersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Olvasok>> GetReaderAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Olvasok>>("olvasok");
        }
        public async Task<Olvasok> GetReaderAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<Olvasok>($"olvasok/{id}");
        }
        public async Task AddReaderAsync(Olvasok reader)
        {
            await _httpClient.PostAsJsonAsync("olvasok", reader);
        }
        public async Task UpdateReaderAsync(string id, Olvasok reader)
        {
            await _httpClient.PutAsJsonAsync($"olvasok/{id}", reader);
        }
        public async Task DeleteReaderAsync(string id)
        {
            await _httpClient.DeleteAsync($"olvasok/{id}");
        }
    }
}
