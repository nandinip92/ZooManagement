using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Data;
using ZooManagement.Models.Request;

namespace ZooManagement.Controllers;

[ApiController]
[Route("species")]
public class SpeciesController : Controller
{
    private readonly Zoo _zoo;
    private readonly ILogger<SpeciesController> _logger;

    public SpeciesController(ILogger<SpeciesController> logger, Zoo zoo)
    {
        _zoo = zoo;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAllSpecies()
    {
        var species = _zoo.Species.Include(species => species.Enclosure).ToList();
        return Ok(species);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var species = _zoo
            .Species.Include(species => species.Enclosure)
            .SingleOrDefault(species => species.Id == id);

        if (species == null)
        {
            return NotFound();
        }
        return Ok(species);
    }

    [HttpGet("/speciecs/")]
    public IActionResult GetByName([FromQuery] string name="")
    {
        var species = _zoo
            .Species.Include(species => species.Enclosure)
            .SingleOrDefault(species => species.Name.ToLower() == name.ToLower());
        return Ok(species);
    }
}
