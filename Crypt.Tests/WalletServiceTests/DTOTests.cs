using AutoFixture;

using Crypt.Domain;
using Crypt.Service.DTO;
using Crypt.Service.Extensions;
using Crypt.Tests.Fixtures;

namespace Crypt.Tests.WalletServiceTests
{
    public class DTOTests
    {
        private readonly Fixture _fixture = BaseTests.CreateFixture();

        [Fact]
        public void ShouldParseTheRequestDTOToEntityCorrectly()
        {
            var requests = new List<WalletRequestDTO>();
            for (int i = 0; i <= 10; i++)
            {
                var request = _fixture.Create<WalletRequestDTO>();
                requests.Add(request);
            }

            requests.ForEach(r =>
            {
                Wallet entity = r.ToEntity();
                entity.Value.Should().Be(r.Value);
                entity.CreditCard.CreditCardNumber.Should().Be(r.CreditCardNumber);
                entity.Document.UserDocument.Should().Be(r.UserDocument);
            });
        }

        [Fact]
        public void ShouldParseTheEntityToTheResponseCorrectly()
        {
            var requests = new List<Wallet>();
            for (int i = 0; i <= 10; i++)
            {
                var request = _fixture.Create<Wallet>();
                requests.Add(request);
            }

            requests.ForEach(e =>
            {
                WalletResponseDTO response = e.ToResponse();
                response.Id.Should().Be(e.Id);
                response.Value.Should().Be(e.Value);
                response.CreditCardNumber.Should().Be(e.CreditCard.CreditCardNumber);
                response.UserDocument.Should().Be(e.Document.UserDocument);
            });
        }
    }
}
