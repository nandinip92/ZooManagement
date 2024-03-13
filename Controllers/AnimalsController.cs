using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Data;
using ZooManagement.Models.Request;

namespace ZooManagement.Controllers;

[ApiController]
[Route("/animals")]
public class AnimalsController : Controller
{
    private readonly Zoo _zoo;
    private readonly ILogger<AnimalsController> _logger;

    public AnimalsController(ILogger<AnimalsController> logger, Zoo zoo)
    {
        _zoo = zoo;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var matchingAnimal = _zoo
            .Animals.Include(animal => animal.Species)
            .Include(animal => animal.Enclosure)
            .SingleOrDefault(animal => animal.Id == id);
        if (matchingAnimal == null)
        {
            return NotFound();
        }
        // _logger.LogInformation("Foud the match");
        // return Ok(matchingAnimal);
        return Ok(
            new AnimalResponse
            {
                Name = matchingAnimal.Name,
                SpeciesName = matchingAnimal.Species.Name,
                Classification = matchingAnimal.Species.Classification.ToString().ToLower(),
                Sex = matchingAnimal.Sex.ToString().ToLower(),
                EnclosureId = matchingAnimal.Enclosure.Id,
                EnclosureName = matchingAnimal.Enclosure.Name.ToLower(),
                DateOfBirth = matchingAnimal.DateOfBirth,
                DateOfAcquisition = matchingAnimal.DateOfAcquisition,
            }
        );
    }

    [HttpGet]
    public IActionResult GetByPageAndSize([FromQuery] int page = 1, int pageSize = 10)
    {
        var animalsList = _zoo
            .Animals.Include(animal => animal.Species)
            .Include(animal => animal.Enclosure)
            .OrderBy(animal => animal.Species.Name)
            .ThenBy(animal => animal.Name)
            .ToList();
        var animalsData = animalsList.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        var responseList = new List<AnimalResponse>();
        animalsData.ForEach(animal =>
        {
            responseList.Add(
                new AnimalResponse
                {
                    Name = animal.Name,
                    SpeciesName = animal.Species.Name,
                    Classification = animal.Species.Classification.ToString().ToLower(),
                    Sex = animal.Sex.ToString().ToLower(),
                    EnclosureId = animal.Enclosure.Id,
                    EnclosureName = animal.Enclosure.Name.ToLower(),
                    DateOfBirth = animal.DateOfBirth,
                    DateOfAcquisition = animal.DateOfAcquisition,
                }
            );
        });
        return Ok(responseList);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateAnimalRequest createAnimalRequest)
    {
        //Based on the Species Id finding the EnclosureId
        var newAnimalEnclosureId = _zoo
            .Species.Where(animal => animal.Id == createAnimalRequest.SpeciesId)
            .Select(animal => animal.EnclosureId)
            .Single();

        var newAnimal = _zoo
            .Animals.Add(
                new Animal
                {
                    Name = createAnimalRequest.Name,
                    SpeciesId = createAnimalRequest.SpeciesId,
                    EnclosureId = newAnimalEnclosureId,
                    Sex = createAnimalRequest.Sex,
                    DateOfBirth = createAnimalRequest.DateOfBirth,
                    DateOfAcquisition = createAnimalRequest.DateOfAcquisition,
                }
            )
            .Entity;
        _zoo.SaveChanges();
        var animal = _zoo
            .Animals.Include(animal => animal.Species)
            .ThenInclude(animal => animal.Enclosure)
            .Where(animal => animal.Name == newAnimal.Name).Single();
            
        return Ok( new AnimalResponse
                {
                    Name = animal.Name,
                    SpeciesName = animal.Species.Name,
                    Classification = animal.Species.Classification.ToString().ToLower(),
                    Sex = animal.Sex.ToString().ToLower(),
                    EnclosureId = animal.Enclosure.Id,
                    EnclosureName = animal.Enclosure.Name.ToLower(),
                    DateOfBirth = animal.DateOfBirth,
                    DateOfAcquisition = animal.DateOfAcquisition,
                });
        // return Ok();
    }
}
