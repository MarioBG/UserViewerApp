using AspnetCoreMvcFull.Models;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Geo> Geos { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=users.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar la relación entre User y Address como entidad propia
            modelBuilder.Entity<User>()
                .OwnsOne(u => u.address, a =>
                {
                    a.WithOwner();

                // Configurar la relación entre Address y Geo como entidad propia
                a.OwnsOne(ad => ad.geo);
                });

            // Configurar la relación entre User y Company como entidad propia
            modelBuilder.Entity<User>()
                .OwnsOne(u => u.company);
        }
    }
}
