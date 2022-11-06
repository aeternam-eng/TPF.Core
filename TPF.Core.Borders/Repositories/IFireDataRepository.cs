using TPF.Core.Borders.Entities;

namespace TPF.Core.Borders.Repositories
{
    public interface IFireDataRepository
    {
        Task Insert(bool isFogoBicho, decimal probability, Guid deviceId);
        Task<IEnumerable<Fire_Data>> GetAllByUserId(Guid id);
    }
}
