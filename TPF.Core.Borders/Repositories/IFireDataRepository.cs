using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Entities;

namespace TPF.Core.Borders.Repositories
{
    public interface IFireDataRepository
    {
        Task Insert(GetFireResponse model, string? imgUrl, Guid deviceId);
        Task<IEnumerable<Fire_Data>> GetAllByUserId(Guid id);
    }
}
