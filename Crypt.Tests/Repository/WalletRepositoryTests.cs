using AutoFixture;

using Crypt.Domain;
using Crypt.Repository.Repositories;
using Crypt.Tests.Fixtures;

namespace Crypt.Tests.Repository
{
    public class WalletRepositoryTests
    {
        [Fact]
        public async void GetSingleShouldReturnAEntityInsertedInTheDatabase()
        {
            using (var ctx = new InMemoryDatabaseContext().Create())
            {
                var repository = new WalletRepository(ctx);
                var fixture = new Fixture().Create<Wallet>();
                var result = await ctx.AddAsync(fixture);
                await ctx.SaveChangesAsync();

                var entity = await repository.GetSingle(e => e.Id == result.Entity.Id);
                Console.WriteLine(entity.CreditCardNumber);
            }
        }
    }
}
