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
    public class SpecialFeeStrategy : IFeeCalculationStrategy
    {
        public float CalculateFee(VehicleDto obj)
        {
            VehicleEnum vehicleType = (VehicleEnum)obj.TypeId;

            return vehicleType switch
            {
                VehicleEnum.Common => obj.Price * 0.02f,
                VehicleEnum.Luxury => obj.Price * 0.04f,
                _ => throw new ArgumentOutOfRangeException("Invalid vehicle type")
            };
        }
    }
}
