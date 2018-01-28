using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class NoteCommentReply
    {
        [Key]
        public int ReplyId { get; set; }
        [Required]
        public string Content { get; set;}
        [Required]
        public DateTime RepliedTime { get; set; }
        [Required]
        [ForeignKey("Comments")]
        public int CommentId { get; set; }
        public NoteCommentDetails Comments{ get; set; }
        [Required]
        [ForeignKey("User")]
        public string ReplierId { get; set; }
        public AspNetUsers User { get; set; }
    }
}
