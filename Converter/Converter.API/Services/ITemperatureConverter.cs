namespace Converter.API.Services
{
    public interface ITemperatureConverter
    {        
        decimal GetFahrenheitFromCelsius(decimal celsius);

        decimal GetCelsiusFromFahrenheit(decimal fahrenheit);
    }
}
