
using System.ComponentModel.DataAnnotations;

namespace Data_1.Models
{
    public class Movie
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Range(1900, 2016)]
        public int Year { get; set; }

        [Required]
        public Genre Genre { get; set; }
    }
}