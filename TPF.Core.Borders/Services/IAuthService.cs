using TPF.Core.Borders.Entities;

namespace TPF.Core.Borders.Services
{
    public interface IAuthService
    {
        string GenerateToken(User user);
    }
}
