using Domain.Dtos;
using Domain.Models;

namespace Aplication.Services.VehicleFee
{
    public interface IVehicleFee
    {
        public Task<List<VehicleDto>> GetAll();
        public Task<VehicleDto> Create(Vehicle vehicle);
        public Task<VehicleDto> Update(int id, Vehicle vehicle);
        public Task<bool> Delete(int vehicleId);
    }
}
