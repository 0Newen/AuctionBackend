using API.Controllers;
using Aplication.Common.Helpers;
using Aplication.Services.TypeVehicle;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTesting.Controllers
{
    public class VehicleTypeControllerTests
    {
        private readonly Mock<IVehicleType> _mockVehicleTypeService;
        private readonly VehicleTypeController _controller;

        public VehicleTypeControllerTests()
        {
            _mockVehicleTypeService = new Mock<IVehicleType>();
            _controller = new VehicleTypeController(_mockVehicleTypeService.Object);
        }

        // Test for Get() method
        [Fact]
        public async Task Get_ReturnsOkResult_WithListOfVehicleTypes()
        {
            // Arrange
            var vehicleTypeList = new List<VehicleType>
        {
            new VehicleType { Id = 1, Name = "Common" },
            new VehicleType { Id = 2, Name = "Luxury" }
        };
            _mockVehicleTypeService.Setup(service => service.GetAll()).ReturnsAsync(vehicleTypeList);

            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedResult = Assert.IsType<GenericResult<List<VehicleType>>>(okResult.Value);
            Assert.True(returnedResult.Success);
            Assert.Equal(2, returnedResult.Result.Count);
            Assert.Equal("Luxury", returnedResult.Result[1].Name);
        }
    }
}
