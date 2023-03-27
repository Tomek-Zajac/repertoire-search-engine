using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using RepertoireManagementService.Application.Common.Persistence.Repositories.Base;

namespace RepertoireManagementService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private readonly IRepository<CinemaEntity> _repository;

    public CinemaController(IRepository<CinemaEntity> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetCinemas()
    {
        var cinemas = await _repository.GetAllAsync();
        return Ok(cinemas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCinema(string id)
    {
        CinemaEntity cinema = await _repository.GetByIdAsync(id);

        if (cinema == null)
        {
            return NotFound();
        }

        return Ok(cinema);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCinema(CinemaEntity cinema)
    {
        await _repository.AddAsync(cinema);

        return CreatedAtAction(nameof(GetCinema), new { id = cinema.Id }, cinema);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCinema(string id, CinemaEntity cinema)
    {
        if (id != cinema.Id)
        {
            return BadRequest();
        }

        await _repository.UpdateAsync(cinema);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCinema(string id)
    {
        CinemaEntity cinema = await _repository.GetByIdAsync(id);

        if (cinema == null)
        {
            return NotFound();
        }

        await _repository.DeleteAsync(cinema);

        return NoContent();
    }
}