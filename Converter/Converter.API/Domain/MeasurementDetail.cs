using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Converter.API.Domain
{
    [Table("MeasurementDetails")]
    public class MeasurementDetail
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal MeasurementValue { get; set; }
    }
}
