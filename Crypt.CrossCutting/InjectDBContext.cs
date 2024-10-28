using Crypt.Repository;

using Microsoft.Extensions.DependencyInjection;

public static class InjectDBContext
{
    public static void InjectDB(this IServiceCollection services)
    {
        var conn_string = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        if (string.IsNullOrEmpty(conn_string))
            throw new Exception("Connection string not Loaded");

        services.AddNpgsql<DataContext>(conn_string);
    }
}
