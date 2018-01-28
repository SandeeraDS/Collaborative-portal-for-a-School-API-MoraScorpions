using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Models
{
    public class SyllabusOutlineWithTernary
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Outline { get; set; }       
        public bool DoneOrNot { get; set; } = false;

        [Required]
        [ForeignKey("Ternary")]
        public int IdTernary { get; set; }
        public Ternary Ternary { get; set; }



    }
}
