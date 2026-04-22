using System.ComponentModel.DataAnnotations;

namespace Kias_Kar_Kompany.Models
{
    public class Owner
    {
        [Key]
        public int? OwnerId { get; set; }
        public string? OwnerName { get; set; }

        public string? OwnerAddress { get; set; }

        public int? OwnerCellNumber { get; set; }

        public string OwnerEmailAddress { get; set; }



        //owner can own a vehicle
        public List<Vehicle>? Vehicles { get; set; }

    }
}
