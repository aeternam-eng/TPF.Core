using TPF.Core.Borders.Entities;

namespace TPF.Core.Borders.Repositories
{
    public interface IDeviceRepository
    {
        Task UpdateDeviceName(Guid deviceId, string newName);
        Task<IEnumerable<Device>> GetAllByUserId(Guid userId);
    }
}
