using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.TypeVehicle
{
    public interface IVehicleType
    {
        public Task<List<VehicleType>> GetAll();
    }
}
