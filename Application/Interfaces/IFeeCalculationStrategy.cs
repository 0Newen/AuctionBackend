using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface IFeeCalculationStrategy
    {
        float CalculateFee(VehicleDto obj);
    }
}
