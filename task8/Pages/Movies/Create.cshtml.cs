using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using task8.Models;
using task8.Services.Abstract;

namespace task8.Pages.Movies
{

    [IgnoreAntiforgeryToken]
    public class CreateModel : PageModel
    {
        private readonly IFilmRepository repository;

        public CreateModel(IFilmRepository repository)
        {
            this.repository = repository;
        }
        [BindProperty]
        public Movie? Movie { get; set; }
        public void OnGet()
        {
        }
        public void OnPost(string title)
        {
            if (ModelState.IsValid && Movie is not null)
            {
                repository.Create(Movie);
            }
        }
    }
}
