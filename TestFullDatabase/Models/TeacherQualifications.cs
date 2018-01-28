using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class TeacherQualifications
    {

        [Required]
        [Key]
        public string Qualification { get; set; }


        //1 to many 
        [Required]
        [ForeignKey("Teacher")]
        public string TeacherId { get; set; }
        public Teachers Teacher { get; set; }

    }
}
