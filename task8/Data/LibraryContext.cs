using Microsoft.EntityFrameworkCore;
using task8.Models;

namespace task8.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) :
           base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Movie> Movies { get; set; }
    }
}
