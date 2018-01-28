using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class AttendanceDetails
    {

        [Key]
        public int AttendanceId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public Boolean PresentAbsent { get; set; }


        //student connection
        [Required]
        [ForeignKey("StdDetails")]
        public string P_Id { get; set; }
        public Students StdDetails { get; set; }
    }
}
