using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Entities;

namespace TPF.Core.Borders.Repositories
{
    public interface IDeviceRepository
    {
        Task UpdateDeviceName(Guid deviceId, string newName);
        Task<IEnumerable<DeviceResponse>> GetAllByUserId(Guid userId);
        Task<Device> GetById(Guid id);
    }
}
