﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("Genre")]  // Setter hvor foreignkey'en hører til
        [Range(1,int.MaxValue)]
        public int GenreId { get; set; }
        
        public virtual Genre _Genre { get; set; } // Virtual lager en lazy-join

        public MovieGenre Genre {
            get
            {
                return (MovieGenre)GenreId;
            }
            set
            {

                GenreId = (int)value;
            }
    }

    
}