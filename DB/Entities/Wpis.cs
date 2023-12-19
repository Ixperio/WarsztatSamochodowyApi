using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Entities
{
    public class Wpis
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ZlecenieId { get; set; }
        public Zlecenie Zlecenie { get; set; }

        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [Required]
        public int UslugaId { get; set; }
        public Usluga usluga { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] //ustawia datę na aktualną datę 
        [DataType(DataType.DateTime)] //ustawia typ bazodanowy na datetime
        public DateTime dataDodania { get; set; }

        [Required]
        public string Opis { get; set; }

        [Required]
        [DefaultValue(1)]
        public uint ilosc {  get; set; }

        [Required]
        [DefaultValue(false)]
        public bool isDeleted { get; set; }
    }
}
