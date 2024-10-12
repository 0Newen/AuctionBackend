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
    public class AssociationFeeStrategy : IFeeCalculationStrategy
    {
        public float CalculateFee(VehicleDto obj)
        {
            float price = obj.Price;

            if (price <= 500)
            {
                return 5;
            }
            else if (price <= 1000)
            {
                return 10;
            }
            else if (price <= 3000)
            {
                return 15;
            }
            else
            {
                return 20;
            }
        }
    }
}
