using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Aplication.Services.FeeTypeServ;
using Aplication.Common.Helpers;

namespace BidApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeeTypeController : ControllerBase
    {
        private readonly IFeeType _ifeeType;

        public FeeTypeController(IFeeType feeTypeService)
        {
            _ifeeType = feeTypeService;
        }

        [HttpGet(Name = "GetFeeType")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(GenericResult<List<FeeType>>))]
        public async Task<IActionResult> Get()
        {
            var obj = await _ifeeType.GetAll();
            var result = new GenericResult<List<FeeType>>
            {
                Success = true,
                Result = obj,
            };
            return Ok(result);
        }
    }
}
