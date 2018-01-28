using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class AspNetRoles
    {
        [Key]
        [Required]
        [StringLength(450)]
        public string Id { get; set; }

       // [Required]
        
        public string ConcurrencyStamp { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        public List<AspNetUserRoles> UserRoles { get; set; }

        [StringLength(256)]
        public string NormalizedName { get; set; }
       // public IEnumerable<PersonDetails> RoleOfPersons { get; set; }

        public IList<AspNetUsers> UsrRoles { get; set; }
    }
}
