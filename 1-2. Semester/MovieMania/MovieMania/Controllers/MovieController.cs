using Microsoft.AspNetCore.Mvc;
using MovieMania.Models;
using MovieMania.Persistence;
using MovieMania.ViewModels;

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
    public IActionResult Add(MovieViewModel movieViewModel)
    {
        if (ModelState.IsValid)
        {
            MovieRepository.Add(movieViewModel.movie);
            return RedirectToAction("Index");
        }
        return View(movieViewModel);
    }
    
    [HttpGet]
    public IActionResult Edit(int movieId)
    {
        var movie = MovieRepository.GetById(movieId);
        
            return View(movie);
        
    }
    [HttpPost]
    public IActionResult Edit(MovieViewModel movieViewModel)
    {
        if (ModelState.IsValid)
        {
            MovieRepository.Update(movieViewModel.movie.MovieId ?? 0, movieViewModel.movie);
            return RedirectToAction("Index");
        }
        return View(movieViewModel);
    }
    
    [HttpGet]
    public IActionResult Delete(int movieId)
    {
        MovieRepository.Delete(movieId);
        return RedirectToAction("Index");
    }
}