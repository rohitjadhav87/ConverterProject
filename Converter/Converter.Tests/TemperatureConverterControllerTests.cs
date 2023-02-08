using Converter.API.Controllers;
using Converter.API.Services;
using Moq;
using NUnit.Framework;

namespace Converter.Tests
{
    public class TemperatureConverterControllerTests
    {
        TemperatureConverterController _temperatureConverterController;

        [SetUp]
        public void Setup()
        {
            Mock<ITemperatureConverter> tempreatureConverterMock = new Mock<ITemperatureConverter>();
            tempreatureConverterMock.Setup(fun => fun.GetFahrenheitFromCelsius(It.IsAny<decimal>())).Returns(It.IsAny<decimal>);
            tempreatureConverterMock.Setup(fun => fun.GetCelsiusFromFahrenheit(It.IsAny<decimal>())).Returns(It.IsAny<decimal>);

            _temperatureConverterController = new TemperatureConverterController(tempreatureConverterMock.Object);
        }

        [Test]
        public void CelsiusToFahrenheit_Test()
        {
            var data = _temperatureConverterController.CelsiusToFahrenheit(1);
            Assert.NotNull(data);
        }

        [Test]
        public void FahrenheitToCelsius_Test()
        {
            var data = _temperatureConverterController.FahrenheitToCelsius(1);
            Assert.NotNull(data);
        }
    }
}
