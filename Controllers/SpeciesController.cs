using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Data;
using ZooManagement.Models.Response;

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

    private static SpeciesResponse ResponseToSpeciesEndpoint(Species species)
    {
        var enclosure = species.Enclosure;
        var animalName = enclosure.Animals.Select(animal => animal.Name).ToList();
        return new SpeciesResponse
        {
            SpeciesId = species.Id,
            SpeciesName = species.Name,
            Enclosure = new EnclosureResponse
            {
                EnclosureId = enclosure.Id,
                EnclosureName = enclosure.Name.ToLower(),
                Classification = enclosure.Classification.ToString().ToLower(),
                AnimalsCount = enclosure.Animals.Count,
                Animals = animalName
            }
        };
    }

    [HttpGet("all")]
    public IActionResult GetAllSpecies()
    {
        var species = _zoo
            .Species.Include(species => species.Enclosure)
            .Include(species => species.Enclosure.Animals)
            .ToList();
        if (species == null)
        {
            return NotFound();
        }
        var responseList = new SpeciesListResponse
        {
            SpeciesList = species
                .Select(singleSpecies => ResponseToSpeciesEndpoint(singleSpecies))
                .ToList()
        };
        return Ok(responseList);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var species = _zoo
            .Species.Include(species => species.Enclosure)
            .Include(species => species.Enclosure.Animals)
            .SingleOrDefault(species => species.Id == id);

        if (species == null)
        {
            return NotFound();
        }

        return Ok(ResponseToSpeciesEndpoint(species));
    }

    [HttpGet("")]
    public IActionResult GetByName([FromQuery] string name = "")
    {
        var species = _zoo
            .Species.Include(species => species.Enclosure)
            .Include(species => species.Enclosure.Animals)
            .SingleOrDefault(species => string.Equals(species.Name, name));
        // return Ok(species);
        if (species == null)
        {
            return NotFound();
        }

        return Ok(ResponseToSpeciesEndpoint(species));
    }

    // [HttpGet]
    // public IActionResult GetImage()
    // {
    //     // Byte[] b = System.IO.File.ReadAllBytes(@".\Images\bear.jpg"); // You can use your own method over here.
    //     // return File(b, "image/jpeg");
    //     var path = Path.Combine(Directory.GetCurrentDirectory(), @".\Images\*.jpg");
    //     Console.WriteLine($"****************{path}");
    //     return PhysicalFile(path, "image/jpeg");
    // }
}
