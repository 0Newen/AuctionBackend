using Aplication.Interfaces;
using Domain.Dtos;
using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Strategies
{
    public class BasicFeeStrategy : IFeeCalculationStrategy
    {
        public float CalculateFee(VehicleDto obj)
        {
            VehicleEnum vehicleType = (VehicleEnum)obj.TypeId;

            return vehicleType switch
            {
                VehicleEnum.Common => Math.Clamp(obj.Price * 0.1f, 10, 50),
                VehicleEnum.Luxury => Math.Clamp(obj.Price * 0.1f, 25, 200),
                _ => throw new ArgumentOutOfRangeException("Invalid vehicle type")
            };
        }
    }
}
