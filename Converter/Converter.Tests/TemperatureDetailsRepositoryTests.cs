using Converter.API.Domain;
using Converter.API.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace Converter.Tests
{
    public class TemperatureDetailsRepositoryTests
    {
        TemperatureDetailsRepository temperatureDetailsRepository;

        [SetUp]
        public void Setup()
        {
            temperatureDetailsRepository = new TemperatureDetailsRepository(GetDbContext());
        }

        [Test]
        public void GetTemperatureDetail_Test()
        {
            var data = temperatureDetailsRepository.GetTemperatureDetail();
            Assert.NotNull(data);
        }

        [Test]
        public void Dispose_Test()
        {
            Assert.DoesNotThrow(() => temperatureDetailsRepository.Dispose());
        }

        private ConverterDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ConverterDbContext>()
                        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                        .Options;
            var databaseContext = new ConverterDbContext(options);
            databaseContext.Database.EnsureCreated();
            databaseContext.TemperatureDetails.Add(new TemperatureDetail
            {
                Id = Guid.NewGuid(),
                Value1 = 1.80m,
                Value2 = 32
            });
            databaseContext.SaveChanges();

            return databaseContext;
        }
    }
}
