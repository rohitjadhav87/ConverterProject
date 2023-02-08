using Converter.API.Models;
using Converter.API.Repository;
using Converter.API.Services;
using Moq;
using NUnit.Framework;
using System;

namespace Converter.Tests
{
    public class TemperatureConverterTests
    {
        Mock<ITemperatureDetailsRepository> temperatureDetailsRepoMock;
        TemperatureConverter temperatureConverter;
        AppSettings appSettings;

        [SetUp]
        public void Setup()
        {
            temperatureDetailsRepoMock = new Mock<ITemperatureDetailsRepository>();
            temperatureDetailsRepoMock.Setup(fun => fun.GetTemperatureDetail()).Returns(
                new API.Domain.TemperatureDetail
                {
                    Value1 = 1.80m,
                    Value2 = 32
                });
            appSettings = new AppSettings
            {
                DecimalPlaces = 4
            };

            temperatureConverter = new TemperatureConverter(temperatureDetailsRepoMock.Object, appSettings);
        }

        [Test]
        public void GetCelsiusFromFahrenheit_Test()
        {
            var data = temperatureConverter.GetCelsiusFromFahrenheit(86);
            Assert.NotNull(data);
            Assert.AreEqual(30, data);
        }

        [Test]
        public void GetCelsiusFromFahrenheit_Exception_Test()
        {
            SetUpForNull();
            var data = Assert.Throws<Exception>(() => temperatureConverter.GetCelsiusFromFahrenheit(86));
            Assert.AreEqual("Unable to get temperature details.", data.Message);          
        }

        [Test]
        public void GetFahrenheitFromCelsius_Test()
        {
            var data = temperatureConverter.GetFahrenheitFromCelsius(30);
            Assert.NotNull(data);
            Assert.AreEqual(86, data);
        }

        [Test]
        public void GetFahrenheitFromCelsius_Exception_Test()
        {
            SetUpForNull();
            var data = Assert.Throws<Exception>(() => temperatureConverter.GetFahrenheitFromCelsius(30));
            Assert.AreEqual("Unable to get temperature details.", data.Message);            
        }

        private void SetUpForNull()
        {
            temperatureDetailsRepoMock.Setup(fun => fun.GetTemperatureDetail()).Returns(null as API.Domain.TemperatureDetail);
        }
    }
}
