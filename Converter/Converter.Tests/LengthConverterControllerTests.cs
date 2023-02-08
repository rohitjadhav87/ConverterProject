using Converter.API.Controllers;
using Converter.API.Services;
using Moq;
using NUnit.Framework;

namespace Converter.Tests
{
    public class LengthConverterControllerTests
    {
        LengthConverterController _lengthConverterController;

        [SetUp]
        public void Setup()
        {
            Mock<ILengthConverter> lengthConverterMock = new Mock<ILengthConverter>();
            lengthConverterMock.Setup(fun => fun.GetFeetFromMM(It.IsAny<decimal>())).Returns(It.IsAny<decimal>);

            _lengthConverterController = new LengthConverterController(lengthConverterMock.Object);
        }

        [Test]
        public void MilimeterToFeet_Test()
        {
            var pounds = _lengthConverterController.MilimeterToFeet(1);
            Assert.NotNull(pounds);
        }

        [Test]
        public void MilimeterToFeet_InvalidData_Test()
        {
            var pounds = _lengthConverterController.MilimeterToFeet(0);
            Assert.NotNull(pounds);
        }

        [Test]
        public void FeetToMilimeter_Test()
        {
            var pounds = _lengthConverterController.FeetToMilimeter(1);
            Assert.NotNull(pounds);
        }

        [Test]
        public void FeetToMilimeter_InvalidData_Test()
        {
            var pounds = _lengthConverterController.FeetToMilimeter(0);
            Assert.NotNull(pounds);
        }
    }
}
