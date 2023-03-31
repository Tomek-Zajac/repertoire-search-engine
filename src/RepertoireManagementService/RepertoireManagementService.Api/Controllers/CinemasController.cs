using Domain.Entities;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using RepertoireManagementService.Application.Modules.Cinemas.Commands;
using RepertoireManagementService.Application.Modules.Cinemas.Queries;

namespace RepertoireManagementService.Api.Controllers;

[ApiController]
public class CinemasController : ControllerBase
{
    private readonly IMediator _mediator;

    public CinemasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("cinemas")]
    public async Task<IActionResult> GetCinemas()
    {
        var result = await _mediator.Send(GetCinemasQuery.Instance);

        return result.Success
            ? Ok(result.Data)
            : NotFound();
    }

    [HttpGet("cinemas/{id}")]
    public async Task<IActionResult> GetCinema(string id)
    {
        var result = await _mediator.Send(new GetCinemaByIdQuery(id));

        return result.Success
            ? Ok(result.Data)
            : NotFound();
    }

    [HttpPost("cinemas")]
    public async Task<IActionResult> CreateCinema(CinemaEntity cinema)
    {
        var result = await _mediator.Send(
            new CreateCinemaCommand(cinema.CinemaName, cinema.Address, cinema.City, cinema.State, cinema.ZipCode));

        return result.Success
            ? Ok(result.Data)
            : NotFound();
    }

    [HttpPut("cinemas/{id}")]
    public async Task<IActionResult> UpdateCinema(CinemaEntity cinema)
    {
        var result = await _mediator.Send(
            new UpdateCinemaCommand(cinema.Id, cinema.CinemaName, cinema.Address, cinema.City, cinema.State, cinema.ZipCode));

        return result.Success
            ? Ok(result.Data)
            : NotFound();
    }

    [HttpDelete("cinemas/{id}")]
    public async Task<IActionResult> DeleteCinema(string id)
    {
        var result = await _mediator.Send(
            new DeleteCinemaCommand(id));

        return result.Success
            ? Ok(result.Data)
            : NotFound();
    }
}
