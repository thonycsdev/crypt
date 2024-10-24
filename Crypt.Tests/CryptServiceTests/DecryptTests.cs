using Crypt.Service.Interfaces;
using Crypt.Service.Services;

namespace Crypt.Tests.CryptServiceTests
{
    public class DecryptTest
    {
        public Faker faker = new Faker();

        public DecryptTest() { }

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
            Console.WriteLine(cardNumber);
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
    }
}
