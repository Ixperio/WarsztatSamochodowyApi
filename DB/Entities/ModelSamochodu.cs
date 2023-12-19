using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class ModelSamochodu
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public int WersjaId { get; set; }
        public WersjeNadwozia wersjeNadwozia { get; set; }


        [Required]
        public int MarkaId { get; set; }
        public Marka marka { get; set; }


        [Required]
        public int PersonAdderId { get; set; }
        public Person persons { get; set; }

        ///
        public ICollection<Samochod> Samochody { get; set; }

    }



}
