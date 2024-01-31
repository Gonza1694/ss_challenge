using Microsoft.EntityFrameworkCore;
using SpeedSolutionsChallenge.Data.Models;

namespace SpeedSolutionsChallenge.Data.DBContext
{
    public class AppDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Dispenser> Dispensers { get; set; }
        public DbSet<Hose> Hoses { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GON;Database=SpeedSolutionsDB;Integrated Security=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(255);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Hoses)
                .WithOne(h => h.Product)
                .HasForeignKey(h => h.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>()
                .HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<Price>()
                .HasKey(p => p.PriceId);

            modelBuilder.Entity<Price>()
                .HasOne(p => p.Product)
                .WithMany(p => p.Prices)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Dispenser>()
                .HasKey(d => d.DispenserId);

            modelBuilder.Entity<Dispenser>()
                .HasMany(d => d.Hoses)
                .WithOne(h => h.Dispenser)
                .HasForeignKey(h => h.DispenserId);

            modelBuilder.Entity<Hose>()
                .HasKey(h => h.HoseId);

            modelBuilder.Entity<Hose>()
                .Property(h => h.Name)
                .HasMaxLength(255);

            modelBuilder.Entity<Hose>()
                .HasOne(h => h.Product)
                .WithMany(p => p.Hoses)
                .HasForeignKey(h => h.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Hose>()
                .HasOne(h => h.Dispenser)
                .WithMany(d => d.Hoses)
                .HasForeignKey(h => h.DispenserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Hose>()
                .HasQueryFilter(h => !h.IsDeleted);
        }

    }
}
