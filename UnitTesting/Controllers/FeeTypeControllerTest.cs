using Aplication.Common.Helpers;
using Aplication.Services.FeeTypeServ;
using BidApi.Controllers;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTesting.Controllers
{
    public class FeeTypeControllerTests
    {
        private readonly Mock<IFeeType> _mockFeeTypeService;
        private readonly FeeTypeController _controller;

        public FeeTypeControllerTests()
        {
            _mockFeeTypeService = new Mock<IFeeType>();
            _controller = new FeeTypeController(_mockFeeTypeService.Object);
        }

        // Test for Get() method
        [Fact]
        public async Task Get_ReturnsOkResult_WithListOfFeeTypes()
        {
            // Arrange
            var feeTypeList = new List<FeeType>
        {
            new FeeType { Id = 1, Name = "Basic" },
            new FeeType { Id = 2, Name = "Special" },
            new FeeType { Id = 3, Name = "Association" },
            new FeeType { Id = 4, Name = "Storage" }
        };
            _mockFeeTypeService.Setup(service => service.GetAll()).ReturnsAsync(feeTypeList);

            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedResult = Assert.IsType<GenericResult<List<FeeType>>>(okResult.Value);
            Assert.True(returnedResult.Success);
            Assert.Equal(4, returnedResult.Result.Count);
            Assert.Equal("Basic", returnedResult.Result[0].Name);
        }
    }
}
