using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class ActionDetails
    {

        [Key]
        public int ActionId { get; set; }
        
        public DateTime Date { get; set; } 
       
        public bool Satisfaction { get; set; } = false;
       
        public string Action { get; set; } = null;

        [Required]
        public bool ActionTaken { get; set; } = false;

       
        [Required]
        [ForeignKey("Complain")]
        public int ComplainId { get; set; }
        public ComplainDetails Complain { get; set; }


    }
}
