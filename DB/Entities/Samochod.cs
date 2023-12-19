using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class Samochod
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(16)]
        public string Nazwa { get; set; }
        [Required]
        [StringLength(17)]
        [MaxLength(17)]
        [MinLength(17)]
        public string VIN { get; set; }

        [Required]
        public int ModelSamochoduId { get; set; }
        public ModelSamochodu ModelSamochodu { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(4)]
        public int rokProdukcji { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        [RegularExpression(@"^\d{1,2}(\.\d{1})?$", ErrorMessage = "Nalezy zastosować format XX.Y")]
        public double pojemnoscSkokowa { get; set; }

        [Required]
        public int rodzajPaliwaId { get; set; }
        public Paliwo rodzajPaliwa { get; set; }

        [Required]
        [MaxLength(5000)]
        public uint przebieg {  get; set; }

        [MaxLength(7)]
        [MinLength(4)]
        public string nr_rejestracyjny { get; set; }

        [Required]
        public int WlascicielId { get; set; }
        public Person persons { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool isDeleted { get; set; }

        //kolekcje

        public ICollection<Zlecenie> zlecenia {  get; set; }


    }

}
