using Aplication.Strategies;
using Domain.Dtos;

namespace UnitTesting.Strategies
{
    public class AssociationFeeStrategyTests
    {
        private readonly AssociationFeeStrategy _associationFeeStrategy;

        public AssociationFeeStrategyTests()
        {
            _associationFeeStrategy = new AssociationFeeStrategy();
        }

        [Theory]
        [InlineData(398, 5)]
        [InlineData(501, 10)]
        [InlineData(57, 5)]
        [InlineData(1800, 15)]
        [InlineData(1100, 15)]
        public void CalculateFee_ReturnsExpectedAssociationFee(float price, float expectedFee)
        {
            // Arrange
            var vehicleDto = new VehicleDto
            {
                Price = price
            };

            // Act
            float actualFee = _associationFeeStrategy.CalculateFee(vehicleDto);

            // Assert
            Assert.Equal(expectedFee, actualFee);
        }
    }
}
