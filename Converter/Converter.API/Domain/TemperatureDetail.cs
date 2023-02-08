using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Converter.API.Domain
{
    [Table("TemperatureDetails")]

    public class TemperatureDetail
    {
        [Key]
        public Guid Id { get; set; }
        public decimal Value1 { get; set; }
        public decimal Value2 { get; set; }
    }
}
