using Dapper;
using TPF.Core.Borders.Dtos;
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

        public async Task Insert(GetFireResponse model, Guid deviceId)
        {
            string sql = @"INSERT INTO fire_data
                            (device_id, is_fogo_bixo, environmental_fire_probability, temperature, humidity, fire,smoke)
                        VALUES(@DeviceId, @IsFogoBixo, @EnvironmentalFireProbability, @Temperature, @Humidity, @Fire, @Smoke)";

            using var connection = _helper.GetConnection();
            await connection.ExecuteAsync(sql,
                                          new
                                          {
                                              model.IsFogoBixo,
                                              model.EnvironmentalFireProbability,
                                              DeviceId = deviceId,
                                              Fire = model.Fogo,
                                              Smoke = model.Fumaça,
                                              model.Humidity,
                                              model.Temperature,
                                          });
        }
    }
}
