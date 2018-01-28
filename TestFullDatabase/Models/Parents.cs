using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class Parents
    {
        [Key]
        [Required]
        [StringLength(450)]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public AspNetUsers User { get; set; }

        [Required]
        [ForeignKey("Student")]

        public string StudentId { get; set; }



        public Students Student { get; set; }
    }
}
