using AutoFixture;
using Crypt.Repository.Interfaces;
using Crypt.Service.Interfaces;
using Crypt.Service.Services;
using NSubstitute;

namespace Crypt.Tests.Services
{
    public class WalletServiceTest
    {
        private readonly Fixture _fixture;
        private readonly IWalletRepository _walletMockRepository;
        private readonly ICryptService _cryptService;

        public WalletServiceTest()
        {
            _fixture = new Fixture();
            _cryptService = new CryptService();
            _walletMockRepository = Substitute.For<IWalletRepository>();
        }
    }
}
