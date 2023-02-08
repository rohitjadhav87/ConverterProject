using Converter.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Converter.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeightConverterController : ControllerBase
    {
        private readonly IWeightConverter _weightConverter;
        public WeightConverterController(IWeightConverter weightConverter)
        {
            _weightConverter = weightConverter;
        }

        [Route("KgToPounds")]
        public IActionResult KgToPounds([FromQuery] decimal kiloGram)
        {
            if (kiloGram <= 0) return BadRequest("Please enter valid KiloGram");
            return Ok(_weightConverter.GetPoundFromKg(kiloGram));
        }

        [Route("PoundsToKg")]
        public IActionResult PoundsToKg([FromQuery] decimal pounds)
        {
            if (pounds <= 0) return BadRequest("Please enter valid Pounds");
            return Ok(_weightConverter.GetKgFromPound(pounds));
        }

        [Route("KgToTon")]
        public IActionResult KgToTon([FromQuery] decimal kiloGram)
        {
            if (kiloGram <= 0) return BadRequest("Please enter valid KiloGram");
            return Ok(_weightConverter.GetTonFromKg(kiloGram));
        }

        [Route("TonToKg")]
        public IActionResult TonToKg([FromQuery] decimal ton)
        {
            if (ton <= 0) return BadRequest("Please enter valid ton");
            return Ok(_weightConverter.GetKgFromTon(ton));
        }
    }
}
