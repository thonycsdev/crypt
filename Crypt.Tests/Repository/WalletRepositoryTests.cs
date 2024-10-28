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
        public async void GetSingleShouldReturnAEntityInsertedInTheDatabase()
        {
            using (var ctx = new InMemoryDatabaseContext().Create())
            {
                var repository = new WalletRepository(ctx);
                var fixture = _fixture.Create<Wallet>();
                var result = await ctx.AddAsync(fixture);
                await ctx.SaveChangesAsync();

                var entity = await repository.GetSingle(e => e.Id == result.Entity.Id);
                entity.Should().NotBeNull();
                entity.UserDocument.Should().Be(fixture.UserDocument);
            }
        }

        [Fact]
        public async void WhenNoEntityIsFoundShouldThrowAnError()
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
        public async void GetSingleShouldThrowAnErrorWhenNoPredicateIsProvided()
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
        public async void ShouldDeleteEntityWhenProvidedIdExistsInDatabase()
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
        public async void WhenNoEntityIsFoundWithThisIdShouldThrowAnId()
        {
            using (var ctx = new InMemoryDatabaseContext().Create())
            {
                var repository = new WalletRepository(ctx);
                var fixture = _fixture.Create<Wallet>();

                Func<Task> action = async () => await repository.DeleteWallet(fixture.Id);

                await action.Should().ThrowAsync<Exception>("Entity not found!");
            }
        }
    }
}
