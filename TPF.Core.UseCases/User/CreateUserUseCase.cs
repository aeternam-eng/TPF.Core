using FluentValidation;
using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.Repositories;
using TPF.Core.Borders.Shared;
using TPF.Core.Borders.UseCases.User;
using TPF.Core.Borders.Validators.User;

namespace TPF.Core.UseCases.User
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly UserValidator _userValidator;

        public CreateUserUseCase(IUserRepository userRepository, UserValidator userValidator)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
        }

        public async Task<UseCaseResponse<bool>> Execute(CreateUserRequest request)
        {
            _userValidator.ValidateAndThrow(request);

            return UseCaseResponse<bool>.Success(await _userRepository.CreateUser(request.ToModel()));
        }
    }
}
