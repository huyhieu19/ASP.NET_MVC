using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int ID { get; set; } // The ID field is required by the database for the primary key.
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)] // A [DataType] attribute that specifies the type of data in the ReleaseDate property. With this attribute:
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
