using API.Request;
using Aplication.Common.Helpers;
using Aplication.Services.VehicleFee;
using AutoMapper;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleFee _ivehicleFee;
        private readonly IMapper _mapper;

        public VehicleController(IVehicleFee ivehicleFee, IMapper mapper)
        {
            _ivehicleFee = ivehicleFee;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(GenericResult<List<VehicleDto>>))]
        public async Task<IActionResult> Get()
        {
            var obj = await _ivehicleFee.GetAll();
            var result = new GenericResult<List<VehicleDto>>
            {
                Success = true,
                Result = obj
            };
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(GenericResult<VehicleDto>))]
        public async Task<IActionResult> Create([FromBody] CreateVehicleRequest request)
        {
            if (ModelState.IsValid)
            {
                var newVehicle = _mapper.Map<Vehicle>(request);
                var obj = await _ivehicleFee.Create(newVehicle);
                var result = new GenericResult<VehicleDto>
                {
                    Success = true,
                    Result = obj
                };
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{vehicleId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(GenericResult<VehicleDto>))]
        public async Task<IActionResult> EditVehicle(int vehicleId, [FromBody] CreateVehicleRequest request)
        {
            if (ModelState.IsValid)
            {
                var vehicle = _mapper.Map<Vehicle>(request);
                var obj = await _ivehicleFee.Update(vehicleId, vehicle);
                var result = new GenericResult<VehicleDto>
                {

                    Success = true,
                    Result = obj
                };
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{vehicleId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteVehicle(int vehicleId)
        {
            if (ModelState.IsValid)
            {
                var result = await _ivehicleFee.Delete(vehicleId);
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

    }
}
