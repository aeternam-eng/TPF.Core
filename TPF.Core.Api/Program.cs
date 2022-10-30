using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TPF.Core.Api.Configurations;
using TPF.Core.Api.Extensions;
using TPF.Core.Api.Middlewares;
using TPF.Core.Api.Models;

var builder = WebApplication.CreateBuilder(args);

var appConfig = builder.Configuration.LoadConfiguration();

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appConfig.Authentication.Secret)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddSingleton(appConfig);
builder.Services.AddSingleton<IActionResultConverter, ActionResultConverter>();

builder.Services.AddValidators();
builder.Services.AddHttpClient(appConfig);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddUseCases();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(config => config.LowercaseUrls = true);

var app = builder.Build();

app.UseSwagger(c =>
{
    c.RouteTemplate = "api-docs/{documentName}/open-api.json";
});
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/api-docs/v1/open-api.json", "TaPegandoFogoBicho.Api v1");
    c.RoutePrefix = "api-docs";
});

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
