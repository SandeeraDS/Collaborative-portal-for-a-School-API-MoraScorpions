using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class Teachers
    {
        [Key]
        [Required]
        [StringLength(450)]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public AspNetUsers User { get; set; }
        [Required]
        public string TeacherGrade { get; set; }
            // 1 to many with Ternary
        public List<Ternary> TernaryTeacher { get; set; }

        public List<TeacherQualifications> Qualifications { get; set; }

        [ForeignKey("TchrClass")]
        public int ClassRoomId { get; set; }
        public ClassRoom TchrClass { get; set; }
    }
}
