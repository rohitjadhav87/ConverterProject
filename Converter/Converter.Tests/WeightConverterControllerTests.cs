using Converter.API.Controllers;
using Converter.API.Services;
using Moq;
using NUnit.Framework;

namespace Converter.Tests
{
    public class WeightConverterControllerTests
    {
        WeightConverterController _weightConverterController;

        [SetUp]
        public void Setup()
        {
            Mock<IWeightConverter> weightConverterMock = new Mock<IWeightConverter>();
            weightConverterMock.Setup(fun => fun.GetPoundFromKg(It.IsAny<decimal>())).Returns(It.IsAny<decimal>);

            _weightConverterController = new WeightConverterController(weightConverterMock.Object);
        }

        [Test]
        public void KgToPounds_Test()
        {
            var pounds = _weightConverterController.KgToPounds(1);
            Assert.NotNull(pounds);
        }

        [Test]
        public void KgToPounds_InvaliData_Test()
        {
            var pounds = _weightConverterController.KgToPounds(0);
            Assert.NotNull(pounds);
        }

        [Test]
        public void PoundsToKg_Test()
        {
            var kg = _weightConverterController.PoundsToKg(1);
            Assert.NotNull(kg);
        }

        [Test]
        public void PoundsToKg_InvalidData_Test()
        {
            var kg = _weightConverterController.PoundsToKg(0);
            Assert.NotNull(kg);
        }

        [Test]
        public void KgToTon_Test()
        {
            var ton = _weightConverterController.KgToTon(1);
            Assert.NotNull(ton);
        }

        [Test]
        public void KgToTon_InvalidData_Test()
        {
            var ton = _weightConverterController.KgToTon(0);
            Assert.NotNull(ton);
        }

        [Test]
        public void TonToKg_Test()
        {
            var kg = _weightConverterController.TonToKg(1);
            Assert.NotNull(kg);
        }

        [Test]
        public void TonToKg_InvalidData_Test()
        {
            var kg = _weightConverterController.TonToKg(0);
            Assert.NotNull(kg);
        }
    }
}