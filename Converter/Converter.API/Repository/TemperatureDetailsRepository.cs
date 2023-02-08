using Converter.API.Domain;
using System;
using System.Linq;

namespace Converter.API.Repository
{
    public class TemperatureDetailsRepository : ITemperatureDetailsRepository, IDisposable
    {
        private readonly ConverterDbContext _converterDbContext;

        public TemperatureDetailsRepository(ConverterDbContext converterDbContext)
        {
            _converterDbContext = converterDbContext;
        }        

        public TemperatureDetail GetTemperatureDetail()
        {
            return _converterDbContext.TemperatureDetails.FirstOrDefault();
        }

        public void Dispose()
        {
            _converterDbContext.Dispose();
        }
    }
}
