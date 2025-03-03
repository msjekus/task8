using task8.Models;
using task8.Services.Abstract;

namespace task8.Services.Implementation
{
    public class MockFilmRepository :IFilmRepository
    {
        private ICollection<Movie> _movies;

        public MockFilmRepository()
        {
            _movies = new List<Movie>();
        }
        public Movie Create(Movie entity)
        {
            int newId = 0;
            if (_movies.Count > 0)
                newId = _movies.Max(x => x.Id);
            entity.Id = ++newId;
            _movies.Add(entity);
            return entity;
        }

        public Movie? Delete(int id)
        {
            Movie? movie=_movies.FirstOrDefault(t => t.Id == id);
            return movie;
        }

        public Movie Edit(Movie entity)
        {
            Movie? editedMovie = _movies.FirstOrDefault(t => t.Id == entity.Id);
            if (editedMovie != null) 
            {
                editedMovie.Title = entity.Title;
                editedMovie.Filmmaker = entity.Filmmaker;
                editedMovie.Genre = entity.Genre;
                editedMovie.Description = entity.Description;
                return editedMovie;
            }
            else
                return entity;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _movies.ToList();
        }
    }
}
