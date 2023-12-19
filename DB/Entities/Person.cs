using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        
        public DateTime Birthday { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostCode { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        public string trustString { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool isDeleted { get; set; }


        //wartosci kluczy obchych

        [Required]
        public int rodzajUzytkownika { get; set; }
        public UserType UserType { get; set; }

        //kolekcje

        public ICollection<Wpis> wpisy { get; set; }

        public ICollection<Marka> marki { get; set; }

        public ICollection<WersjeNadwozia> wersjeNadwozia { get; set; }

        public ICollection<Zlecenie> zlecenia { get; set; }

        public ICollection<Samochod> samochody { get; set; }

        public ICollection<ModelSamochodu> modeleSamochodu { get; set; }

        public ICollection<RodzajeUslug> rodzajeUslug { get; set; }
        
    }
}
