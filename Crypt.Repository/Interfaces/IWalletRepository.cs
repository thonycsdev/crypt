using System.Linq.Expressions;
using Crypt.Domain;

namespace Crypt.Repository.Interfaces
{
    public interface IWalletRepository
    {
        Task<Wallet> CreateWallet(Wallet wallet);
        Task<Wallet> UpdateWallet(Wallet wallet);
        Task<Wallet> GetSingle(Expression<Func<Wallet, bool>> predicate);
        Task<IEnumerable<Wallet>> GetMany(Expression<Func<Wallet, bool>>? predicate);
        Task DeleteWallet(long id);
        Task DeleteCreditCard(long id);
    }
}
