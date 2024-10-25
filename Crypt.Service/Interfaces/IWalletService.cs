using Crypt.Domain;

namespace Crypt.Service.Interfaces
{
    public interface IWalletService
    {
        Task<Wallet> CreateWallet(Wallet wallet);
        Task<Wallet> UpdateWallet(long id, Wallet wallet);
        Task<Wallet> GetWalletById(long id);
        Task DeleteWallet(long id);
        Task<IEnumerable<Wallet>> GetAllWallets();
    }
}
