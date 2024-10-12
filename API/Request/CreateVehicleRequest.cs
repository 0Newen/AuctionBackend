using System.ComponentModel.DataAnnotations;

namespace API.Request
{
    public class CreateVehicleRequest
    {
        [Required]
        public float Price { get; set; }
        [Required]
        public int TypeId { get; set; }
    }
}
