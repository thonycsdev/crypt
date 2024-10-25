using System.Linq.Expressions;

using Crypt.Domain;
using Crypt.Repository.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Crypt.Repository.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly DbSet<Wallet> _dbSet;
        private readonly DataContext _context;

        public WalletRepository(DataContext context)
        {
            _dbSet = context.Set<Wallet>();
            _context = context;
        }

        public async Task<Wallet> CreateWallet(Wallet wallet)
        {
            await _dbSet.AddAsync(wallet);
            await _context.SaveChangesAsync();
            return wallet;
        }

        public Task DeleteCreditCard(long id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWallet(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Wallet>> GetMany(Expression<Func<Wallet, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Wallet> GetSingle(Expression<Func<Wallet, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Wallet> UpdateWallet(long id, Wallet wallet)
        {
            throw new NotImplementedException();
        }
    }
}
