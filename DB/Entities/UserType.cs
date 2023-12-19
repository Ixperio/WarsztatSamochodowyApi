using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entities
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        //Kolekcje
        public ICollection<Person> Persons { get; set; }
    }
}
