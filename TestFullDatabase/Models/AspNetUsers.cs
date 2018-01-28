using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class AspNetUsers
    {
        [Key]
        [Required]
        [StringLength(450)]
        public string Id { get; set; }
        [Required]
        public int AccessFailedCount { get; set; } = 0;

        public string ConcurrencyStamp { get; set; }
        [Required]
        [StringLength(256)]
        public string Email { get; set; }
        [Required]
        public bool EmailConfirmed { get; set; } = false;
        [Required]
        public bool LockoutEnabled { get; set; } = true;


        public string LockoutEnd { get; set; } = null;
        public string NormalizedEmail { get; set; }
        public string NormalizedUserName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; } = false;
        public string SecurityStamp { get; set; }
        [Required]
        public bool TwoFactorEnabled { get; set; } = false;

        [Required]
        public string Password { get; set; }

       // [Required]
        [StringLength(256)]
        public string UserName { get; set; }
        
        public string Image { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public List<AspNetUserRoles> UserRoles { get; set; }

        public List<Students> Students { get; set; }
        public List<Teachers> Teachers { get; set; }
        public List<Parents> Parents { get; set; }
        public List<Principals> Principals { get; set; }

        public List<ComplainDetails> Complains { get; set; }

        
        [Required]
       // [StringLength(450)]
        [ForeignKey("Role")]
        public string RoleId { get; set; }
        public AspNetRoles Role { get; set; }

        // 1 to mant with note comments
        public List<NoteCommentDetails> Comments { get; set; }
      



    }
}
