using Crypt.Repository;

using Microsoft.EntityFrameworkCore;

namespace Crypt.Tests.Fixtures
{
    public class InMemoryDatabaseContext()
    {
        public DataContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(
                Guid.NewGuid().ToString()
            );

            var ctx = new DataContext(optionsBuilder.Options);
            return ctx;
        }
    }
}
