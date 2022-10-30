using TPF.Core.Borders.Repositories;
using TPF.Core.Borders.Repositories.Helpers;
using TPF.Core.Repositories;
using TPF.Core.Repositories.Helpers;

namespace TPF.Core.Api.Configurations
{
    public static class RepositoryConfig
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services.AddSingleton<IRepositoryHelper, RepositoryHelper>()
            .AddSingleton<IUserRepository, UserRepository>()
            .AddSingleton<IFireRepository, FireRepository>();
    }
}