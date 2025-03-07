using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using task8.Models;
using task8.Services.Abstract;

namespace task8.Pages.Movies
{
    //[IgnoreAntiforgeryToken]
    public class EditModel : PageModel
    {
        private readonly IFilmRepository repository;

        public string Message { get; set; } = "";
        [BindProperty]
        public Movie Movie { get; set; } = new();
        public EditModel(IFilmRepository repository) 
        {
            this.repository = repository;
            
        }
        public IActionResult OnGet(int id)
        {
            Movie? movie = repository.Get(id);
            if(movie is not null)
            {
                Movie = movie;
            }
            return Page();
        }
        public IActionResult OnPost() 
        { 
            repository.Edit(Movie);
            return RedirectToPage("Index");
        }
    }
}
