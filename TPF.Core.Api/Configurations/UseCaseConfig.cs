using TPF.Core.Borders.UseCases.Auth;
using TPF.Core.Borders.UseCases.Fire;
using TPF.Core.Borders.UseCases.User;
using TPF.Core.UseCases.Auth;
using TPF.Core.UseCases.Fire;
using TPF.Core.UseCases.User;

namespace TPF.Core.Api.Configurations
{
    public static class UseCaseConfig
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services) =>
            services.AddSingleton<IAuthenticationUseCase, AuthenticationUseCase>()
            .AddSingleton<IGetUserByIdUseCase, GetUserByIdUseCase>()
            .AddSingleton<IGetFireUseCase, GetFireUseCase>();
    }
}