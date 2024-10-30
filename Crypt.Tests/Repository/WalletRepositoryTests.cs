using AutoFixture;

using Crypt.Domain;
using Crypt.Repository.Repositories;
using Crypt.Tests.Fixtures;

using Microsoft.EntityFrameworkCore;

namespace Crypt.Tests.Repository
{
    public class WalletRepositoryTests
    {
        private readonly Fixture _fixture = BaseTests.CreateFixture();

        [Fact]
        public async Task GetSingleShouldReturnAEntityInsertedInTheDatabase()
        {
            using (var ctx = new InMemoryDatabaseContext().Create())
            {
                var repository = new WalletRepository(ctx);
                var fixture = _fixture.Create<Wallet>();
                var result = await ctx.AddAsync(fixture);
                await ctx.SaveChangesAsync();

                var entity = await repository.GetSingle(e => e.Id == result.Entity.Id);
                entity.Should().NotBeNull();
                entity.Document.UserDocument.Should().Be(fixture.Document.UserDocument);
            }
        }

        [Fact]
        public async Task WhenNoEntityIsFoundShouldThrowAnError()
        {
            using (var ctx = new InMemoryDatabaseContext().Create())
            {
                var repository = new WalletRepository(ctx);
                var fixture = _fixture.Create<Wallet>();

                Func<Task> action = async () => await repository.GetSingle(e => e.Id == fixture.Id);

                await action.Should().ThrowAsync<Exception>("Entity not found!");
            }
        }

        [Fact]
        public async Task GetSingleShouldThrowAnErrorWhenNoPredicateIsProvided()
        {
            using (var ctx = new InMemoryDatabaseContext().Create())
            {
                var repository = new WalletRepository(ctx);
                Func<Task> action = async () => await repository.GetSingle(predicate: null!);
                await action
                    .Should()
                    .ThrowAsync<ArgumentException>("Closure function not provided");
            }
        }

        [Fact]
        public async Task ShouldDeleteEntityWhenProvidedIdExistsInDatabase()
        {
            using (var ctx = new InMemoryDatabaseContext().Create())
            {
                var repository = new WalletRepository(ctx);
                var fixture = _fixture.Create<Wallet>();
                var result = await ctx.AddAsync(fixture);
                await ctx.SaveChangesAsync();

                await repository.DeleteWallet(fixture.Id);

                var entitiesInDatabase = await ctx.Wallets!.ToListAsync();
                bool exists = entitiesInDatabase.Exists(x => x.Id == fixture.Id);
                exists.Should().Be(false);
            }
        }

        [Fact]
        public async Task WhenNoEntityIsFoundWithThisIdShouldThrowAnId()
        {
            using (var ctx = new InMemoryDatabaseContext().Create())
            {
                var repository = new WalletRepository(ctx);
                var fixture = _fixture.Create<Wallet>();

                Func<Task> action = async () => await repository.DeleteWallet(fixture.Id);

                await action.Should().ThrowAsync<Exception>("Entity not found!");
            }
        }

        [Fact]
        public async Task GetManyShouldAlwaysReturnAArrayEvenWithLengthZero()
        {
            using (var ctx = new InMemoryDatabaseContext().Create())
            {
                var repository = new WalletRepository(ctx);
                var results = await repository.GetMany();
                results.ToArray().Length.Should().Be(0);
            }
        }

        [Fact]
        public async Task ShouldReturnTheAmountOfWalletInsertedInTheDatabase()
        {
            using (var ctx = new InMemoryDatabaseContext().Create())
            {
                int amount = 5;
                for (int i = 0; i < amount; i++)
                {
                    var fixture = _fixture.Create<Wallet>();
                    await ctx.AddAsync(fixture);
                    await ctx.SaveChangesAsync();
                }
                var repository = new WalletRepository(ctx);
                var results = await repository.GetMany();
                results.ToArray().Length.Should().Be(amount);
            }
        }

        [Fact]
        public async Task ShouldIncreaseTheLenghtBy1WhenCreateWalletIsCalled()
        {
            using (var ctx = new InMemoryDatabaseContext().Create())
            {
                var fixture = _fixture.Create<Wallet>();
                var repository = new WalletRepository(ctx);
                await repository.CreateWallet(fixture);

                var databaseResults = await ctx.Wallets!.ToListAsync();
                databaseResults.ToArray().Length.Should().Be(1);
            }
        }

        [Fact]
        public async Task ShouldThrowAnErrorWhenTheWalletHasUserDocumentAsEmpty()
        {
            using (var ctx = new InMemoryDatabaseContext().Create())
            {
                var fixture = _fixture.Create<Wallet>();
                fixture.Document.UserDocument = "";
                var repository = new WalletRepository(ctx);
                Func<Task> action = async () => await repository.CreateWallet(fixture);
                await action.Should().ThrowAsync<ArgumentException>("Invalid entity attribute");
            }
        }

        [Fact]
        public async Task ShouldThrowAnErrorWhenTheWalletHasCreditCardNumberAsEmpty()
        {
            using (var ctx = new InMemoryDatabaseContext().Create())
            {
                var fixture = _fixture.Create<Wallet>();
                fixture.CreditCard.CreditCardNumber = "";
                var repository = new WalletRepository(ctx);
                Func<Task> action = async () => await repository.CreateWallet(fixture);
                await action.Should().ThrowAsync<ArgumentException>("Invalid entity attribute");
            }
        }
    }
}
