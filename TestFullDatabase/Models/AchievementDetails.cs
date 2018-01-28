using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class AchievementDetails
    {
        [Key]
        public int AchievementID { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public Students Student { get; set; }
    }
}
