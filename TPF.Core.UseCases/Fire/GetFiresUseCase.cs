using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Repositories;
using TPF.Core.Borders.Shared;
using TPF.Core.Borders.UseCases.Fire;

namespace TPF.Core.UseCases.Fire
{
    public class GetFiresUseCase : IGetFiresUseCase
    {
        private readonly IFireDataRepository _fireDataRepository;
        private readonly IDeviceRepository _deviceRepository;

        public GetFiresUseCase(
            IFireDataRepository fireDataRepository,
            IDeviceRepository deviceRepository)
        {
            _fireDataRepository = fireDataRepository;
            _deviceRepository = deviceRepository;
        }

        public async Task<UseCaseResponse<GetFiresResponse>> Execute(Guid request)
        {
            var measurements = await _fireDataRepository.GetAllByUserId(request);
            var devices = await _deviceRepository.GetAllByUserId(request);

            var fireDtos = measurements.Join(devices, m => m.Device_Id, d => d.Id, (measurement, device) => new FireDto
            {
                Is_fogo_bicho = measurement.Is_Fogo_Bixo,
                Date = measurement.Date_Time,
                Device = new DeviceResponse()
                {
                    Id = device.Id,
                    Name = device.Name,
                    User_Id = device.User_Id,
                    Latitude = device.Latitude,
                    Longitude = device.Longitude
                },
                Id = measurement.Id,
                Image_Fire_Probability = measurement.Image_Fire_Probability
            });

            var response = new GetFiresResponse
            {
                FireDtos = fireDtos
            };

            return UseCaseResponse<GetFiresResponse>.Success(response);
        }
    }
}
