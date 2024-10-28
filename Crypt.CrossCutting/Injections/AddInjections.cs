using Crypt.Repository.Interfaces;
using Crypt.Repository.Repositories;
using Crypt.Service.Interfaces;
using Crypt.Service.Services;

using Microsoft.Extensions.DependencyInjection;

namespace Crypt.CrossCutting.Injections
{
    public static class Injections
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<ICryptService, CryptService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IWalletRepository, WalletRepository>();
        }
    }
}
