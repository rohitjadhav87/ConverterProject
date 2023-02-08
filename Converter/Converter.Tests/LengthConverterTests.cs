using Converter.API.Models;
using Converter.API.Repository;
using Converter.API.Services;
using Moq;
using NUnit.Framework;
using System;

namespace Converter.Tests
{
    public class LengthConverterTests
    {
        Mock<IMeasurementDetailsRepository> measurementDetailsRepoMock = new Mock<IMeasurementDetailsRepository>();
        LengthConverter lengthConverter;
        AppSettings appSettings;

        [SetUp]
        public void Setup()
        {
            measurementDetailsRepoMock = new Mock<IMeasurementDetailsRepository>();
            measurementDetailsRepoMock.Setup(fun => fun.GetByName("inches")).Returns(
                new API.Domain.MeasurementDetail
                {
                    MeasurementValue = 0.0394m,
                    Name = "inches"
                });
            measurementDetailsRepoMock.Setup(fun => fun.GetByName("feetToInch")).Returns(
                new API.Domain.MeasurementDetail
                {
                    MeasurementValue = 12,
                    Name = "feetToInch"
                });
            measurementDetailsRepoMock.Setup(fun => fun.GetByName("mm")).Returns(
                new API.Domain.MeasurementDetail
                {
                    MeasurementValue = 25.4000m,
                    Name = "mm"
                });
            appSettings = new AppSettings
            {
                DecimalPlaces = 4
            };

            lengthConverter = new LengthConverter(measurementDetailsRepoMock.Object, appSettings);
        }

        [Test]
        public void GetFeetFromMM_Test()
        {
            var data = lengthConverter.GetFeetFromMM(500);
            Assert.NotNull(data);
            Assert.AreEqual(1.6417, data);
        }

        [Test]
        public void GetFeetFromMM_Exception_Test()
        {
            SetUpForNullForFeet();
            var data = Assert.Throws<Exception>(() => lengthConverter.GetFeetFromMM(500));
            Assert.AreEqual("Unable to get measurement details.", data.Message);
        }

        [Test]
        public void GetFeetFromMM_Exception_For_FeetToInch_Test()
        {
            SetUpForNullForFeetToInch();
            var data = Assert.Throws<Exception>(() => lengthConverter.GetFeetFromMM(500));
            Assert.AreEqual("Unable to get measurement details.", data.Message);
        }

        [Test]
        public void GetMMFromFeet_Test()
        {
            var data = lengthConverter.GetMMFromFeet(1);
            Assert.NotNull(data);
            Assert.AreEqual(304.8, data);
        }

        [Test]
        public void GetMMFromFeet_Exception_Test()
        {
            SetUpForNullForMM();
            var data = Assert.Throws<Exception>(() => lengthConverter.GetMMFromFeet(1000));
            Assert.AreEqual("Unable to get measurement details.", data.Message);
        }

        [Test]
        public void GetMMFromFeet_Exception_For_FeetToInch_Test()
        {
            SetUpForNullForFeetToInch();
            var data = Assert.Throws<Exception>(() => lengthConverter.GetMMFromFeet(1000));
            Assert.AreEqual("Unable to get measurement details.", data.Message);
        }

        private void SetUpForNullForFeet()
        {
            measurementDetailsRepoMock.Setup(fun => fun.GetByName("inches")).Returns(null as API.Domain.MeasurementDetail);
        }

        private void SetUpForNullForFeetToInch()
        {
            measurementDetailsRepoMock.Setup(fun => fun.GetByName("inches")).Returns(
                new API.Domain.MeasurementDetail
                {
                    MeasurementValue = 0.0394m,
                    Name = "inches"
                });
            measurementDetailsRepoMock.Setup(fun => fun.GetByName("mm")).Returns(
                new API.Domain.MeasurementDetail
                {
                    MeasurementValue = 25.4000m,
                    Name = "mm"
                });
            measurementDetailsRepoMock.Setup(fun => fun.GetByName("feetToInch")).Returns(null as API.Domain.MeasurementDetail);
        }

        private void SetUpForNullForMM()
        {
            measurementDetailsRepoMock.Setup(fun => fun.GetByName("mm")).Returns(null as API.Domain.MeasurementDetail);
        }
    }
}
