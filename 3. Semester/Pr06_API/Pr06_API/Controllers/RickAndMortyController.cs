using Microsoft.AspNetCore.Mvc;
using Pr06_API.Services;
using Pr06_API.Models;

namespace Pr06_API.Controllers;

public class RickAndMortyController : Controller
{
    private readonly IRickAndMortyHttpService _rickAndMortyHttpService;
    
    [HttpPost]
    public async Task<IActionResult> Index(int id)
    {
        var ch = await _rickAndMortyHttpService.GetCharacterByIdAsync(id);
        if (ch is null) return NotFound();

        var vm = new RickAndMortyViewModel
        {
            Character = ch
        };

        return View(vm);
    }
    
    
    [HttpGet]
    public async Task<IActionResult> All()
    {
        var list = await _rickAndMortyHttpService.GetAllCharactersAsync();

        var vm = new RickAndMortyViewModel
        {
            Characters = list
        };

        return View(vm);
    }

    public RickAndMortyController(IRickAndMortyHttpService rickAndMortyHttpService)
    {
        _rickAndMortyHttpService = rickAndMortyHttpService;
    }
}