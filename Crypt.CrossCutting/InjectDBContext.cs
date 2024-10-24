using Crypt.Repository;

using Microsoft.Extensions.DependencyInjection;

public static class InjectDBContext
{
    public static void InjectDB(this IServiceCollection services)
    {
        services.AddDbContext<DataContext>();
    }
}
