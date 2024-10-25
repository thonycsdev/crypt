using Crypt.Service.DTO;

namespace Crypt.Service.Interfaces
{
    public interface IWalletService
    {
        Task<WalletResponseDTO> CreateWallet(WalletRequestDTO wallet);
        Task<WalletResponseDTO> UpdateWallet(long id, WalletRequestDTO wallet);
        Task<WalletResponseDTO> GetWalletById(long id);
        Task DeleteWallet(long id);
        Task<IEnumerable<WalletResponseDTO>> GetAllWallets();
    }
}
