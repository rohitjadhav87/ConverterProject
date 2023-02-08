using Converter.API.Models;
using Converter.API.Repository;
using Converter.API.Services;
using Moq;
using NUnit.Framework;
using System;

namespace Converter.Tests
{
    public class WeightConverterTests
    {
        Mock<IMeasurementDetailsRepository> measurementDetailsRepoMock;
        WeightConverter weightConverter;
        AppSettings appSettings;

        [SetUp]
        public void Setup()
        {
            measurementDetailsRepoMock = new Mock<IMeasurementDetailsRepository>();
            measurementDetailsRepoMock.Setup(fun => fun.GetByName("pounds")).Returns(
                new API.Domain.MeasurementDetail
                {
                    MeasurementValue = 2.2046m,
                    Name = "pounds"
                });
            appSettings = new AppSettings
            {
                DecimalPlaces = 4
            };

            weightConverter = new WeightConverter(measurementDetailsRepoMock.Object, appSettings);
        }

        [Test]
        public void GetKgFromPound_Test()
        {
            var data = weightConverter.GetKgFromPound(26.4552m);
            Assert.NotNull(data);
            Assert.AreEqual(12, data);
        }

        [Test]
        public void GetKgFromPound_Exception_Test()
        {
            SetUpForNull();
            var data = Assert.Throws<Exception>(() => weightConverter.GetKgFromPound(26.4552m));
            Assert.AreEqual("Unable to get measurement details.", data.Message);
        }

        [Test]
        public void GetPondFromKg_Test()
        {
            var data = weightConverter.GetPoundFromKg(2.2046m);
            Assert.NotNull(data);
            Assert.AreEqual(4.8603m, data);
        }

        [Test]
        public void GetPondFromKg_Exception_Test()
        {
            SetUpForNull();
            var data = Assert.Throws<Exception>(() => weightConverter.GetPoundFromKg(2.2046m));
            Assert.AreEqual("Unable to get measurement details.", data.Message);
        }

        [Test]
        public void GetKgFromTon_Test()
        {
            SetUpForTon();
            var data = weightConverter.GetKgFromTon(0.011m);
            Assert.NotNull(data);
            Assert.AreEqual(11, data);
        }

        [Test]
        public void GetKgFromTon_Exception_Test()
        {
            var data = Assert.Throws<Exception>(() => weightConverter.GetKgFromTon(0.011m));
            Assert.AreEqual("Unable to get measurement details.", data.Message);
        }

        [Test]
        public void GetTonFromKg_Test()
        {
            SetUpForTon();
            var data = weightConverter.GetTonFromKg(1);
            Assert.NotNull(data);
            Assert.AreEqual(0.001, data);
        }

        [Test]
        public void GetTonFromKg_Exception_Test()
        {
            var data = Assert.Throws<Exception>(() => weightConverter.GetTonFromKg(1));
            Assert.AreEqual("Unable to get measurement details.", data.Message);
        }

        private void SetUpForTon()
        {
            measurementDetailsRepoMock.Setup(fun => fun.GetByName("tons")).Returns(
                new API.Domain.MeasurementDetail
                {
                    MeasurementValue = 0.001m,
                    Name = "tons"
                });
        }

        private void SetUpForNull()
        {
            measurementDetailsRepoMock.Setup(fun => fun.GetByName("pounds")).Returns(null as API.Domain.MeasurementDetail);
        }
    }
}
