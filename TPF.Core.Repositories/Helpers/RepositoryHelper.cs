using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using TPF.Core.Borders.Repositories.Helpers;

namespace TPF.Core.Repositories.Helpers;

public class RepositoryHelper : IRepositoryHelper
{
    private readonly IConfiguration _appConfig;

    public RepositoryHelper(IConfiguration appConfig)
    {
        _appConfig = appConfig;
    }

    public IDbConnection GetConnection()
    {
        var connectionString = _appConfig.GetConnectionString("DefaultConnection");
        return new NpgsqlConnection(connectionString);
    }
}
