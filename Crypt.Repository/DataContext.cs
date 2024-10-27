using Crypt.Domain;

using Microsoft.EntityFrameworkCore;

namespace Crypt.Repository
{
    public class DataContext : DbContext
    {
        public DbSet<Wallet>? Wallets { get; set; }

        public DataContext(DbContextOptions<DataContext> opt)
            : base(opt) { }
    }
}
