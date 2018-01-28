using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class ClassRoom
    {
        [Key]
        public int ClassRoomId { get; set; }
        [Required]
        public string ClassRoomName { get; set; }

        public List<Students> Students { get; set; }
        public List<Teachers> Teacher { get; set; }
  

        //with ClasswithSubjects

        public List<ClassWithSubjects> SubjectOfClass{ get; set; }

       

        // 1 to many with Ternary
        public List<Ternary> TernaryClass { get; set; }

    }
}
