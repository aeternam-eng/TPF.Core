using FluentValidation;
using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Repositories;
using TPF.Core.Borders.Shared;
using TPF.Core.Borders.UseCases.Fire;
using TPF.Core.Borders.Validators;

namespace TPF.Core.UseCases.Fire
{
    public class GetFiresUseCase : IGetFiresUseCase
    {
        private readonly IFireDataRepository _fireDataRepository;
        private readonly GuidValidator _guidValidator;

        public GetFiresUseCase(IFireDataRepository fireDataRepository,
            GuidValidator guidValidator)
        {
            _fireDataRepository = fireDataRepository;
            _guidValidator = guidValidator;
        }

        public async Task<UseCaseResponse<GetFiresResponse>> Execute(Guid request)
        {
            _guidValidator.ValidateAndThrow(request);

            var result = await _fireDataRepository.GetAllByUserId(request);

            var response = new GetFiresResponse
            {
                FireDtos = result.Select(x => new FireDto
                {
                    Is_fogo_bicho = x.Is_Fogo_Bixo,
                    Date = x.Date_Time,
                    Device_Id = x.Device_Id,
                    Id = x.Id,
                    Image_Fire_Probability = x.Image_Fire_Probability
                })
            };

            return UseCaseResponse<GetFiresResponse>.Success(response);
        }
    }
}
