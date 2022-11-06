using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Repositories;
using TPF.Core.Borders.Shared;
using TPF.Core.Borders.UseCases;

namespace TPF.Core.UseCases.Fire
{
    public class UpdateDeviceNameUseCase : IUpdateDeviceNameUseCase
    {
        private readonly IDeviceRepository _deviceRepository;

        public UpdateDeviceNameUseCase(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<UseCaseResponse<DeviceResponse>> Execute(UpdateDeviceNameRequest request)
        {
            await _deviceRepository.UpdateDeviceName(request.DeviceId, request.NewName);

            return UseCaseResponse<DeviceResponse>.Success(new DeviceResponse());
        }
    }
}
