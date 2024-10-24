using System.Linq.Expressions;

using Crypt.Domain;
using Crypt.Repository.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Crypt.Repository.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly DbSet<Wallet> _dbSet;

        public WalletRepository(DataContext context)
        {
            _dbSet = context.Set<Wallet>();
        }

        public Task<Wallet> CreateWallet(Wallet wallet)
        {
            throw new NotImplementedException();
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
