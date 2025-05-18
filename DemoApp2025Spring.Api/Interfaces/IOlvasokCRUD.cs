using DemoApp2025Spring.Shared;

namespace KonyvtarAPI
{
    public interface IOlvasokCRUD
    {
        void Add(Olvasok olvaso);

        List<Olvasok> GetAllOlvasok();

        Olvasok GetOlvaso(int olvasoSzam);

        void Update(Olvasok olvaso);

        void Delete(int olvasoSzam);
    }
}
