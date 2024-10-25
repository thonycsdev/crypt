using System.Linq.Expressions;

using Crypt.Domain;
using Crypt.Repository.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Crypt.Repository.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly DataContext _context;
        private readonly DbSet<Wallet> _entity;

        public WalletRepository(DataContext context)
        {
            _context = context;
            _entity = _context.Wallets!;
        }

        public async Task<Wallet> CreateWallet(Wallet wallet)
        {
            await _entity.AddAsync(wallet);
            await _context.SaveChangesAsync();
            return wallet;
        }

        public Task DeleteCreditCard(long id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteWallet(long id)
        {
            Wallet? walletToDelete = await _entity.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (walletToDelete is null)
                throw new Exception("Wallet id not found in database");
            _entity.Remove(walletToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Wallet>> GetMany(Expression<Func<Wallet, bool>> predicate)
        {
            IEnumerable<Wallet> wallets = await _entity.Where(predicate).ToListAsync();
            return wallets;
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
