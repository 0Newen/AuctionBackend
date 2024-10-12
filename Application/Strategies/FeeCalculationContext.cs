using Aplication.Interfaces;
using Domain.Dtos;
using Domain.Enums;

namespace Aplication.Strategies
{
    public class FeeCalculationContext
    {
        private readonly Dictionary<FeeEnum, IFeeCalculationStrategy> _strategies;

        public FeeCalculationContext()
        {
            _strategies = new Dictionary<FeeEnum, IFeeCalculationStrategy> {
                {FeeEnum.Basic, new BasicFeeStrategy()} ,
                {FeeEnum.Special, new SpecialFeeStrategy()} ,
                {FeeEnum.Association, new AssociationFeeStrategy()} ,
                {FeeEnum.Storage, new StorageStrategy()}
            };
        }

        public void CalculateFees(VehicleDto vehicle)
        {
            vehicle.BasicFee = _strategies[FeeEnum.Basic].CalculateFee(vehicle);
            vehicle.SpecialFee = _strategies[FeeEnum.Special].CalculateFee(vehicle);
            vehicle.AssociationFee = _strategies[FeeEnum.Association].CalculateFee(vehicle);
            vehicle.StorageFee = _strategies[FeeEnum.Storage].CalculateFee(vehicle);
            vehicle.TotalFee = vehicle.Price + vehicle.BasicFee + vehicle.SpecialFee + vehicle.AssociationFee + vehicle.StorageFee;
        }
    }
}
