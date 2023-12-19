using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class Marka
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int PersonAdderId { get; set; }

        public Person Person { get; set; }

        //kolekcja
        public ICollection<ModelSamochodu> modeleSamochodu { get; set; }

    }


}
