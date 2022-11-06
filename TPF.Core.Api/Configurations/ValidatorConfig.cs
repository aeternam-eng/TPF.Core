using TPF.Core.Borders.Validators;

namespace TPF.Core.Api.Configurations
{
    public static class ValidatorConfig
    {
        public static IServiceCollection AddValidators(this IServiceCollection services) =>
            services.AddSingleton<AuthRequestValidator>()
            .AddSingleton<FireValidator>()
            .AddSingleton<GuidValidator>();
    }
}