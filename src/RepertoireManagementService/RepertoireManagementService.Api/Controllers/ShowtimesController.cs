using Domain.Entities;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using RepertoireManagementService.Application.Modules.Showtimes.Commands;
using RepertoireManagementService.Application.Modules.Showtimes.Queries;

namespace RepertoireManagementService.Api.Controllers;

[ApiController]
public class ShowtimesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShowtimesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("showtimes")]
    public async Task<IActionResult> GetShowtimes()
    {
        var result = await _mediator.Send(GetShowtimesQuery.Instance);

        return result.Success
            ? Ok(result)
            : NotFound();
    }

    [HttpGet("showtimes/{id}")]
    public async Task<IActionResult> GetShowtime(string id)
    {
        var result = await _mediator.Send(new GetShowtimeByIdQuery(id));

        return result.Success
            ? Ok(result)
            : NotFound();
    }

    [HttpPost("showtimes")]
    public async Task<IActionResult> CreateShowtime(ShowtimeEntity showtime)
    {
        var result = await _mediator.Send(
            new CreateShowtimeCommand(showtime.DateTime));

        return result.Success
            ? Ok(result)
            : NotFound();
    }

    [HttpPut("showtimes/{id}")]
    public async Task<IActionResult> UpdateShowtime(ShowtimeEntity showtime)
    {
        var result = await _mediator.Send(
            new UpdateShowtimeCommand(showtime.DateTime));

        return result.Success
            ? Ok(result)
            : NotFound();
    }

    [HttpDelete("showtimes/{id}")]
    public async Task<IActionResult> DeleteShowtime(string id)
    {
        var result = await _mediator.Send(
            new DeleteShowtimeCommand(id));

        return result.Success
            ? Ok(result)
            : NotFound();
    }
}