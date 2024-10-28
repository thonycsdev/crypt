using Crypt.Service.DTO;
using Crypt.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Crupt.API.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly IWalletService _service;

        public CreditCardController(IWalletService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<WalletResponseDTO>> GetAll()
        {
            var result = await _service.GetAllWallets();
            return result;
        }

        [HttpPost]
        public async Task<WalletResponseDTO> Create(WalletRequestDTO request)
        {
            var result = await _service.CreateWallet(request);
            return result;
        }
    }
}
