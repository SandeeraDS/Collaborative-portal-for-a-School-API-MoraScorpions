using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class Subject
    {

        [Key]
        public int SubjectId { get; set; }
        [Required]
        public string SubjectName { get; set; }

        [Required]
        public string SubjectCode { get; set; }

        // with class with subject
        public List<ClassWithSubjects> ClassesOfSubject { get; set; }
        // 1 to many with Ternary
        public List<Ternary> TernarySubject { get; set; }

    }
}
