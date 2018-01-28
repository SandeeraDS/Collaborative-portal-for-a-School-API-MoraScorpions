using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class AspNetUserLogins
    {
        [Key]
        [Required]
        [StringLength(450)]
        public string LoginProvider { get; set; }
        [Key]
        [Required]
        [StringLength(450)]
        public string ProvideKey { get; set; }
        public string ProviderDisplayName { get; set; }
        [Required]
        [ForeignKey("User")]
        [StringLength(450)]
        public string UserId { get; set; }
        public AspNetUsers User { get; set; }
    }
}
