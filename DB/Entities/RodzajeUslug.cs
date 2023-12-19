using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class RodzajeUslug
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int personId { get; set; }
        public Person person { get; set; }

        [Required]
        [DefaultValue(false)] //nie widoczne dla użytkowników bedacych klientami , widoczne dla kierowników 
        public bool isVisible { get; set; }

        [Required]
        [DefaultValue(false)] //nie widoczne dla nikogo
        public bool isDeleted { get; set; }


        //kolekcje

        public ICollection<Zlecenie> zlecenia { get; set; }

    }
}
