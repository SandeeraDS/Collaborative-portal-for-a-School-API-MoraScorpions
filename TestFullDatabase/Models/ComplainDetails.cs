using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class ComplainDetails
    {
        [Key]
        public int ComplainId { get; set; }
        [Required]
        public string Content { get; set; }
        
        [Required]
        public string Topic { get; set; }

        [Required]
        [ForeignKey("Users")]
        public string ComplaineeId { get; set; }
        public AspNetUsers Users { get; set; }

        //complainer connection 1 to many 
        [Required]
        [ForeignKey("Parent")]
        public string ComplainerId { get; set; }
        public Parents Parent { get; set; }
        //--------------------------------------------

        [Required]
        public Boolean Anonymous { get; set; } = false;
        [Required]
        public DateTime ComplainDate { get; set; }
        [Required]
        public bool Status { get; set; } = false;


        // 1 to 1 mapping wth action
        public ActionDetails ActionDetail { get; set; }

    }
}
