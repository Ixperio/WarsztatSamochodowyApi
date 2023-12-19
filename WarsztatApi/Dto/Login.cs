using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WarsztatApi.Dto
{
    public class Login
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
