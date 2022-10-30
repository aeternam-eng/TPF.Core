using TPF.Core.Shared.Configurations;

namespace TPF.Core.Api.Extensions;

public static class ConfigurationExtensions
{
    public static ApplicationConfig LoadConfiguration(this IConfiguration source)
    {
        var applicationConfig = source.Get<ApplicationConfig>();

        return applicationConfig;
    }
}
