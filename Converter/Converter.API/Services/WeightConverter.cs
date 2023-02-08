using Converter.API.Models;
using Converter.API.Repository;
using System;

namespace Converter.API.Services
{
    public class WeightConverter : IWeightConverter
    {
        private readonly IMeasurementDetailsRepository _measurementDetailsRepository;
        private readonly AppSettings _appSettings;

        public WeightConverter(IMeasurementDetailsRepository measurementDetailsRepository, AppSettings appSettings)
        {
            _measurementDetailsRepository = measurementDetailsRepository;
            _appSettings = appSettings;
        }

        public decimal GetKgFromPound(decimal pound)
        {
            var measurementDetails = _measurementDetailsRepository.GetByName("pounds");

            if (measurementDetails == null)
            { throw new Exception("Unable to get measurement details."); }

            return Math.Round(pound / measurementDetails.MeasurementValue, _appSettings.DecimalPlaces);
        }

        public decimal GetPoundFromKg(decimal kg)
        {
            var measurementDetails = _measurementDetailsRepository.GetByName("pounds");

            if (measurementDetails == null)
            { throw new Exception("Unable to get measurement details."); }

            return Math.Round(kg * measurementDetails.MeasurementValue, _appSettings.DecimalPlaces);
        }

        public decimal GetTonFromKg(decimal kg)
        {
            var measurementDetails = _measurementDetailsRepository.GetByName("tons");

            if (measurementDetails == null)
            { throw new Exception("Unable to get measurement details."); }

            return Math.Round(kg * measurementDetails.MeasurementValue, _appSettings.DecimalPlaces);
        }

        public decimal GetKgFromTon(decimal ton)
        {
            var measurementDetails = _measurementDetailsRepository.GetByName("tons");

            if (measurementDetails == null)
            { throw new Exception("Unable to get measurement details."); }


            return Math.Round(ton / measurementDetails.MeasurementValue, _appSettings.DecimalPlaces);
        }

    }
}
