using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Wordly.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Word> Words { get; set; }
    }
}
