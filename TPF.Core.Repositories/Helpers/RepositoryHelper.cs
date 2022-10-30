using Npgsql;
using System.Data;
using TPF.Core.Borders.Repositories.Helpers;
using TPF.Core.Shared.Configurations;

namespace TPF.Core.Repositories.Helpers;

public class RepositoryHelper : IRepositoryHelper
{
    private readonly ApplicationConfig _appConfig;

    public RepositoryHelper(ApplicationConfig appConfig)
    {
        _appConfig = appConfig;
    }

    public IDbConnection GetConnection()
    {
        return new NpgsqlConnection(_appConfig.ConnectionStrings.DefaultConnection);
    }
}
