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

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

    }
}
