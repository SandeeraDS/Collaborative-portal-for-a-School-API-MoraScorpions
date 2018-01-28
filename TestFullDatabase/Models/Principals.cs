using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class Principals
    {

        [Key]
        [Required]
        [StringLength(450)]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public AspNetUsers User { get; set; }


        [Required]
        public string PrincipalGrade { get; set; }

        //with action details 1 to many connection
      //  public List<ActionDetails> Actions { get; set; }

        // 1 to many with principalQualification
        //public List<PrincipalQualifications> Qualification { get; set; }
    }
}
