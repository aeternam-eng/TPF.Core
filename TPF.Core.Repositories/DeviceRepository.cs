using Dapper;
using TPF.Core.Borders.Entities;
using TPF.Core.Borders.Repositories;
using TPF.Core.Borders.Repositories.Helpers;

namespace TPF.Core.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IRepositoryHelper _helper;

        public DeviceRepository(IRepositoryHelper helper)
        {
            _helper = helper;
        }

        public async Task UpdateDeviceName(Guid deviceId, string newName)
        {
            const string sql = "UPDATE device SET name=@name WHERE id=@deviceId";

            using var connection = _helper.GetConnection();

            await connection.ExecuteAsync(sql, new { deviceId, name = newName });
        }

        public async Task<IEnumerable<Device>> GetAllByUserId(Guid userId)
        {
            const string sql = "SELECT * FROM device WHERE user_id=@userId";

            using var connection = _helper.GetConnection();

            return await connection.QueryAsync<Device>(sql, new { userId });
        }

        public async Task<Device> GetById(Guid id)
        {
            const string sql = "SELECT * FROM device WHERE id=@Id";

            using var connection = _helper.GetConnection();

            return await connection.QueryFirstAsync<Device>(sql, new { id });
        }
    }
}
