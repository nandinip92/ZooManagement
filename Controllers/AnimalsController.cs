using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Data;
using ZooManagement.Models.Request;
using ZooManagement.Models.Response;

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

    public static AnimalResponse ResponseToAnimalEndpoint(Animal animal)
    {
        return new AnimalResponse
        {
            Id = animal.Id,
            Name = animal.Name,
            SpeciesName = animal.Species.Name,
            Classification = animal.Species.Classification.ToString().ToLower(),
            Sex = animal.Sex.ToString().ToLower(),
            EnclosureId = animal.Enclosure.Id,
            EnclosureName = animal.Enclosure.Name.ToLower(),
            DateOfBirth = animal.DateOfBirth,
            DateOfAcquisition = animal.DateOfAcquisition,
        };
    }

    // [HttpGet]
    // public IActionResult GetByPageAndSize([FromQuery] int page = 1, int pageSize = 10)
    // {
    //     var animalsList = _zoo
    //         .Animals.Include(animal => animal.Species)
    //         .Include(animal => animal.Enclosure)
    //         .OrderBy(animal => animal.Species.Name)
    //         .ThenBy(animal => animal.Name)
    //         .ToList();
    //     var animalsData = animalsList.Skip((page - 1) * pageSize).Take(pageSize).ToList();

    //     var responseList = new AnimalListResponse
    //     {
    //         AnimalsList = animalsData.Select(animal => ResponseToAnimalEndpoint(animal)).ToList()
    //     };
    //     return Ok(responseList);
    // }
    [HttpGet]
    public IActionResult Search([FromQuery] SearchAnimalRequest searchRequest)
    {
        var animalsList = _zoo
            .Animals.Include(animal => animal.Species)
            .Include(animal => animal.Enclosure)
            .ToList();
        if (animalsList == null)
        {
            return NotFound();
        }
        if (!string.IsNullOrEmpty(searchRequest.SortBy))
        {
            var sortParam = searchRequest.SortBy;
            string sortOrder =
                searchRequest.SortOrder == true ? string.Concat(sortParam, "Desc") : sortParam;
            var sortedList = sortOrder switch
            {
                "animalNameDesc"
                    => new List<Animal>(animalsList.OrderByDescending(animal => animal.Name)),

                "speciesNameDesc"
                    => animalsList.OrderByDescending(animal => animal.Species.Name).ToList(),
                "classificationDesc"
                    => animalsList
                        .OrderByDescending(animal => animal.Species.Classification)
                        .ToList(),

                "animalName" => animalsList.OrderBy(animal => animal.Name).ToList(),
                "speciesName" => animalsList.OrderBy(animal => animal.Species.Name).ToList(),

                "classification"
                    => animalsList.OrderBy(animal => animal.Species.Classification).ToList(),
                _
                    => animalsList
                        .OrderBy(animal => animal.Species.Name)
                        .ThenBy(animal => animal.Name)
                        .ToList()
            };
            animalsList = sortedList;
        }

        var page = searchRequest.PageNumber;
        var pageSize = searchRequest.PageSize;

        var animalsData = animalsList.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        var responseList = new AnimalListResponse
        {
            AnimalsList = animalsData.Select(animal => ResponseToAnimalEndpoint(animal)).ToList()
        };
        return Ok(responseList);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        Console.Write($"*****************GetId: {id}");
        var matchingAnimal = _zoo
            .Animals.Include(animal => animal.Species)
            .Include(animal => animal.Enclosure)
            .SingleOrDefault(animal => animal.Id == id);
        if (matchingAnimal == null)
        {
            return NotFound();
        }
        // _logger.LogInformation("Foud the match");
        return Ok(matchingAnimal);
        // return Ok(ResponseToAnimalEndpoint(matchingAnimal));
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

        return CreatedAtAction(nameof(GetById), new { id = newAnimal.Id }, newAnimal); //This is not working need to be checked
    }
}
