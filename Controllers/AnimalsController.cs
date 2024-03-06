using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ZooManagement.Controllers;

[ApiController]
[Route("/animals")]
public class AnimalsController : Controller
{
    private readonly Zoo _zoo;

    public AnimalsController(Zoo zoo)
    {
        _zoo = zoo;
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
}
