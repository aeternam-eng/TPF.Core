using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Shared.Helpers;

namespace TPF.Core.Borders.UseCases.User
{
    public interface IGetUserByIdUseCase : IUseCase<Guid, UserResponse> { }
}
