using TPF.Core.Borders.Repositories;
using TPF.Core.Repositories;
using TPF.Core.Shared.Configurations;

namespace TPF.Core.Api.Configurations
{
    public static class HttpClients
    {
        public static IServiceCollection AddHttpClient(this IServiceCollection services, ApplicationConfig appConfig)
        {
            services.AddHttpClient<IFireRepository, FireRepository>(client =>
            {
                client.BaseAddress = new Uri(appConfig.Endpoint.ApiIa);
                client.DefaultRequestHeaders.Add("Accept", "*/*");
            });

            return services;
        }
    }
}
