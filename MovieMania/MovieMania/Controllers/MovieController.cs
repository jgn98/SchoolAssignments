using Microsoft.AspNetCore.Mvc;

namespace MovieMania.Controllers;

public class MovieController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}