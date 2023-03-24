using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace RepertoireManagementService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RepertoireController : ControllerBase
{
    private readonly IMongoCollection<RepertoireEntity> _repertoire;

    public RepertoireController(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("repertoireSearchEngineDB");
        _repertoire = database.GetCollection<RepertoireEntity>("repertoire");
    }

    [HttpGet]
    public async Task<IEnumerable<RepertoireEntity>> Get()
    {
        var repertoires = await _repertoire.Find(_ => true).ToListAsync();
        return repertoires;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RepertoireEntity>> GetById(string id)
    {
        var repertoire = await _repertoire.Find(m => m.Id == id).FirstOrDefaultAsync();
        return repertoire is null 
            ? (ActionResult<RepertoireEntity>)NotFound() 
            : (ActionResult<RepertoireEntity>)repertoire;
    }

    [HttpPost]
    public async Task<ActionResult<RepertoireEntity>> Create(RepertoireEntity repertoire)
    {
        await _repertoire.InsertOneAsync(repertoire);
        return CreatedAtAction(nameof(GetById), new { id = repertoire.Id }, repertoire);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(string id, RepertoireEntity repertoireToUdpate)
    {
        var repertoire = await _repertoire.Find(m => m.Id == id).FirstOrDefaultAsync();
        if (repertoire == null)
        {
            return NotFound();
        }
        await _repertoire.ReplaceOneAsync(m => m.Id == id, repertoireToUdpate);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        var repertoire = await _repertoire.Find(m => m.Id == id).FirstOrDefaultAsync();
        if (repertoire == null)
        {
            return NotFound();
        }
        await _repertoire.DeleteOneAsync(m => m.Id == id);
        return NoContent();
    }
}