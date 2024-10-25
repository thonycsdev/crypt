using Crypt.Domain;
using Microsoft.EntityFrameworkCore;

namespace Crypt.Repository
{
    public class DataContext : DbContext
    {
        public DbSet<Wallet>? Wallets { get; set; }

        public DataContext(DbContextOptions<DataContext> opt)
            : base(opt) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string? connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("CONNECTION_STRING not loaded");

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
