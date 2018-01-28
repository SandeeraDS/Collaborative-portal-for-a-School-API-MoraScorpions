using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFullDatabase.Models;

namespace TestFullDatabase.GetDataModels
{
    public class GiveSyllabus
    {
        public string SubjectName { get; set; }
        public IQueryable<SyllabusOutlineWithTernary> Syllabus { get; set; }
    }
}
