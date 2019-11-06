using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApi.Models.Model
{
    public class MedicationModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Creation { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Quantity { get; set; }
    }
}
