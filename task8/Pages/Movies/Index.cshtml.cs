using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using task8.Models;
using task8.Services.Abstract;

namespace task8.Pages.Movies
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IndexModel(IFilmRepository repository)
        {
            Movies = repository.GetAll();
        }
        public void OnGet()
        {
        }
    }
}
