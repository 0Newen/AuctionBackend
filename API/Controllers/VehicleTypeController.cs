using Aplication.Common.Helpers;
using Aplication.Services.TypeVehicle;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class VehicleTypeController : ControllerBase
    {
        private readonly IVehicleType _ivehicleType;

        public VehicleTypeController(IVehicleType ivehicleType)
        {
            _ivehicleType = ivehicleType;
        }

        [HttpGet(Name = "GetVehicleType")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(GenericResult<List<VehicleType>>))]
        public async Task<IActionResult> Get()
        {
            var obj = await _ivehicleType.GetAll();
            var result = new GenericResult<List<VehicleType>>()
            {
                Success = true,
                Result = obj
            };
            return Ok(result);
        }
    }
}
