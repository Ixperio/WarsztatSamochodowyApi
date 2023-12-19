using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WarsztatApi.Dto
{
    public class Test
    {
        [Required]
        [DisplayName("Test Kontrolera")]
        public bool Controller { get; set; }
        [Required]
        [DisplayName("Test Serwisu")]
        public bool Service { get; set; }
        [Required]
        [DisplayName("Test Repozytorium")]
        public bool Repository { get; set; }
    }
}
