using Microsoft.AspNetCore.Mvc;
using MovieMania.Models;
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

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Add(Movie movie)
    {
        if (ModelState.IsValid)
        {
            MovieRepository.Add(movie);
            return RedirectToAction("Index");
        }
        return View(movie);
    }
    
    [HttpGet]
    public IActionResult Edit(int movieId)
    {
        var movie = MovieRepository.GetById(movieId);
        
            return View(movie);
        
    }
    [HttpPost]
    public IActionResult Edit(Movie movie)
    {
        if (ModelState.IsValid)
        {
            MovieRepository.Update(movie.MovieId ?? 0, movie);
            return RedirectToAction("Index");
        }
        return View(movie);
    }
    
    [HttpGet]
    public IActionResult Delete(int movieId)
    {
        MovieRepository.Delete(movieId);
        return RedirectToAction("Index");
    }
}