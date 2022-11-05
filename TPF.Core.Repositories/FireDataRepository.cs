using Dapper;
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

        public async Task Insert(bool isFogoBicho, decimal probability, Guid deviceId)
        {
            string sql = @"INSERT INTO public.fire_data
                            (id, device_id, is_fogo_bixo, image_fire_probability, date_time)
                        VALUES(@Id, @DeviceId, @IsFogoBixo, @ImageFireProbability, @Date)";

            using var connection = _helper.GetConnection();
            await connection.ExecuteAsync(sql, new { Id = Guid.NewGuid(), IsFogoBixo = isFogoBicho, ImageFireProbability = probability, DeviceId = deviceId, Date = DateTime.UtcNow });
        }
    }
}
