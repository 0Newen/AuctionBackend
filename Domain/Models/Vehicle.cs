using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("VehicleType")]
        public int TypeId { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public float TotalFee { get; set; }
    }
}
