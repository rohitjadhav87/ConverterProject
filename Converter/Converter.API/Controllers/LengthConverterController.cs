using Converter.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Converter.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LengthConverterController : ControllerBase
    {
        private readonly ILengthConverter _lengthConverter;

        public LengthConverterController(ILengthConverter lengthConverter)
        {
            _lengthConverter = lengthConverter;
        }

        [Route("MilimeterToFeet")]
        public IActionResult MilimeterToFeet([FromQuery] decimal milimeter)
        {
            if (milimeter <= 0) return BadRequest("Please enter valid Milimeter");
            return Ok(_lengthConverter.GetFeetFromMM(milimeter));
        }

        [Route("FeetToMilimeter")]
        public IActionResult FeetToMilimeter([FromQuery] decimal feet)
        {
            if (feet <= 0) return BadRequest("Please enter valid Feet");
            return Ok(_lengthConverter.GetMMFromFeet(feet));
        }
    }
}
