using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class AspNetUserRoles
    {
        [Key]
        [Required]
        [StringLength(450)]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public AspNetUsers User{ get; set; }


        [Key]
        [Required]
        [StringLength(450)]
        [ForeignKey("Role")]
        public string RoleId { get; set; }
        public AspNetRoles Role { get; set; }


    }
}
