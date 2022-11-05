using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPF.Core.Api.Models;
using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.UseCases.User;
using TPF.Core.Shared.Models;

namespace TPF.Core.Api.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IActionResultConverter _actionResultConverter;
        private readonly IGetUserByIdUseCase _getUserByIdUseCase;

        public UsersController(IGetUserByIdUseCase getUserByIdUseCase, IActionResultConverter actionResultConverter)
        {
            _getUserByIdUseCase = getUserByIdUseCase;
            _actionResultConverter = actionResultConverter;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            var response = await _getUserByIdUseCase.Execute(id);
            return _actionResultConverter.Convert(response);
        }
    }
}