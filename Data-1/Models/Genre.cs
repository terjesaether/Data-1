using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data_1.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public enum MovieGenre
    {
        [Display(Name="Action")]
        Action = 1,
        Adventure = 2,
        [Display(Name="Sci-Fi")]
        SciFi = 3,
        Comedy = 4
    }
}

