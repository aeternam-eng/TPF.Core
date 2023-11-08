﻿using Dapper;
using TPF.Core.Borders.Dtos;
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

        public async Task<IEnumerable<DeviceResponse>> GetAllByUserId(Guid userId)
        {
            const string sql = @"select 
                                    d.id,
                                    d.user_id,
                                    d.latitude,
                                    d.longitude,
                                    d.name,
                                    f.id,
                                    f.is_fogo_bixo,
                                    f.temperature,
                                    f.humidity,
                                    f.fire,
                                    f.smoke,
                                    f.environmental_fire_probability,
                                    f.date_time
                                from device d
                                join fire_data f on f.device_id = d.id 
                                WHERE d.user_id=@userId";

            var deviceResponseDictionary = new Dictionary<Guid, DeviceResponse>();

            using var connection = _helper.GetConnection();
            return await connection.QueryAsync<DeviceResponse, FireDto, DeviceResponse>(
                sql,
                map: (deviceResponse, fireDto) =>
                {
                    if (deviceResponseDictionary.TryGetValue(deviceResponse.Id, out var device))
                        deviceResponse = device;
                    else
                        deviceResponseDictionary.Add(deviceResponse.Id, deviceResponse);

                    if (fireDto is not null)
                    {
                        if (!deviceResponse.Fires.Any(fire => fire.Id == fireDto.Id))
                            deviceResponse.Fires.Add(fireDto);
                    }

                    return deviceResponse;
                },
                new { userId },
                null,
                true,
                splitOn: "id");
        }

        public async Task<Device> GetById(Guid id)
        {
            const string sql = "SELECT * FROM device WHERE id=@Id";

            using var connection = _helper.GetConnection();

            return await connection.QueryFirstAsync<Device>(sql, new { id });
        }
    }
}
