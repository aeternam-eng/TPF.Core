using Dapper;
using System.Data;
using TPF.Core.Borders.Entities;
using TPF.Core.Borders.Repositories;
using TPF.Core.Borders.Repositories.Helpers;

namespace TPF.Core.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IRepositoryHelper _helper;

    public UserRepository(IRepositoryHelper helper)
    {
        _helper = helper;
    }

    public async Task<User> GetUserByEmail(string email)
    {
        const string sql = @"SELECT * FROM users
                                WHERE email = @email";

        using IDbConnection connection = _helper.GetConnection();

        return await connection.QueryFirstOrDefaultAsync<User>(sql, new { email });
    }

    public async Task<User> GetUserById(Guid id)
    {
        const string sql = @"SELECT * FROM users
                                WHERE id = @id";

        using IDbConnection connection = _helper.GetConnection();

        return await connection.QueryFirstOrDefaultAsync<User>(sql, new { id });
    }

    public async Task<bool> CreateUser(User user)
    {
        const string sql = @"INSERT INTO users (id, name, email, secret)
                            VALUES (@Id, @Name, @Email, @Secret)";

        using var connection = _helper.GetConnection();
        return (await connection.ExecuteAsync(sql, new
        {
            Id = Guid.NewGuid(),
            user.Name,
            user.Email,
            user.Secret
        })) > 0;
    }
}
