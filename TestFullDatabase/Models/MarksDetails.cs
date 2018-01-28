using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class MarksDetails
    {

        [Key]
        public int MarksID { get; set; }

        //1 to many with subject
        [Required]
        [ForeignKey("Ternary")]
        public int TernaryId{ get; set; }
        public Ternary Ternary { get; set; }

        //Relavant Student
        [Required]
        [ForeignKey("Student")]
        public string StudentID { get; set; }
        public Students Student { get; set; }

        [Required]
        public string Term { get; set; }
        [Required]
        public int Marks { get; set; }

    }
}
