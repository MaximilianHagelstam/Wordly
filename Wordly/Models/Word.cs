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

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
