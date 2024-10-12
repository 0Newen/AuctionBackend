using Aplication.Strategies;
using Domain.Dtos;

namespace UnitTesting.Strategies
{
    public class StorageStrategyTests
    {
        private readonly StorageStrategy _storageStrategy;

        public StorageStrategyTests()
        {
            _storageStrategy = new StorageStrategy();
        }

        [Fact]
        public void CalculateFee_ReturnsFixedStorageFee()
        {
            // Arrange
            var vehicleDto = new VehicleDto();

            // Act
            float actualFee = _storageStrategy.CalculateFee(vehicleDto);

            // Assert
            Assert.Equal(100, actualFee);
        }
    }
}
