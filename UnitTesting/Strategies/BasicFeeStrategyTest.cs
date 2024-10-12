using Aplication.Strategies;
using Domain.Dtos;
using Domain.Enums;

namespace UnitTesting.Strategies
{
    public class BasicFeeStrategyTests
    {
        private readonly BasicFeeStrategy _basicFeeStrategy;

        public BasicFeeStrategyTests()
        {
            _basicFeeStrategy = new BasicFeeStrategy();
        }

        [Theory]
        [InlineData(398, VehicleEnum.Common, 39.80)]
        [InlineData(501, VehicleEnum.Common, 50)]
        [InlineData(57, VehicleEnum.Common, 10)]
        [InlineData(1800, VehicleEnum.Luxury, 180)]
        [InlineData(1100, VehicleEnum.Common, 50)]
        public void CalculateFee_CommonVehicle_ReturnsExpectedFee(float price, VehicleEnum vehicleType, float expectedFee)
        {
            // Arrange
            var vehicleDto = new VehicleDto
            {
                Price = price,
                TypeId = (int)vehicleType // Cast to int
            };

            // Act
            float actualFee = _basicFeeStrategy.CalculateFee(vehicleDto);

            // Assert
            Assert.Equal(expectedFee, actualFee);
        }

        [Fact]
        public void CalculateFee_InvalidVehicleType_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var vehicleDto = new VehicleDto
            {
                Price = 100,
                TypeId = (int)VehicleEnum.Common + 2 // Invalid type
            };

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _basicFeeStrategy.CalculateFee(vehicleDto));
        }
    }
}
