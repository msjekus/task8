using System.ComponentModel.DataAnnotations;

namespace task8.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Display(Name ="Назва фільму")]
        public string Title { get; set; } = string.Empty;
        [Display(Name = "Режисер")]
        public string Filmmaker { get; set; } = string.Empty;
        [Display(Name = "Жанри")]
        public string Genre { get; set; } = string.Empty;
        [Display(Name = "Короткий опис фільму")]
        public string Description { get; set; } = string.Empty;
    }
}
