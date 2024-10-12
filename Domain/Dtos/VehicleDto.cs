using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public float BasicFee { get; set; }
        public float SpecialFee { get; set; }
        public float AssociationFee { get; set;}
        public float StorageFee { get; set; }
        public float TotalFee { get; set; }
    }
}
