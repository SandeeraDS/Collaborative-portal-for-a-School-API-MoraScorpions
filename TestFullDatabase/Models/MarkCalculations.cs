using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class MarkCalculations
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float Average { get; set; }
        [Required]
        public string Term { get; set; }
        [Required]
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public Students Student { get; set; }
    }
}
