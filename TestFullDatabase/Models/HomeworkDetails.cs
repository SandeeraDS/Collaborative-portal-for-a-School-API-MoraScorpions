using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class HomeworkDetails
    {

        [Key]
        public int HomeworkId { get; set; }
        [Required]
        public string Topic { get; set; }
       
        public string PDF { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime Deadline { get; set; }
       // [Required]
        public DateTime VisibilityStartDate { get; set; }
      
        public Boolean Visibility { get; set; } = false;
       // [Required]
        public DateTime VisibilityEndDate { get; set; }
        [Required]
        public DateTime UploadedTime { get; set; }
        [Required]
        [ForeignKey("Ternary")]
        public int TernaryId { get; set; }
        public Ternary Ternary { get; set; }

    }
}
