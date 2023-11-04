using Microsoft.AspNetCore.Mvc;
using TPF.Core.Api.Models;
using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.UseCases.Fire;
using TPF.Core.Shared.Models;

namespace TPF.Core.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class FireController : Controller
{
    private readonly IActionResultConverter _actionResultConverter;
    private readonly ICreateMeasurementUseCase _getFireUseCase;

    public FireController(
        IActionResultConverter actionResultConverter,
        ICreateMeasurementUseCase getFireUseCase)
    {
        _actionResultConverter = actionResultConverter;
        _getFireUseCase = getFireUseCase;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetFireResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage[]))]
    public async Task<IActionResult> CreateMeasurement(
        [FromForm] IFormFile request,
        [FromForm] Guid deviceId,
        [FromForm] decimal temperature,
        [FromForm] decimal humidity)
    {
        var file = new CreateMeasurementRequest
        {
            Img = request,
            DeviceId = deviceId,
            Temperature = temperature,
            Humidity = humidity
        };

        var response = await _getFireUseCase.Execute(file);
        return _actionResultConverter.Convert(response);
    }
}
