using Converter.API.Models;
using Converter.API.Repository;
using System;

namespace Converter.API.Services
{
    public class TemperatureConverter : ITemperatureConverter
    {
        private readonly AppSettings _appSettings;
        private readonly ITemperatureDetailsRepository _temperatureDetailsRepository;

        public TemperatureConverter(ITemperatureDetailsRepository temperatureDetailsRepository, AppSettings appSettings)
        {
            _temperatureDetailsRepository = temperatureDetailsRepository;
            _appSettings = appSettings;
        }

        public decimal GetCelsiusFromFahrenheit(decimal fahrenheit)
        {
            var details = _temperatureDetailsRepository.GetTemperatureDetail();

            if (details == null)
            { throw new Exception("Unable to get temperature details."); }

            return Math.Round(decimal.Divide(fahrenheit - details.Value2, details.Value1), _appSettings.DecimalPlaces);
        }

        public decimal GetFahrenheitFromCelsius(decimal celsius)
        {
            var details = _temperatureDetailsRepository.GetTemperatureDetail();

            if (details == null)
            { throw new Exception("Unable to get temperature details."); }

            return Math.Round((celsius * details.Value1) + details.Value2, _appSettings.DecimalPlaces);
        }
    }
}
