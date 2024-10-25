using AutoFixture;
using Crypt.Domain;
using Crypt.Repository.Interfaces;
using Crypt.Service.DTO;
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

        [Fact]
        public async void WhenCreatingAWalletShouldReturnAResponseWithTheCardNumberCrypted()
        {
            var service = new WalletService(_walletMockRepository, _cryptService);
            var walletRequest = _fixture.Create<WalletRequestDTO>();
            var wallet = new Wallet
            {
                CreditCardNumber = walletRequest.CreditCardNumber,
                Value = walletRequest.Value,
                UserDocument = walletRequest.UserDocument,
            };
            wallet.CreditCardNumber = _cryptService.Hash(wallet.CreditCardNumber);
            wallet.UserDocument = _cryptService.Hash(wallet.UserDocument);

            _walletMockRepository.CreateWallet(Arg.Any<Wallet>()).Returns(wallet);

            var result = await service.CreateWallet(walletRequest);

            result.CreditCardNumber.Should().Be(wallet.CreditCardNumber);
        }
    }
}
