using System.ComponentModel.DataAnnotations;

namespace Wordly.Dtos
{
    public class WordReadDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public string Meaning { get; set; }
    }
}
