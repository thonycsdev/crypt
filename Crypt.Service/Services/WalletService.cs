using Crypt.Domain;
using Crypt.Repository.Interfaces;
using Crypt.Service.DTO;
using Crypt.Service.Interfaces;

namespace Crypt.Service.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _repository;
        private readonly ICryptService _cryptService;

        public WalletService(IWalletRepository repository, ICryptService cryptService)
        {
            _repository = repository;
            _cryptService = cryptService;
        }

        public async Task<WalletResponseDTO> CreateWallet(WalletRequestDTO request)
        {
            var entity = new Wallet
            {
                CreditCardNumber = request.CreditCardNumber,
                Value = request.Value,
                UserDocument = request.UserDocument,
            };

            entity.CreditCardNumber = _cryptService.Hash(entity.CreditCardNumber);
            entity.UserDocument = _cryptService.Hash(entity.UserDocument);

            var result = await _repository.CreateWallet(entity);

            var response = new WalletResponseDTO
            {
                Id = result.Id,
                UserDocument = result.UserDocument,
                Value = result.Value,
                CreditCardNumber = result.CreditCardNumber,
            };

            return response;
        }

        public async Task DeleteWallet(long id)
        {
            if (id.Equals(0))
                throw new ArgumentNullException("Id not provided");
            await _repository.DeleteWallet(id);
        }

        public Task<IEnumerable<WalletResponseDTO>> GetAllWallets()
        {
            throw new NotImplementedException();
        }

        public Task<WalletResponseDTO> GetWalletById(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<WalletResponseDTO> UpdateWallet(long id, WalletRequestDTO wallet)
        {
            if (id.Equals(0))
                throw new ArgumentNullException("Id not provided");

            var entity = await _repository.GetSingle(e => e.Id == id);
            return new WalletResponseDTO();
        }
    }
}
