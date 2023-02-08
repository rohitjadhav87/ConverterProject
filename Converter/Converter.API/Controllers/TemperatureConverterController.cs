using Converter.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Converter.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureConverterController : ControllerBase
    {
        private ITemperatureConverter _temperatureConverter;

        public TemperatureConverterController(ITemperatureConverter temperatureConverter)
        {
            _temperatureConverter = temperatureConverter;
        }

        [Route("CelsiusToFahrenheit/{celsius}")]
        public IActionResult CelsiusToFahrenheit([FromRoute] decimal celsius)
        {
            return Ok(_temperatureConverter.GetFahrenheitFromCelsius(celsius));
        }

        [Route("FahrenheitToCelsius/{fahrenheit}")]
        public IActionResult FahrenheitToCelsius([FromRoute] decimal fahrenheit)
        {
            return Ok(_temperatureConverter.GetCelsiusFromFahrenheit(fahrenheit));
        }
    }
}
