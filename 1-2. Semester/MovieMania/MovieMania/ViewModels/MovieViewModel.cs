using Microsoft.AspNetCore.Mvc.Rendering;
using MovieMania.Models;

namespace MovieMania.ViewModels;

public class MovieViewModel
{
    public Movie movie { get; set; } = new Movie();
    public IEnumerable<SelectListItem> Directors { get; set; } = Enumerable.Empty<SelectListItem>();
}