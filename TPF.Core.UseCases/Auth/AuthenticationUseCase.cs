using FluentValidation;
using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Repositories;
using TPF.Core.Borders.Services;
using TPF.Core.Borders.Shared;
using TPF.Core.Borders.UseCases.Auth;
using TPF.Core.Borders.Validators;

namespace TPF.Core.UseCases.Auth;

public class AuthenticationUseCase : IAuthenticationUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _tokenService;
    private readonly AuthRequestValidator _authRequestValidator;

    public AuthenticationUseCase(
        IUserRepository userRepository,
        IAuthService tokenService,
        AuthRequestValidator authRequestValidator)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _authRequestValidator = authRequestValidator;
    }

    public async Task<UseCaseResponse<AuthResponse>> Execute(AuthRequest request)
    {
        _authRequestValidator.ValidateAndThrow(request);

        var user = await _userRepository.GetUserByEmail(request.Email);

        if (user is null)
            return UseCaseResponse<AuthResponse>.NotFound("User not found.");

        if (user.Secret == request.Password)
        {
            var response = new AuthResponse()
            {
                UserId = user.Id,
                Token = _tokenService.GenerateToken(user)
            };

            return UseCaseResponse<AuthResponse>.Success(response);
        }

        return UseCaseResponse<AuthResponse>.BadRequest("Invalid password");
    }
}
