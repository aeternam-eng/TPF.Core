using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPF.Core.Api.Models;
using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.UseCases;
using TPF.Core.Borders.UseCases.Fire;
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
        private readonly IGetUserDevicesUseCase _getUserDevicesUseCase;
        private readonly IGetFiresUseCase _getFiresUseCase;

        public UsersController(
            IGetUserByIdUseCase getUserByIdUseCase,
            IActionResultConverter actionResultConverter,
            IGetUserDevicesUseCase getUserDevicesUseCase,
            IGetFiresUseCase getFiresUseCase)
        {
            _getUserByIdUseCase = getUserByIdUseCase;
            _actionResultConverter = actionResultConverter;
            _getUserDevicesUseCase = getUserDevicesUseCase;
            _getFiresUseCase = getFiresUseCase;
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

        [HttpGet("{userId}/devices")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> GetUserDevices([FromRoute] Guid userId)
        {
            return _actionResultConverter.Convert(await _getUserDevicesUseCase.Execute(userId));
        }

        [HttpGet("{userId}/fires")]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> GetFires([FromRoute] Guid userId)
        {
            return _actionResultConverter.Convert(await _getFiresUseCase.Execute(userId));
        }
    }
}
