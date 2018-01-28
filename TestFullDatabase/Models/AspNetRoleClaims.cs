using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class AspNetRoleClaims
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        [Required]
        [ForeignKey("Role")]
        [StringLength(450)]
        public string RoleId { get; set; }
        public AspNetRoles Role { get; set; }
    }
}
