using TPF.Core.Borders.Services;
using TPF.Core.UseCases.Services;

namespace TPF.Core.Api.Configurations
{
    public static class ServiceConfig
    {
        public static IServiceCollection AddServices(this IServiceCollection services) =>
            services.AddSingleton<IAuthService, AuthService>();
    }
}
