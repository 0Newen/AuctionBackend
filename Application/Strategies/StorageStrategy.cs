using Aplication.Interfaces;
using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Strategies
{
    public class StorageStrategy : IFeeCalculationStrategy
    {
        public float CalculateFee(VehicleDto obj)
        {
            return 100;
        }
    }
}
