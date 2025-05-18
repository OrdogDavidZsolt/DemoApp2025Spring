using DemoApp2025Spring.Shared;

namespace DemoApp2025Spring.UI.Services
{
    public interface IBooksService
    {
        Task<List<Konyvek>> GetBookAsync();

        Task<Konyvek> GetBookAsync(string id);

        Task AddBookAsync(Konyvek konyv);

        Task UpdateBookAsync(string id, Konyvek konyv);

        Task DeleteBookAsync(string id);
    }
}
