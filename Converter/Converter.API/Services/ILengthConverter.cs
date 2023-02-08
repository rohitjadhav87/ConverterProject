namespace Converter.API.Services
{
    public interface ILengthConverter
    {
        decimal GetMMFromFeet(decimal feet);

        decimal GetFeetFromMM(decimal mm);
    }
}
