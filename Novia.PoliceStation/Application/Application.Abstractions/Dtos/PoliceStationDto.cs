using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Novia.PoliceStationManagement.Application.Abstractions.Dtos
{
    public class PoliceStationDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        [Range(0, uint.MaxValue, ErrorMessage = "Workers must be a positive number")]
        public uint Workers { get; set; }

        [Required]
        public string Chief { get; set; }
    }
}
