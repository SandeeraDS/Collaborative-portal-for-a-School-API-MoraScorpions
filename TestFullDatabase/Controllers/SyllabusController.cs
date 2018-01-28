using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFullDatabase.Controllers
{

    [Route("Api/[Controller]")]
    public class SyllabusController:Controller
    {

        private SchoolContext _context;

        public SyllabusController(SchoolContext context)
        {
            _context = context;
        }

        //geting all the subject of a teacher
        [Route("GetTeacherSubjects/{id}")]
        [HttpGet("{id}", Name = "GetTeacherSubjects")]
        public IActionResult SubjectsGetByTchrId(string id)
        {


            var Subjects = _context.SujectTeacher.Where(t => t.TeacherId == id).Select(t => t.Subject.SubjectName);

            if (Subjects == null)
            {
                return BadRequest();
            }
            return new ObjectResult(Subjects);
        }








    }
}
