using Aplication.Common.Exceptions;
using Aplication.Interfaces;
using Aplication.Strategies;
using Domain.Dtos;
using Domain.Enums;
using Domain.Models;

namespace Aplication.Services.VehicleFee
{
    public class VehicleFeeService : IVehicleFee
    {
        private readonly IVehicleRepo _vehicleRepo;

        public VehicleFeeService(IVehicleRepo vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;
        }

        public async Task<List<VehicleDto>> GetAll()
        {
            FeeCalculationContext feeContext = new FeeCalculationContext();
            //Retrieving all the vehicles
            var vehicles = await _vehicleRepo.GetAll();
            var vehicleDtos = new List<VehicleDto>();

            //Iterating on vehicles
            vehicles.ForEach(vehicle =>
            {
                //Creating vehicleDto for inserting into the List
                var type = (VehicleEnum)vehicle.TypeId;

                VehicleDto vehicleDto = new VehicleDto()
                {
                    Id = vehicle.Id,
                    Price = vehicle.Price,
                    TypeId = vehicle.TypeId,
                    TypeName = type.ToString(),
                    BasicFee = 0,
                    SpecialFee = 0,
                    AssociationFee = 0,
                    StorageFee = 0,
                    TotalFee = 0,
                };
                //Calculating Fees
                feeContext.CalculateFees(vehicleDto);
                //Adding to the List
                vehicleDtos.Add(vehicleDto);
            });

            return vehicleDtos;
        }

        public async Task<VehicleDto> Create(Vehicle vehicle)
        {

            FeeCalculationContext feeContext = new FeeCalculationContext();

            var type = (VehicleEnum)vehicle.TypeId;

            //Creating a new vehicleDto

            VehicleDto vehicleDto = new VehicleDto()
            {
                Id = vehicle.Id,
                Price = vehicle.Price,
                TypeId = vehicle.TypeId,
                TypeName = type.ToString(),
                BasicFee = 0,
                SpecialFee = 0,
                AssociationFee = 0,
                StorageFee = 0,
                TotalFee = 0,
            };

            //Calculating Fees
            feeContext.CalculateFees(vehicleDto);

            //Updating to vehicle and inserting in DB
            vehicle.TotalFee = vehicleDto.TotalFee;
            var newVehicle = await _vehicleRepo.Create(vehicle);
            vehicleDto.Id = newVehicle.Id;

            return vehicleDto;
        }

        public async Task<VehicleDto> Update(int id, Vehicle vehicle)
        {
            FeeCalculationContext feeContext = new FeeCalculationContext();

            var currentVehicle = await _vehicleRepo.GetById(id) ?? throw new NotFoundException("Vehicle not found");
            var type = (VehicleEnum)vehicle.TypeId;

            currentVehicle.Price = vehicle.Price;
            currentVehicle.TypeId = vehicle.TypeId;


            //Creating a new vehicleDto
            VehicleDto vehicleDto = new VehicleDto()
            {
                Id = currentVehicle.Id,
                Price = vehicle.Price,
                TypeId = vehicle.TypeId,
                TypeName = type.ToString(),
                BasicFee = 0,
                SpecialFee = 0,
                AssociationFee = 0,
                StorageFee = 0,
                TotalFee = 0,
            };

            //Calculating Fees
            feeContext.CalculateFees(vehicleDto);

            //Updating to vehicle and inserting in DB
            await _vehicleRepo.Update(currentVehicle);

            return vehicleDto;
        }

        public Task<bool> Delete(int vehicleId)
        {
            return _vehicleRepo.DeleteById(vehicleId);
        }

    }
}