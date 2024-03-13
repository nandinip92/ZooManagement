using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Data;
using ZooManagement.Models.Request;

namespace ZooManagement.Controllers;

[ApiController]
[Route("enclosure")]
public class EnclosureController : Controller
{
    private readonly Zoo _zoo;
    private readonly ILogger<EnclosureController> _logger;

    public EnclosureController(ILogger<EnclosureController> logger, Zoo zoo)
    {
        _zoo = zoo;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult GetAllEnclosures()
    {
        var enclosures = _zoo.Enclosures.ToList();
        return Ok(enclosures);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var enclosure = _zoo.Enclosures.SingleOrDefault(enclosure => enclosure.Id == id);
         if (enclosure == null)
        {
            return NotFound();
        }
        return Ok(
            new EnclosureResponse
            {
                EnclosureId = enclosure.Id,
                EnclosureName = enclosure.Name.ToLower(),
                Classification = enclosure.Classification.ToString().ToLower()
            }
        );
    }
}
