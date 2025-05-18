using System.Net.Http.Json;
using DemoApp2025Spring.Shared;

namespace DemoApp2025Spring.UI.Services
{
    public class BooksService : IBooksService
    {
        private readonly HttpClient _httpClient;
        public BooksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Konyvek>> GetBookAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Konyvek>>("konyvek");
        }
        public async Task<Konyvek> GetBookAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<Konyvek>($"konyvek/{id}");
        }
        public async Task AddBookAsync(Konyvek book)
        {
            await _httpClient.PostAsJsonAsync("konyvek", book);
        }
        public async Task UpdateBookAsync(string id, Konyvek book)
        {
            await _httpClient.PutAsJsonAsync($"konyvek/{id}", book);
        }
        public async Task DeleteBookAsync(string id)
        {
            await _httpClient.DeleteAsync($"konyvek/{id}");
        }
    }
}
