using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class AspNetUserTokens
    {
        [Required]
        [Key]
        [StringLength(450)]
        public string UserId { get; set; }
        [Required]
        [Key]
        [StringLength(450)]
        public string LoginProvider { get; set; }
        [Required]
        [Key]
        [StringLength(450)]
        public string Name { get; set; }
        public string Value { get; set; } = null;

    }
}
