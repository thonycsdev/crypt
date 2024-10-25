using Crypt.Domain;
using Crypt.Repository.Interfaces;
using Crypt.Service.Interfaces;

namespace Crypt.Service.Services
{
    public class WalletService : IWalletService
    {
        public WalletService(IWalletRepository _repository, ICryptService _cryptService) { }

        public Task<Wallet> CreateWallet(Wallet wallet)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWallet(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Wallet>> GetAllWallets()
        {
            throw new NotImplementedException();
        }

        public Task<Wallet> GetWalletById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Wallet> UpdateWallet(long id, Wallet wallet)
        {
            throw new NotImplementedException();
        }
    }
}
