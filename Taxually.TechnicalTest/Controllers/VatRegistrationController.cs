using System.Text;
using System.Xml.Serialization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.Interfaces;
using Taxually.TechnicalTest.Interfaces.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VatRegistrationController: ControllerBase
{
    public IMediator mediator { get; set; }

    public VatRegistrationController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Registers a company for a VAT number in a given country
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] VatRegistrationRequestDto request)
    {
        var registrationRequest = new VatRegistrationRequest(request);
        var command = new VatRegistrationCommand(registrationRequest);
        var result = await mediator.Send(command);

        var resultDto = new VatRegistrationResponseDto(result.IsSuccess, result.Message);

        if (!resultDto.IsSuccess)
        {
            return UnprocessableEntity(resultDto);
        }
        return Ok(resultDto);
    }
}