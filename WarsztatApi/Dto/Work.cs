using DB.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace WarsztatApi.Dto
{
    public class WorkDTOAdd
    {

        [Required]
        public int SamochodId { get; set; }

        [Required]
        public int rodzajUslugiId { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        public DateTime dataPrzekazaniaPojazdu { get; set; }

        [Required]
        public string OpisZdarzenia { get; set; }

        [Required]
        public string trustString { get; set; }

    }

    public class WorkDTOView
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int SamochodId { get; set; }

        [Required]
        public int rodzajUslugiId { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        public DateTime dataPrzekazaniaPojazdu { get; set; }

        [Required]
        public string OpisZdarzenia { get; set; }


        [Required]
        public DateTime dataDodania {  get; set; }
    }

}
