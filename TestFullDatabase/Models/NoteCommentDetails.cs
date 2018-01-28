using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class NoteCommentDetails
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime CommentedTime { get; set; }

        // 1 to many with noteDetails
        [Required]
        [ForeignKey("NoteDetails")]
        public int NoteID { get; set; }
        public NoteDetails NoteDetails { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public AspNetUsers User { get; set; }

   



    }
}
