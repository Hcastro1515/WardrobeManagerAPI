using Microsoft.EntityFrameworkCore;
using WardrobeManagerAPI.Entities;

namespace WardrobeManagerAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Wardrobe> Wardrobes => Set<Wardrobe>();
        public DbSet<WardrobeItem> WardrobeItems  => Set<WardrobeItem>();
        public DbSet<WardrobeItemImageFile> ItemImages => Set<WardrobeItemImageFile>(); 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Wardrobe>().HasIndex(x => x.Name).IsUnique();
        }
    }
}
