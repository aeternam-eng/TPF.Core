using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Repositories;
using TPF.Core.Borders.Shared;
using TPF.Core.Borders.UseCases;

namespace TPF.Core.UseCases.Fire
{
    public class GetUserDevicesUseCase : IGetUserDevicesUseCase
    {
        private readonly IDeviceRepository _deviceRepository;

        public GetUserDevicesUseCase(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<UseCaseResponse<IEnumerable<DeviceResponse>>> Execute(Guid request)
        {
            var result = await _deviceRepository.GetAllByUserId(request);

            var response = result.Select(deviceEntity => new DeviceResponse
            {
                Id = deviceEntity.Id,
                Name = deviceEntity.Name,
                User_Id = deviceEntity.User_Id,
                Latitude = deviceEntity.Latitude,
                Longitude = deviceEntity.Longitude,
            });

            return UseCaseResponse<IEnumerable<DeviceResponse>>.Success(response);
        }
    }
}
