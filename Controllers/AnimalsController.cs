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

    public AnimalsController(ILogger<AnimalsController> logger,Zoo zoo)
    {
        _zoo = zoo;
        _logger = logger;

    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var matchingAnimal = _zoo
            .Animals.Include(animal => animal.Species)
            .SingleOrDefault(animal => animal.Id == id);
        if (matchingAnimal == null)
        {
            return NotFound();
        }
        return Ok(matchingAnimal);
    }

    [HttpGet]
    public IActionResult GetByPageAndSize([FromQuery] int page = 1, int pageSize = 10)
    {
        var animalsList = _zoo
            .Animals.Include(animal => animal.Species)
            .OrderBy(animal => animal.Species.Name)
            .ThenBy(animal => animal.Name)
            .ToList();
        var animalsData = animalsList.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        return Ok(animalsData);
    }

     [HttpPost]
    public IActionResult Create([FromBody] CreateAnimalRequest createAnimalRequest)
    {
        var newAnimal = _zoo.Animals.Add(new Animal
        {
            Name = createAnimalRequest.Name,
            SpeciesId = createAnimalRequest.SpeciesId,
            Sex = createAnimalRequest.Sex,
            DateOfBirth = createAnimalRequest.DateOfBirth,
            DateOfAcquisition = createAnimalRequest.DateOfAcquisition,
        }).Entity;
        _zoo.SaveChanges();
        var animal = _zoo.Animals.Include(animal=>animal.Species).Where(animal=> animal.Name==newAnimal.Name);
        return Ok(animal);
    }
}
