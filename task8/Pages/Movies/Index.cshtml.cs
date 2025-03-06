using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using task8.Models;
using task8.Services.Abstract;

namespace task8.Pages.Movies
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        private readonly IFilmRepository repository;

        public IEnumerable<Movie> Movies { get; set; }
        public IndexModel(IFilmRepository repository)
        {
            Movies = repository.GetAll();
            this.repository = repository;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(int? id)
        {
            if (id is null)
                return NotFound();
            Movie? movie = repository.Get(id.Value);
            if(movie == null)
                return NotFound();
            repository.Delete(id.Value);
            return RedirectToPage("Index");
        }
    }
}
