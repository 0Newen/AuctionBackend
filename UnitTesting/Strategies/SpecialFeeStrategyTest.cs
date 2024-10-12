using Aplication.Strategies;
using Domain.Dtos;
using Domain.Enums;

namespace UnitTesting.Strategies
{
    public class SpecialFeeStrategyTests
    {
        private readonly SpecialFeeStrategy _specialFeeStrategy;

        public SpecialFeeStrategyTests()
        {
            _specialFeeStrategy = new SpecialFeeStrategy();
        }

        [Theory]
        [InlineData(398, VehicleEnum.Common, 7.96)]
        [InlineData(501, VehicleEnum.Common, 10.02)]
        [InlineData(57, VehicleEnum.Common, 1.14)]
        [InlineData(1800, VehicleEnum.Luxury, 72)]
        [InlineData(1100, VehicleEnum.Common, 22)]
        public void CalculateFee_ReturnsExpectedSpecialFee(float price, VehicleEnum vehicleType, float expectedFee)
        {
            // Arrange
            var vehicleDto = new VehicleDto
            {
                Price = price,
                TypeId = (int)vehicleType // Cast to int
            };

            // Act
            float actualFee = _specialFeeStrategy.CalculateFee(vehicleDto);

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
            Assert.Throws<ArgumentOutOfRangeException>(() => _specialFeeStrategy.CalculateFee(vehicleDto));
        }
    }
}
