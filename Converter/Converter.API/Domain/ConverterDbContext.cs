using Microsoft.EntityFrameworkCore;

namespace Converter.API.Domain
{
    public class ConverterDbContext : DbContext
    {
        public ConverterDbContext(DbContextOptions<ConverterDbContext> options) : base(options) { }

        public DbSet<MeasurementDetail> MeasurementDetails { get; set; }
        public DbSet<TemperatureDetail> TemperatureDetails { get; set; }
    }
}
