using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class ClassWithSubjects
    {

        [Required]
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }


        [Required]
        [ForeignKey("GetClassRoom")]
        public int ClassRoomId { get; set; }
        public ClassRoom GetClassRoom { get; set; }

    }
}
