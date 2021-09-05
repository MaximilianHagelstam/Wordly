using System.ComponentModel.DataAnnotations;

namespace Wordly.Dtos
{
    public class WordReadDto
    {
        [Required]
        public string Body { get; set; }

        [Required]
        public string Meaning { get; set; }
    }
}
