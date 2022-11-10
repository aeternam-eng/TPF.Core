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
        private readonly FireValidator _fireValidator;

        public CreateMeasurementUseCase(IFireRepository fireRepository,
            IFireDataRepository deviceRepository,
            FireValidator fireValidator,
            IBlobRepository blobRepository)
        {
            _fireRepository = fireRepository;
            _fireDataRepository = deviceRepository;
            _fireValidator = fireValidator;
            _blobRepository = blobRepository;
        }

        public async Task<UseCaseResponse<GetFireResponse>> Execute(GetFireRequest request)
        {
            _fireValidator.ValidateAndThrow(request);

            var result = await _fireRepository.AnalyzeImage(request.Img);

            using var imageStream = request.Img.OpenReadStream();
            var imageUrl = await _blobRepository.UploadBlob(imageStream, $"fire-image-{request.DeviceId}-{DateTime.UtcNow.ToString("o")}.jpg");

            await _fireDataRepository.Insert(result.IsFogoBixo, result.Probability, request.DeviceId, imageUrl);

            return UseCaseResponse<GetFireResponse>.Success(result with { ImageUrl = imageUrl });
        }
    }
}
