using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class Students
    {
        [Key]
        [Required]
        [StringLength(450)]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public AspNetUsers User { get; set; }

        [Required]
        public string AdmissionNumber { get; set; }

        [Required]
        public DateTime AdmissionDate { get; set; }

        //CLASS 1 to many
        [ForeignKey("StdClass")]
        public int ClassRoomId { get; set; }
        public ClassRoom StdClass { get; set; }

        //parent 1 to 1
        public Parents Parent { get; set; }
        //Achievement  1 to many
        public List<AchievementDetails> Achievements { get; set; }
        public List<MarkCalculations> MarkCalculation { get; set; }
    }
}
