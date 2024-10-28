using Crypt.Domain;
using Crypt.Repository.Configurations;

using Microsoft.EntityFrameworkCore;

namespace Crypt.Repository
{
    public class DataContext : DbContext
    {
        public DbSet<Wallet>? Wallets { get; set; }
        public DbSet<CreditCard>? CreditCards { get; set; }
        public DbSet<Document>? Documents { get; set; }

        public DataContext(DbContextOptions<DataContext> opt)
            : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CreditCardConfiguration).Assembly);
        }
    }
}
