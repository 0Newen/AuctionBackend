using API.Controllers;
using API.Request;
using Aplication.Common.Helpers;
using Aplication.Services.VehicleFee;
using Aplication.Strategies;
using AutoMapper;
using Domain.Dtos;
using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTesting.Controllers
{
    public class VehicleControllerTests
    {
        private readonly Mock<IVehicleFee> _mockVehicleFee;
        private readonly Mock<IMapper> _mockMapper;
        private readonly VehicleController _controller;

        public VehicleControllerTests()
        {
            _mockVehicleFee = new Mock<IVehicleFee>();
            _mockMapper = new Mock<IMapper>();
            _controller = new VehicleController(_mockVehicleFee.Object, _mockMapper.Object);
        }

        //Test for Get() method
        [Fact]
        public async Task Get_ReturnsOkResult_WithListOfVehicles()
        {
            //Arrange
            var vehicleList = new List<VehicleDto>
        {
            new VehicleDto
            {
                Id = 1,
                Price = 1000,
                TypeId = 1,
                TypeName = "common",
                BasicFee = 50,
                SpecialFee = 20,
                AssociationFee = 10,
                StorageFee = 100,
                TotalFee = 1180
            }
        };
            _mockVehicleFee.Setup(service => service.GetAll()).ReturnsAsync(vehicleList);

            //Act
            var result = await _controller.Get();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedResult = Assert.IsType<GenericResult<List<VehicleDto>>>(okResult.Value);
            Assert.True(returnedResult.Success);
            Assert.Single(returnedResult.Result);
        }

        //Test for Create(reuqest) method
        [Fact]
        public async Task Create_ReturnsOkResult_WhenValidModel()
        {
            //Arrange
            FeeCalculationContext feeContext = new FeeCalculationContext();
            var request = new CreateVehicleRequest { TypeId = 1, Price = 1000 };
            var vehicleDto = new VehicleDto
            {
                Id = 1,
                Price = request.Price,
                TypeId = request.TypeId,
                TypeName = "",
                BasicFee = 0,
                SpecialFee = 0,
                AssociationFee = 0,
                StorageFee = 0,
                TotalFee = 0
            };
            feeContext.CalculateFees(vehicleDto);
            var vehicle = new Vehicle { Id = vehicleDto.Id, TypeId = vehicleDto.TypeId, TotalFee = vehicleDto.TotalFee };

            _mockMapper.Setup(m => m.Map<Vehicle>(request)).Returns(vehicle);
            _mockVehicleFee.Setup(service => service.Create(vehicle)).ReturnsAsync(vehicleDto);

            //Act
            var result = await _controller.Create(request);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedResult = Assert.IsType<GenericResult<VehicleDto>>(okResult.Value);
            Assert.True(returnedResult.Success);
            Assert.Equal(1, returnedResult.Result.Id);
        }

        //Test for EditVehicle(id,request) method
        [Fact]
        public async Task EditVehicle_ReturnsOkResult_WhenValidModel()
        {
            //Arrange
            FeeCalculationContext feeContext = new FeeCalculationContext();
            var request = new CreateVehicleRequest { TypeId = 1, Price = 1000 };
            var vehicleDto = new VehicleDto
            {
                Id = 1,
                Price = request.Price,
                TypeId = request.TypeId,
                TypeName = "",
                BasicFee = 0,
                SpecialFee = 0,
                AssociationFee = 0,
                StorageFee = 0,
                TotalFee = 0
            };
            feeContext.CalculateFees(vehicleDto);
            var vehicle = new Vehicle { Id = vehicleDto.Id, TypeId = vehicleDto.TypeId, TotalFee = vehicleDto.TotalFee };

            _mockMapper.Setup(m => m.Map<Vehicle>(request)).Returns(vehicle);
            _mockVehicleFee.Setup(service => service.Update(1, vehicle)).ReturnsAsync(vehicleDto);

            //Act
            var result = await _controller.EditVehicle(1, request);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedResult = Assert.IsType<GenericResult<VehicleDto>>(okResult.Value);
            Assert.True(returnedResult.Success);
            Assert.Equal(1, returnedResult.Result.Id);
        }

        //Test for DeleteVehicle(id) method
        [Fact]
        public async Task DeleteVehicle_ReturnsOkResult_WhenSuccesfull()
        {
            // Arrange
            _mockVehicleFee.Setup(service => service.Delete(1)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteVehicle(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var isSuccess = Assert.IsType<bool>(okResult.Value);
            Assert.True(isSuccess);
        }

        //Test for Get() method
        [Theory]
        [InlineData(398.00, VehicleEnum.Common, 39.80, 7.96, 5.00, 100.00, 550.76)]
        [InlineData(501, VehicleEnum.Common, 50.00, 10.02, 10.0, 100.00, 671.02)]
        [InlineData(57, VehicleEnum.Common, 10, 1.14, 5.00, 100.00, 173.14)]
        [InlineData(1800, VehicleEnum.Luxury, 180, 72.00, 15.00, 100.00, 2167.00)]
        [InlineData(1100, VehicleEnum.Common, 50, 22.00, 15.00, 100.00, 1287.00)]
        public async Task Get_ReturnOkResult_WithListOfVehiclesComputed(float price, VehicleEnum vehicleType, float basicFee, float specialFee, float associationFee, float storageFee, float totalFee)
        {
            //Arrange
            FeeCalculationContext feeContext = new FeeCalculationContext();
            var request = new CreateVehicleRequest { TypeId = (int)vehicleType, Price = price };
            var vehicleDto = new VehicleDto
            {
                Id = 1,
                Price = request.Price,
                TypeId = request.TypeId,
                TypeName = vehicleType.ToString(),
                BasicFee = 0,
                SpecialFee = 0,
                AssociationFee = 0,
                StorageFee = 0,
                TotalFee = 0
            };
            feeContext.CalculateFees(vehicleDto);
            var vehicle = new Vehicle { Id = vehicleDto.Id, TypeId = vehicleDto.TypeId, TotalFee = vehicleDto.TotalFee };

            _mockMapper.Setup(m => m.Map<Vehicle>(request)).Returns(vehicle);
            _mockVehicleFee.Setup(service => service.Create(vehicle)).ReturnsAsync(vehicleDto);

            //Act
            var result = await _controller.Create(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedResult = Assert.IsType<GenericResult<VehicleDto>>(okResult.Value);

            Assert.True(returnedResult.Success);
            Assert.Equal(1, returnedResult.Result.Id);
            Assert.Equal(vehicleDto.BasicFee, basicFee);
            Assert.Equal(vehicleDto.SpecialFee, specialFee);
            Assert.Equal(vehicleDto.AssociationFee, associationFee);
            Assert.Equal(vehicleDto.StorageFee, storageFee);
            Assert.Equal(vehicleDto.TotalFee, totalFee);

        }

    }
}

