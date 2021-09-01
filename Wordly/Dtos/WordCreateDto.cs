using System.ComponentModel.DataAnnotations;

namespace Wordly.Dtos
{
    public class WordCreateDto
    {
        [Required]
        public string Body { get; set; }

        public string Meaning { get; set; }
    }
}
