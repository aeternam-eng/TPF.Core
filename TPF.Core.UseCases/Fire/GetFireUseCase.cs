using FluentValidation;
using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Repositories;
using TPF.Core.Borders.Shared;
using TPF.Core.Borders.UseCases.Fire;
using TPF.Core.Borders.Validators;

namespace TPF.Core.UseCases.Fire
{
    public class GetFireUseCase : IGetFireUseCase
    {
        private readonly IFireRepository _fireRepository;
        private readonly IFireDataRepository _fireDataRepository;
        private readonly FireValidator _fireValidator;

        public GetFireUseCase(IFireRepository fireRepository,
            IFireDataRepository deviceRepository,
            FireValidator fireValidator)
        {
            _fireRepository = fireRepository;
            _fireDataRepository = deviceRepository;
            _fireValidator = fireValidator;
        }

        public async Task<UseCaseResponse<GetFireResponse>> Execute(GetFireRequest request)
        {
            _fireValidator.ValidateAndThrow(request);

            var result = await _fireRepository.GetFire(request.Img);

            await _fireDataRepository.Insert(result.IsFogoBixo, result.Probability, request.DeviceId);

            return UseCaseResponse<GetFireResponse>.Success(result);
        }
    }
}
