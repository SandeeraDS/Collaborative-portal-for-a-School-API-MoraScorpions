using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class Notice
    {
        [Key]
        public int NoticeId { get; set; }
        [Required]
        public string Topic { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime LastUpdatedDate{get;set;}
        [Required]
        public DateTime EndDate { get; set; }

        public bool StudentView { get; set; } = false;
        public bool TeacherView { get; set; } = false;
        public bool ParentView { get; set; } = false;
    }
}
