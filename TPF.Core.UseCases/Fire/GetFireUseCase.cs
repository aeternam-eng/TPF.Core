using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Repositories;
using TPF.Core.Borders.Shared;
using TPF.Core.Borders.UseCases.Fire;
using TPF.Core.Repositories;

namespace TPF.Core.UseCases.Fire
{
    public class GetFireUseCase : IGetFireUseCase
    {
        private readonly IFireRepository _fireRepository;

        public GetFireUseCase(IFireRepository fireRepository)
        {
            _fireRepository = fireRepository;
        }

        public async Task<UseCaseResponse<GetFireResponse>> Execute(GetFireRequest request)
        {
            var result = await _fireRepository.GetFire(request.Img);

            return UseCaseResponse<GetFireResponse>.Success(result);
        }
    }
}
