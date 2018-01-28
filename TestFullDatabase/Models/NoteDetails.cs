using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class NoteDetails
    {

        [Key]
        public int NoteId { get; set; }
        [Required]
        public string NoteUrl { get; set; }
        [Required]
        public string NoteTitle { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime UploadedDate { get; set; }
        [Required]
        public DateTime LastUpdatedDate { get; set; }
        [Required]
        public bool Visibility { get; set; }

      
        [Required]
        [ForeignKey("Ternary")]
        public int TernaryId { get; set; }
        public Ternary Ternary { get; set; }

        // 1 to many mapping with notecomments
        public List<NoteCommentDetails> Comments { get; set; }
    }
}
