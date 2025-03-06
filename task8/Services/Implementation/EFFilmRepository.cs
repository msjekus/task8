using task8.Data;
using task8.Models;
using task8.Services.Abstract;

namespace task8.Services.Implementation
{
    public class EFFilmRepository : IFilmRepository
    {
        private readonly LibraryContext context;

        public EFFilmRepository(LibraryContext context)
        {
            this.context = context;
        }
        public Movie Create(Movie entity)
        {
            context.Movies.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public Movie? Delete(int id)
        {
            Movie? movie = context.Movies.Find(id);
            if (movie is not null)
            {
                context.Movies.Remove(movie);
                context.SaveChanges();
            }
            return movie;
        }

        public Movie Edit(Movie entity)
        {
            Movie? editedMovie = context.Movies.Find(entity.Id);
            if (editedMovie is not null)
            {
                editedMovie.Title = entity.Title;
                editedMovie.Filmmaker = entity.Filmmaker;
                editedMovie.Genre = entity.Genre;
                editedMovie.Description = entity.Description;
                context.SaveChanges();
                return editedMovie;
            }
            else
                return entity;
        }

        public Movie? Get(int id)
        {
            Movie? movie = context.Movies.Find(id);
            return movie;
        }

        public IEnumerable<Movie> GetAll()
        {
            return context.Movies.ToList();
        }
    }
}
