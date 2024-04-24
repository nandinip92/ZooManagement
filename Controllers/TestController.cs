using Microsoft.AspNetCore.Mvc;

namespace ZooManagement.Controllers;

[ApiController]
[Route("/test")]
public class TestController : Controller
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World!!!");
    }
}
