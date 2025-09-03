using Microsoft.AspNetCore.Mvc;
using MovieMania.Persistence;

namespace MovieMania.Controllers;

public class MovieController : Controller
{
    // GET
    public IActionResult Index()
    {
        var movies = MovieRepository.GetAll();
        return View(movies);
    }
}