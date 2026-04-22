using System.ComponentModel.DataAnnotations;

namespace Kias_Kar_Kompany.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }

        public required string VehicleName { get; set; }
        public required string VehicleModel { get; set; }
        public required int VehiclePrice { get; set; }
        public required string VehicleType { get; set; } = "Sedan";
        public string? VehicleImageURL { get; set; }

        [Required]
        public int? ManufacturerId { get; set; }

        [Required]
        public int? OwnerId { get; set; }

        //navigation - vehicle belongs to one manufacturer
        public Manufacturer? Manufacturer { get; set; }
        public Owner? Owner { get; set; }
    }
}
