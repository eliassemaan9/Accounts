using AccountRepository.Helper;
using Microsoft.Extensions.DependencyInjection;

namespace AccountRepository
{
    public static class ICollectionExtensionRepository
    {
        public static IServiceCollection AddServiceRepositories(this IServiceCollection services)
        {
             services.AddTransient<IBasicRepository, BasicRepository>();
             services.AddTransient<IAccountRepository, AccountsRepository>();
             services.AddTransient<ILookupsRepository, LookupsRepository>();
            services.AddTransient<IHelper, Helpers>();
            return services;
        }
    }
}