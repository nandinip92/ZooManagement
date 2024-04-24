using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Data;
using ZooManagement.Models.Response;

namespace ZooManagement.Controllers;

[ApiController]
[Route("/enclosure")]
public class EnclosureController : Controller
{
    private readonly Zoo _zoo;
    private readonly ILogger<EnclosureController> _logger;

    public EnclosureController(ILogger<EnclosureController> logger, Zoo zoo)
    {
        _zoo = zoo;
        _logger = logger;
    }

    private static EnclosureResponse ResponseToEnclosure(Enclosure enclosure)
    {
        return new EnclosureResponse
        {
            EnclosureId = enclosure.Id,
            EnclosureName = enclosure.Name.ToLower(),
            Classification = enclosure.Classification.ToString().ToLower(),
            AnimalsCount = enclosure.Animals.Count,
            Animals = enclosure
                .Animals.Select(animal => new EnclosureAnimalResponse
                {
                    AnimalId = animal.Id,
                    AnimalName = animal.Name.ToLower(),
                    Sex = animal.Sex.ToString().ToLower(),
                    DateOfBirth = animal.DateOfBirth,
                    DateOfAcquisition = animal.DateOfAcquisition
                })
                .ToList()
        };
    }

    [HttpGet]
    public IActionResult GetAllEnclosures()
    {
        var enclosures = _zoo.Enclosures.Include(enclosure => enclosure.Animals).ToList();
        // return Ok(enclosures);
        var enclosureResponseList = new List<EnclosureResponse>();
        enclosures.ForEach(enclosure =>
        {
            enclosureResponseList.Add(ResponseToEnclosure(enclosure));
        });
        return Ok(enclosureResponseList);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var enclosure = _zoo
            .Enclosures.Include(enclosure => enclosure.Animals)
            .SingleOrDefault(enclosure => enclosure.Id == id);
        if (enclosure == null)
        {
            return NotFound();
        }
        // var animalName = enclosure.Animals.Select(animal => animal.Name).ToList();
        return Ok(ResponseToEnclosure(enclosure));
    }

}
