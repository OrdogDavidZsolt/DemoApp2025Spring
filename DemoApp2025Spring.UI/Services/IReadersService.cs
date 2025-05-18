using DemoApp2025Spring.Shared;

namespace DemoApp2025Spring.UI.Services
{
    public interface IReadersService
    {
        Task<List<Olvasok>> GetReaderAsync();

        Task<Olvasok> GetReaderAsync(string id);

        Task AddReaderAsync(Olvasok olvaso);

        Task UpdateReaderAsync(string id, Olvasok olvaso);

        Task DeleteReaderAsync(string id);
    }
}
