    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    namespace HayvanBarinagi.Models
    {
        public class HayvanBarinagiContext : IdentityDbContext<Kullanici>
        {
            public HayvanBarinagiContext(DbContextOptions<HayvanBarinagiContext> options) : base(options)
            {
            }

            public DbSet<Hayvan> Hayvanlar { get; set; }
            public DbSet<SahiplendirmeBasvurulari> SahiplendirmeBasvurulari { get; set; }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);

           
            }
        }
    }
