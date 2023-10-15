using AccountServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AccountServices
{
    public static class ICollectionExtensionService
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddTransient<IBasicService, BasicService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ILookupsService, LookupsService>();
            return services;
        }
    }
}