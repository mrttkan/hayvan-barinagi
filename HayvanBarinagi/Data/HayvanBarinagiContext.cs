using Microsoft.EntityFrameworkCore;

namespace HayvanBarinagi.Models
{
    public class HayvanBarinagiContext : DbContext
    {
        public HayvanBarinagiContext(DbContextOptions<HayvanBarinagiContext> options) : base(options)
        {
        }

        public DbSet<Hayvan> Hayvans { get; set; }
        public DbSet<SahiplendirmeBasvurusu> SahiplendirmeBasvurusus { get; set; }
    }
}
