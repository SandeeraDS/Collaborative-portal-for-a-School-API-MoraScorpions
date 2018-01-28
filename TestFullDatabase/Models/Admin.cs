using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class Admin
    {
        [Key]
        [Required]
        [StringLength(450)]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public AspNetUsers User { get; set; }
    }
}
