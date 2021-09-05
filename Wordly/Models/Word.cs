using System.ComponentModel.DataAnnotations;

namespace Wordly.Models
{
    public class Word
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Body { get; set; }

        public string Meaning { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
