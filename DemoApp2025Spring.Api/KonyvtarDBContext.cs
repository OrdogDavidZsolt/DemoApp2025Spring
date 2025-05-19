using DemoApp2025Spring.Shared;
using Microsoft.EntityFrameworkCore;

namespace DemoApp2025Spring.Api
{
    public class KonyvtarDBContext : DbContext
    {
        public KonyvtarDBContext(DbContextOptions options) 
            :base(options)
        {
        }

        public virtual DbSet<Konyvek> Konyvek { get; set; }
        public virtual DbSet<Kolcsonzes> Kolcsonzesek { get; set; }
        public virtual DbSet<Olvasok> Olvasok { get; set; }
    }
}
