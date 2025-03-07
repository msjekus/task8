using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using task8.Models;
using task8.Services.Abstract;

namespace task8.Pages.Movies
{
    //[IgnoreAntiforgeryToken]
    public class DeleteModel : PageModel
    {
        private readonly IFilmRepository repository;

        public DeleteModel(IFilmRepository repository)
        {
            this.repository = repository;
        }
         
        public Movie Movie { get; set; } = new();
        public void OnGet(int id)
        {
            Movie? movie= repository.Get(id);
            if (movie is not null)
                Movie = movie;
        }
        public IActionResult OnPost(int id)
        {
            Movie? movie= repository.Delete(id);
            return RedirectToPage("Index");
        }
    }
}
