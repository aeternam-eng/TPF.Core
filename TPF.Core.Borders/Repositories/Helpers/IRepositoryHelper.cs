using System.Data;

namespace TPF.Core.Borders.Repositories.Helpers;

public interface IRepositoryHelper
{
    IDbConnection GetConnection();
}
