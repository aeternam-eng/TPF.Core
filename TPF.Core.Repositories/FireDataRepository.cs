using Dapper;
using TPF.Core.Borders.Entities;
using TPF.Core.Borders.Repositories;
using TPF.Core.Borders.Repositories.Helpers;

namespace TPF.Core.Repositories
{
    public class FireDataRepository : IFireDataRepository
    {
        private readonly IRepositoryHelper _helper;

        public FireDataRepository(IRepositoryHelper helper)
        {
            _helper = helper;
        }

        public async Task Insert(bool isFogoBicho, decimal probability, Guid deviceId, string? imageUrl)
        {
            string sql = @"INSERT INTO fire_data
                            (id, device_id, is_fogo_bixo, image_fire_probability, date_time, image_url)
                        VALUES(@Id, @DeviceId, @IsFogoBixo, @ImageFireProbability, @Date, @ImageUrl)";

            using var connection = _helper.GetConnection();
            await connection.ExecuteAsync(sql, new { Id = Guid.NewGuid(), IsFogoBixo = isFogoBicho, ImageFireProbability = probability, DeviceId = deviceId, Date = DateTime.UtcNow, ImageUrl = imageUrl });
        }

        public async Task<IEnumerable<Fire_Data>> GetAllByUserId(Guid id)
        {
            string sql = @"select f.* from users u
                            join device d on d.user_id = u.id and u.id = @id
                            join fire_data f on f.device_id = d.id
                            where f.is_fogo_bixo = true
                            order by f.date_time";

            using var connection = _helper.GetConnection();
            return await connection.QueryAsync<Fire_Data>(sql, new { Id = id });
        }
    }
}
