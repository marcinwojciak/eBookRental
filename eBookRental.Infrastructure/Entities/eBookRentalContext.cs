using eBookRental.Core.Domain;
using eBookRental.Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;

namespace eBookRental.Infrastructure.Entities
{
    public class eBookRentalContext  : DbContext
    {
        private readonly SqlSettings _sqlSettings;

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public eBookRentalContext(DbContextOptions<eBookRentalContext> options, SqlSettings sqlSettings) 
            : base(options)
        {
            _sqlSettings = sqlSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_sqlSettings.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase();
                return;
            }
            optionsBuilder.UseSqlServer(_sqlSettings.ConnectionString, 
                b => b.MigrationsAssembly("eBookRental.Api"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new EntityUserConfiguration(modelBuilder.Entity<User>());
            new EntityBookConfiguration(modelBuilder.Entity<Book>());
            new EntityGenreConfiguration(modelBuilder.Entity<Genre>());
            new EntitySetConfiguration(modelBuilder.Entity<Set>());
            new EntityRentalConfiguration(modelBuilder.Entity<Rental>());
        }
    }
}
