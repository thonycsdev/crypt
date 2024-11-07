using Crypt.Repository.Interfaces;
using Crypt.Service.DTO;
using Crypt.Service.Extensions;
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
            var entity = request.ToEntity();

            _cryptService.HashWalletInformation(ref entity);
            entity.CreditCard.CreditCardNumber = request.CreditCardNumber;
            entity.Document.UserDocument = request.CreditCardNumber;

            var result = await _repository.CreateWallet(entity);

            var response = result.ToResponse();

            return response;
        }

        public async Task DeleteWallet(long id)
        {
            if (id.Equals(0))
                throw new ArgumentNullException("Id not provided");
            await _repository.DeleteWallet(id);
        }

        public async Task<IEnumerable<WalletResponseDTO>> GetAllWallets()
        {
            var result = await _repository.GetMany();
            var result_json = System.Text.Json.JsonSerializer.Serialize(result);
            Console.WriteLine(result_json);
            var responses = result.Select(e => e.ToResponse());
            return responses;
        }

        public async Task<WalletResponseDTO> GetWalletById(long id)
        {
            var entity = await _repository.GetSingle(e => e.Id == id);
            return entity.ToResponse();
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
