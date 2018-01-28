using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class Ternary
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }


        [Required]
        [ForeignKey("GetClassRoom")]
        public int ClassRoomId { get; set; }
        public ClassRoom GetClassRoom { get; set; }

        
        [Required]
        [ForeignKey("Teacher")]
        public string TeacherId { get; set; }
        public Teachers Teacher { get; set; }

        //map with Syllabus outline Ternary
        public List<SyllabusOutlineWithTernary> SyllabusTernary { get; set; }

        //1 to many mapping
         public List<MarksDetails> MarksDetails { get; set; }

        // 1 to mant with note details
        public List<NoteDetails> Notes { get; set; }

    }
}
