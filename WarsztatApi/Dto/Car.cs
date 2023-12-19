using DB.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WarsztatApi.Dto
{
    public class SamochodDto
    {
        [Required]
        [DisplayName("Numer VIN pojazdu")]
        [StringLength(17)]
        [MaxLength(17)]
        [MinLength(17)]
        public string VIN { get; set; }

        [Required]
        [MaxLength(16)]
        public string Nazwa { get; set; }
        [Required]
        public ModelSamochoduDto modelSamochodu { get; set; }
        [Required]
        public int rokProdukcji { get; set; }
        [Required]
        public PaliwoDto rodzajPaliwa { get; set; }
        public double pojemnoscSkokowa { get; set; }

        [Required]
        public uint przebieg { get; set; }

        [Required]
        public string nr_rejestracyjny { get; set; }

    }
    public class SamochodDtoView
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Numer VIN pojazdu")]
        [StringLength(17)]
        [MaxLength(17)]
        [MinLength(17)]
        public string VIN { get; set; }

        [Required]
        [MaxLength(16)]
        public string Nazwa { get; set; }
        [Required]
        public ModelSamochoduDto modelSamochodu { get; set; }
        [Required]
        public int rokProdukcji { get; set; }
        [Required]
        public PaliwoDto rodzajPaliwa { get; set; }
        public double pojemnoscSkokowa { get; set; }

        [Required]
        public uint przebieg { get; set; }

        [Required]
        public string nr_rejestracyjny { get; set; }

    }
    public class SamochodDtoAdd
    {
        [Required]
        [DisplayName("Numer VIN pojazdu")]
        [StringLength(17)]
        [MaxLength(17)]
        [MinLength(17)]
        public string VIN { get; set; }

        [Required]
        [MaxLength(16)]
        public string Nazwa { get; set; }
        [Required]
        public int modelSamochdouId { get; set; }
        [Required]
        public int rokProdukcji { get; set; }

        [Required]
        public double pojemnoscSkokowa {  get; set; }

        [Required]
        public int rodzajPaliwaId { get; set; }

        [Required]
        public uint przebieg {  get; set; }

        [Required]
        public string nr_rejestracyjny { get; set; }

        [Required]
        public string trustString { get; set; }


    }

    public class SamochodDtoDelete
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string trustString { get; set; }

    }
    public class ModelSamochoduDtoView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public WersjeNadwoziaDto WersjaNadwozia { get; set; }

        public MarkaDto Marka { get; set; }


    }
    public class ModelSamochoduDtoGetView
    {
        [Required]
        public int WersjaNadwozia { get; set; }
        [Required]
        public int Marka { get; set; }
        [Required]
        public string trustString { get; set; }
    }

    public class ModelSamochoduDtoAdd
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int WersjaNadwoziaId { get; set; }
        [Required]
        public int MarkaId { get; set; }
        [Required]
        public string trustString { get; set; }

    }
    public class ModelSamochoduDto
    {
        public string Name { get; set; }
        public WersjeNadwoziaDto WersjaNadwozia { get; set; }

        public MarkaDto Marka { get; set; }


    }

    public class WersjeNadwoziaDtoAdd
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string trustString { get; set; }

    }

    public class WersjeNadwoziaDto
    {
        [Required]
        public string Name { get; set; }

    }

    public class WersjeNadwoziaDtoShow
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }


    public class MarkaDtoAdd
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string trustString { get; set; }
    }
    public class MarkaDto
    {
        public string Name { get; set; }
    }
    public class MarkaDtoView
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PaliwoDto
    {
        public string Name { get; set; }
    }

    public class PaliwoDtoView
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
