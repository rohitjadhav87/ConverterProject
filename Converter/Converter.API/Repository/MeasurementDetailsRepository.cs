using Converter.API.Domain;
using System;
using System.Linq;

namespace Converter.API.Repository
{
    public class MeasurementDetailsRepository : IMeasurementDetailsRepository, IDisposable
    {
        private readonly ConverterDbContext _converterDbContext;

        public MeasurementDetailsRepository(ConverterDbContext converterDbContext)
        {
            _converterDbContext = converterDbContext;
        }

        public MeasurementDetail GetByName(string name)
        {
            return _converterDbContext.MeasurementDetails.FirstOrDefault(col => col.Name == name);
        }

        public void Dispose()
        {
            _converterDbContext.Dispose();
        }
    }
}
