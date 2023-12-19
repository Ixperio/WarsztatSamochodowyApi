using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class StatusyZlecen
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //kolekcje
        public ICollection<Zlecenie> zlecenia { get; set; }
    }
}
