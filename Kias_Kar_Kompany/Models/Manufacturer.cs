using System.ComponentModel.DataAnnotations;

namespace Kias_Kar_Kompany.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Manufacturer_Name { get; set; } = string.Empty;

        public string? Manufacturer_Country { get; set; }

        //nav - one manufacturer can have many vehicles
        public List<Vehicle>? Vehicles { get; set; }

    }
}