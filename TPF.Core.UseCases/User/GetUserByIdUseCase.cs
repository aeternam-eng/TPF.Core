using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Repositories;
using TPF.Core.Borders.Shared;
using TPF.Core.Borders.UseCases.User;

namespace TPF.Core.UseCases.User;

public class GetUserByIdUseCase : IGetUserByIdUseCase
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UseCaseResponse<UserResponse>> Execute(Guid request)
    {
        var user = await _userRepository.GetUserById(request);

        if (user is null)
            return UseCaseResponse<UserResponse>.NotFound("User not found.");

        return UseCaseResponse<UserResponse>.Success(user.ToUserResponse());
    }
}
