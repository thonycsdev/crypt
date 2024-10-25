using Crypt.Repository.Interfaces;
using Crypt.Service.DTO;
using Crypt.Service.Interfaces;

namespace Crypt.Service.Services
{
    public class WalletService : IWalletService
    {
        public WalletService(IWalletRepository _repository, ICryptService _cryptService) { }

        public Task<WalletResponseDTO> CreateWallet(WalletRequestDTO wallet)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWallet(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WalletResponseDTO>> GetAllWallets()
        {
            throw new NotImplementedException();
        }

        public Task<WalletResponseDTO> GetWalletById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<WalletResponseDTO> UpdateWallet(long id, WalletRequestDTO wallet)
        {
            throw new NotImplementedException();
        }
    }
}
