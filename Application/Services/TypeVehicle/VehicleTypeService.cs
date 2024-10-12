using Aplication.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.TypeVehicle
{
    public class VehicleTypeService : IVehicleType
    {
        private readonly IVehicleTypeRepo _vehicleTypeRepo;

        public VehicleTypeService(IVehicleTypeRepo vehicleTypeRepo)
        {
           _vehicleTypeRepo = vehicleTypeRepo;
        }
        public Task<List<VehicleType>> GetAll()
        {
            return _vehicleTypeRepo.GetAll();
        }
    }
}
