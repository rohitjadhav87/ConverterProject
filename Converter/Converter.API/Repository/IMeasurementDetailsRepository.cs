using Converter.API.Domain;

namespace Converter.API.Repository
{
    public interface IMeasurementDetailsRepository
    {
        MeasurementDetail GetByName(string name);
    }
}
