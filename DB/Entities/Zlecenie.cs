using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class Zlecenie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SamochodId { get; set; }
        public Samochod Samochod { get; set; }

        [AllowNull]
        [DefaultValue(null)]
        public int PersonWorkerId { get; set; }

        public Person Person { get; set; }

        [Required]
        public int rodzajUslugiId { get; set; }
        public RodzajeUslug rodzajUslug {  get; set; }

        [Required]
        [DefaultValue(1)]
        public int statusZleceniaId { get; set; }

        public StatusyZlecen statusZlecenia { get; set; }

        [Required]
        [DataType(DataType.DateTime)] //ustawia typ bazodanowy na datetime
        public DateTime dataPrzekazaniaPojazdu { get; set; }

        [Required]
        public string OpisZdarzenia { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime dataWplyniecia { get; set; }


        //kolekcje

        public ICollection<Wpis> wpisy {  get; set; }

    }
}
