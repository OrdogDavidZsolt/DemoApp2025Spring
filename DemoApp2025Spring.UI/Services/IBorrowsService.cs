using DemoApp2025Spring.Shared;

namespace DemoApp2025Spring.UI.Services
{
    public interface IBorrowsService
    {
        Task<List<Kolcsonzes>> GetBorrowAsync();

        Task<Kolcsonzes> GetBorrowAsync(string id);

        Task AddBorrowAsync(Kolcsonzes kolcsonzes);

        Task UpdateBorrowAsync(string id, Kolcsonzes kolcsonzes);

        Task DeleteBorrowAsync(string id);
    }
}
