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
            if (
                string.IsNullOrEmpty(wallet.Document.UserDocument)
                || string.IsNullOrEmpty(wallet.CreditCard.CreditCardNumber)
            )
                throw new ArgumentException("Invalid entity attribute");
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
            Wallet? walletToDelete = await this.GetSingle(e => e.Id == id);
            if (walletToDelete is null)
                throw new Exception("Wallet id not found in database");
            _entity.Remove(walletToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Wallet>> GetMany(
            Expression<Func<Wallet, bool>>? predicate = null
        )
        {
            if (predicate is not null)
            {
                return await _entity
                    .Where(predicate)
                    .Include(x => x.Document)
                    .Include(x => x.CreditCard)
                    .ToListAsync();
            }
            return await _entity.Include(x => x.Document).Include(x => x.CreditCard).ToListAsync();
        }

        public async Task<Wallet> GetSingle(Expression<Func<Wallet, bool>> predicate)
        {
            Wallet? wallet = await _entity.Where(predicate).FirstOrDefaultAsync();
            if (wallet is null)
                throw new Exception("Entity not found!");
            return wallet;
        }

        public async Task<Wallet> UpdateWallet(Wallet wallet)
        {
            _entity.Update(wallet);
            await _context.SaveChangesAsync();
            return wallet;
        }
    }
}
