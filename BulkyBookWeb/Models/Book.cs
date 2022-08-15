using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Genre { get; set; }
        [Required]
        public int? Rating { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
