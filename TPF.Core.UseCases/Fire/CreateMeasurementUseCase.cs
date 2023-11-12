using FluentValidation;
using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Repositories;
using TPF.Core.Borders.Shared;
using TPF.Core.Borders.UseCases.Fire;
using TPF.Core.Borders.Validators;

namespace TPF.Core.UseCases.Fire
{
    public class CreateMeasurementUseCase : ICreateMeasurementUseCase
    {
        private readonly IFireRepository _fireRepository;
        private readonly IFireDataRepository _fireDataRepository;
        private readonly IBlobRepository _blobRepository;
        private readonly IDeviceRepository _deviceRepository;
        private readonly FireValidator _fireValidator;

        public CreateMeasurementUseCase(IFireRepository fireRepository,
            IFireDataRepository fireDataRepository,
            FireValidator fireValidator,
            IBlobRepository blobRepository,
            IDeviceRepository deviceRepository)
        {
            _fireRepository = fireRepository;
            _fireDataRepository = fireDataRepository;
            _fireValidator = fireValidator;
            _blobRepository = blobRepository;
            _deviceRepository = deviceRepository;
        }

        public async Task<UseCaseResponse<GetFireResponse>> Execute(CreateMeasurementRequest request)
        {
            _fireValidator.ValidateAndThrow(request);

            var device = await _deviceRepository.GetById(request.DeviceId);

            var result = await _fireRepository.AnalyzeImage(request.ToModel(device.Latitude, device.Longitude));

            using var imageStream = request.Img.OpenReadStream();
            var imageUrl = await _blobRepository.UploadBlob(imageStream, $"fire-image-{request.DeviceId}-{DateTime.UtcNow:o}.jpg");

            await _fireDataRepository.Insert(result, device.Id);

            return UseCaseResponse<GetFireResponse>.Success(result);
        }
    }
}
