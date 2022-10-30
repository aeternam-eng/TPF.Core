﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPF.Core.Api.Models;
using TPF.Core.Borders.Dtos;
using TPF.Core.Borders.UseCases.Fire;
using TPF.Core.Shared.Models;

namespace TPF.Core.Api.Controllers
{
    //[Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FireController : Controller
    {
        private readonly IActionResultConverter _actionResultConverter;
        private readonly IGetFireUseCase _getFireUseCase;

        public FireController(IActionResultConverter actionResultConverter, IGetFireUseCase getFireUseCase)
        {
            _actionResultConverter = actionResultConverter;
            _getFireUseCase = getFireUseCase;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetFireResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorMessage[]))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorMessage[]))]
        public async Task<IActionResult> GetFire([FromForm] IFormFile request)
        {
            var file = new GetFireRequest { Img = request };

            var response = await _getFireUseCase.Execute(file);
            return _actionResultConverter.Convert(response);
        }
    }
}