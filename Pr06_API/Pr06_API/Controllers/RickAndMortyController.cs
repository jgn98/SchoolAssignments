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
        var result = await _rickAndMortyHttpService.GetCharacterByIdAsync(id);
        
        return View(result);
    }

    public RickAndMortyController(IRickAndMortyHttpService rickAndMortyHttpService)
    {
        _rickAndMortyHttpService = rickAndMortyHttpService;
    }
}