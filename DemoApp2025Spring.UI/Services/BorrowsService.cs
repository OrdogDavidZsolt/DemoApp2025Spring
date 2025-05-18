using System.Net.Http.Json;
using DemoApp2025Spring.Shared;

namespace DemoApp2025Spring.UI.Services
{
    public class BorrowsService : IBorrowsService
    {
        private readonly HttpClient _httpClient;
        public BorrowsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Kolcsonzes>> GetBorrowAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Kolcsonzes>>("kolcsonzes");
        }
        public async Task<Kolcsonzes> GetBorrowAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<Kolcsonzes>($"kolcsonzes/{id}");
        }
        public async Task AddBorrowAsync(Kolcsonzes kolcsonzes)
        {
            await _httpClient.PostAsJsonAsync("kolcsonzes", kolcsonzes);
        }
        public async Task UpdateBorrowAsync(string id, Kolcsonzes kolcsonzes)
        {
            await _httpClient.PutAsJsonAsync($"kolcsonzes/{id}", kolcsonzes);
        }
        public async Task DeleteBorrowAsync(string id)
        {
            await _httpClient.DeleteAsync($"kolcsonzes/{id}");
        }
    }
}
