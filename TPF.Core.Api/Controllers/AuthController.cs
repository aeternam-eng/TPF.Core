using Microsoft.AspNetCore.Mvc;
using TPF.Core.Api.Models;
using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.UseCases.Auth;
using TPF.Core.Shared.Models;

namespace TPF.Core.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IActionResultConverter _actionResultConverter;
    private readonly IAuthenticationUseCase _authenticationUseCase;

    public AuthController(IActionResultConverter actionResultConverter, IAuthenticationUseCase authenticationUseCase)
    {
        _actionResultConverter = actionResultConverter;
        _authenticationUseCase = authenticationUseCase;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorMessage[]))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage[]))]
    public async Task<IActionResult> Authenticate([FromBody] AuthRequest request)
    {
        var response = await _authenticationUseCase.Execute(request);
        return _actionResultConverter.Convert(response);
    }
}
