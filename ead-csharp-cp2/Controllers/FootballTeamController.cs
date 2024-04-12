using ead_csharp_cp2.Dto;
using ead_csharp_cp2.Models;
using ead_csharp_cp2.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace ead_csharp_cp2.Controllers;

[ApiController]
[Route("[controller]")]
public class FootballTeamController : ControllerBase
{
    private readonly PostgresDbContext _context;
    
    public FootballTeamController(PostgresDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<FootballTeamGetDto>), StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        var teams = _context.FootballTeams;
        var teamDtos = teams.Select(team => new FootballTeamGetDto
        {
            Id = team.Id,
            Name = team.Name,
            FoundedAt = team.FoundedAt,
            City = team.City,
            Country = team.Country,
            Stadium = team.Stadium,
            StadiumCapacity = team.StadiumCapacity
        });
        
        return Ok(teamDtos);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(FootballTeamGetDto), StatusCodes.Status200OK)]
    public IActionResult Get(int id)
    {
        var team = _context.FootballTeams.Find(id);
        if (team == null)
        {
            return NotFound();
        }
        
        var teamDto = new FootballTeamGetDto
        {
            Id = team.Id,
            Name = team.Name,
            FoundedAt = team.FoundedAt,
            City = team.City,
            Country = team.Country,
            Stadium = team.Stadium,
            StadiumCapacity = team.StadiumCapacity
        };
        
        return Ok(teamDto);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(FootballTeamGetDto), StatusCodes.Status201Created)]
    public IActionResult Post([FromBody] FootballTeamCreateOrUpdateDto teamCreateOrUpdate)
    {
        var newTeam = new FootballTeam
        {
            Name = teamCreateOrUpdate.Name,
            FoundedAt = teamCreateOrUpdate.FoundedAt,
            City = teamCreateOrUpdate.City,
            Country = teamCreateOrUpdate.Country,
            Stadium = teamCreateOrUpdate.Stadium,
            StadiumCapacity = teamCreateOrUpdate.StadiumCapacity
        };
        
        _context.FootballTeams.Add(newTeam);
        _context.SaveChanges();
        
        var teamDto = new FootballTeamGetDto
        {
            Id = newTeam.Id,
            Name = newTeam.Name,
            FoundedAt = newTeam.FoundedAt,
            City = newTeam.City,
            Country = newTeam.Country,
            Stadium = newTeam.Stadium,
            StadiumCapacity = newTeam.StadiumCapacity
        };
        
        return CreatedAtAction(nameof(Get), new { id = newTeam.Id }, teamDto);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(FootballTeamGetDto), StatusCodes.Status200OK)]
    public IActionResult Put(int id, [FromBody] FootballTeamCreateOrUpdateDto teamCreateOrUpdate)
    {
        var existingTeam = _context.FootballTeams.Find(id);
        if (existingTeam == null)
        {
            return NotFound();
        }
        
        existingTeam.Name = teamCreateOrUpdate.Name;
        existingTeam.FoundedAt = teamCreateOrUpdate.FoundedAt;
        existingTeam.City = teamCreateOrUpdate.City;
        existingTeam.Country = teamCreateOrUpdate.Country;
        existingTeam.Stadium = teamCreateOrUpdate.Stadium;
        existingTeam.StadiumCapacity = teamCreateOrUpdate.StadiumCapacity;
        
        _context.FootballTeams.Update(existingTeam);
        _context.SaveChanges();
        
        var teamDto = new FootballTeamGetDto
        {
            Id = existingTeam.Id,
            Name = existingTeam.Name,
            FoundedAt = existingTeam.FoundedAt,
            City = existingTeam.City,
            Country = existingTeam.Country,
            Stadium = existingTeam.Stadium,
            StadiumCapacity = existingTeam.StadiumCapacity
        };
        
        return Ok(teamDto);
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete(int id)
    {
        var team = _context.FootballTeams.Find(id);
        if (team == null)
        {
            return NotFound();
        }
        
        _context.FootballTeams.Remove(team);
        _context.SaveChanges();
        
        return NoContent();
    }
}