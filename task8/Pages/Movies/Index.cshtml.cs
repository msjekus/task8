using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using task8.Models;
using task8.Services.Abstract;

namespace task8.Pages.Movies
{
    //[IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        private readonly IFilmRepository repository;
        [BindProperty(SupportsGet =true)]
        public string? TitleSearch { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? GenreSearch { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public IndexModel(IFilmRepository repository)
        {
            Movies = repository.GetAll();
            this.repository = repository;
        }
        public void OnGet(string? titleSearch, string? genreSearch)
        {
            Movies = repository.GetAll();
            if (!string.IsNullOrEmpty(TitleSearch))
                Movies = Movies.Where(m => m.Title.Contains(TitleSearch));
            if(!string.IsNullOrEmpty(GenreSearch))
                Movies = Movies.Where(m => m.Genre.Contains(GenreSearch));
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
