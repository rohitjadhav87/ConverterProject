using Converter.API.Models;
using Converter.API.Repository;
using System;

namespace Converter.API.Services
{
    public class LengthConverter : ILengthConverter
    {
        private readonly IMeasurementDetailsRepository _measurementDetailsRepository;
        private readonly AppSettings _appSettings;

        public LengthConverter(IMeasurementDetailsRepository measurementDetailsRepository, AppSettings appSettings)
        {
            _measurementDetailsRepository = measurementDetailsRepository;
            _appSettings = appSettings;
        }

        public decimal GetFeetFromMM(decimal mm)
        {
            var measurementDetails = _measurementDetailsRepository.GetByName("inches");

            if (measurementDetails == null)
            { throw new Exception("Unable to get measurement details."); }

            decimal inches = mm * measurementDetails.MeasurementValue;

            var feettoInchDetails = _measurementDetailsRepository.GetByName("feetToInch");
            if (feettoInchDetails == null)
            { throw new Exception("Unable to get measurement details."); }

            return Math.Round(inches / feettoInchDetails.MeasurementValue, _appSettings.DecimalPlaces);
        }

        public decimal GetMMFromFeet(decimal feet)
        {
            var measurementDetails = _measurementDetailsRepository.GetByName("mm");

            if (measurementDetails == null)
            { throw new Exception("Unable to get measurement details."); }

            var feettoInchDetails = _measurementDetailsRepository.GetByName("feetToInch");
            if (feettoInchDetails == null)
            { throw new Exception("Unable to get measurement details."); }

            return Math.Round((feet * feettoInchDetails.MeasurementValue) * measurementDetails.MeasurementValue, _appSettings.DecimalPlaces);
        }
    }
}
