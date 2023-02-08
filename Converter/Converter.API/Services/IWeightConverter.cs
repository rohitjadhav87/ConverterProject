namespace Converter.API.Services
{
    public interface IWeightConverter
    {
        decimal GetPoundFromKg(decimal kg);

        decimal GetKgFromPound(decimal pound);

        decimal GetTonFromKg(decimal kg);

        decimal GetKgFromTon(decimal ton);
    }
}
