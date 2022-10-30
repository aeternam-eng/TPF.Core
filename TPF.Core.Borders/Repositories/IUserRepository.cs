using TPF.Core.Borders.Entities;

namespace TPF.Core.Borders.Repositories;

public interface IUserRepository
{
    Task<User> GetUserByEmail(string email);
    Task<User> GetUserById(Guid id);
}
