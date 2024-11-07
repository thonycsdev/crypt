using AutoFixture;

using Crypt.Domain;
using Crypt.Service.Interfaces;
using Crypt.Service.Services;
using Crypt.Tests.Fixtures;

namespace Crypt.Tests.CryptServiceTests
{
    public class DecryptTest
    {
        public Faker faker = new Faker();
        public Fixture fixture = BaseTests.CreateFixture();

        [Fact]
        public void ShouldHashTheWalletInformationCorrectly()
        {
            ICryptService service = new CryptService();
            var entity = fixture.Create<Wallet>();
            var card = entity.CreditCard.CreditCardNumber;
            var document = entity.Document.UserDocument;

            service.HashWalletInformation(ref entity);

            entity.CreditCard.CreditCardNumberHash.Should().NotBe(card);
            entity.Document.UserDocumentHash.Should().NotBe(document);
        }

        [Fact]
        public void ShouldThrowAnErrorWhenNoDataIsPassedToTheFunction()
        {
            ICryptService service = new CryptService();
            Action action = () => service.Hash(string.Empty);
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void ShouldReturnADiferentStringFromThatWasInputed()
        {
            string cardNumber = faker.Finance.CreditCardNumber().ToString();
            ICryptService service = new CryptService();
            string result = service.Hash(cardNumber);
            result.Should().NotBe(cardNumber);
        }

        [Fact]
        public void ShouldCreateTheSameHashForTheSameString()
        {
            string cardNumber = faker.Finance.CreditCardNumber().ToString();
            ICryptService service = new CryptService();
            string result1 = service.Hash(cardNumber);
            string result2 = service.Hash(cardNumber);
            result1.Length.Should().Be(result2.Length);
            result1.Should().Be(result2);
        }

        [Fact]
        public void AnyHashingShouldHavingTheSameLengthNoMatterTheInput()
        {
            string cardNumber = faker.Finance.CreditCardNumber().ToString();
            ICryptService service = new CryptService();
            int lenght = service.Hash(cardNumber).Length;

            for (int i = 0; i < 50; i++)
            {
                string newCardNumber = faker.Finance.CreditCardNumber().ToString();
                string result = service.Hash(newCardNumber);
                result.Length.Should().Be(lenght);
            }
        }
    }
}
