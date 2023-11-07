using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPF.Core.Api.Models;
using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.UseCases;
using TPF.Core.Shared.Models;

namespace TPF.Core.Api.Controllers;

[Authorize]
[Route("api/v1/[controller]")]
[ApiController]
public class DevicesController : Controller
{
    private readonly IActionResultConverter _actionResultConverter;
    private readonly IUpdateDeviceNameUseCase _updateDeviceNameUseCase;
    public DevicesController(IActionResultConverter actionResultConverter,
                             IUpdateDeviceNameUseCase updateDeviceNameUseCase)
    {
        _actionResultConverter = actionResultConverter;
        _updateDeviceNameUseCase = updateDeviceNameUseCase;
    }

    [HttpPatch("{deviceId}/name")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeviceResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage[]))]
    public async Task<IActionResult> UpdateDeviceName([FromRoute] Guid deviceId, [FromBody] UpdateDeviceNameRequest request)
    {
        return _actionResultConverter.Convert(await _updateDeviceNameUseCase.Execute(request with { DeviceId = deviceId }), true);
    }
}
