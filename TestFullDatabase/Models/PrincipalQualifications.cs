using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class PrincipalQualifications
    {

        [Required]
        [Key]
        public string Qualification { get; set; }


        //1 to many 
        [Required]
        [ForeignKey("Principal")]
        public string PrincipalId { get; set; }
        public Principals Principal { get; set; }
    }
}
