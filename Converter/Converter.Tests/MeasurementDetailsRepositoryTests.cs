using Converter.API.Domain;
using Converter.API.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace Converter.Tests
{
    public class MeasurementDetailsRepositoryTests
    {
        MeasurementDetailsRepository measurementDetailsRepository;

        [SetUp]
        public void Setup()
        {
            measurementDetailsRepository = new MeasurementDetailsRepository(GetDbContext());
        }

        [Test]
        public void GetByName_Test()
        {
            var data = measurementDetailsRepository.GetByName("inches");
            Assert.NotNull(data);
        }

        [Test]
        public void Dispose_Test()
        {

            Assert.DoesNotThrow(() => measurementDetailsRepository.Dispose());
        }

        private ConverterDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ConverterDbContext>()
                        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                        .Options;
            var databaseContext = new ConverterDbContext(options);
            databaseContext.Database.EnsureCreated();
            databaseContext.MeasurementDetails.Add(new MeasurementDetail
            {
                Id = Guid.NewGuid(),
                Name = "inches",
                MeasurementValue = 0.0394m
            });

            databaseContext.SaveChanges();

            return databaseContext;
        }
    }
}
