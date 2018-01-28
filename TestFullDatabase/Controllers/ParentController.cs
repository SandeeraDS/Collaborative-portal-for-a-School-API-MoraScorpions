using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFullDatabase.Models;

namespace TestFullDatabase.Controllers
{
    [Route("Api/[Controller]")]
    public class ParentController : Controller
    {

        public SchoolContext _context;

        public ParentController(SchoolContext context)
        {
            _context = context;
        }

        //get All the Parent
        [HttpGet]
        public IQueryable GetParents()
        {
            return _context.Parents.Select(t=>new { t.UserId, t.User.Name, t.User.Email, t.User.Image,t.User.PhoneNumber, RoleId=t.User.Role.Id, RoleName = t.User.Role.Name ,StudentName=t.Student.User.Name, StudentId = t.StudentId });
        }

        //add Parent
        [HttpPost]
        public IActionResult AddParent([FromBody] Parents item)
        {
            if (item == null)
            {
                return BadRequest("Unsuccessful");
            }
            else
            {
                _context.Parents.Add(item);
                _context.SaveChanges();
                return Ok("Successful");
            }
        }

        // get all the teachers of the student
        //come parentID
        [Route("GetTeachersOfAStudent/{id}")]
        [HttpGet("{id}", Name = "GetAlltheTeachers")]
        public IQueryable GetTeachers(string Id)
        {
            string StdId = _context.Parents.FirstOrDefault(u => u.UserId == Id).StudentId;
            int ClsId = _context.Students.FirstOrDefault(u => u.UserId == StdId).ClassRoomId;

            return _context.Ternary.Where(t => t.ClassRoomId == ClsId).Select(t => new { t.Teacher.UserId, t.Teacher.User.Name, t.Teacher.User.Image, t.SubjectId, t.Subject.SubjectName });
        }

        //Get By Id
        [Route("StudentDetailsGetByParent/{Id}")]
        [HttpGet("{id}")]
        public IActionResult GetDetailsById(string id)
        {
            string stdId = _context.Students.FirstOrDefault(t => t.Parent.UserId == id).UserId;

            var item = _context.Students.Where(t => t.UserId == stdId).Select(t => new { t.AdmissionDate, t.AdmissionNumber, t.StdClass.ClassRoomName });
            if (item == null)
            {
                return BadRequest("Empty");
            }
            return new ObjectResult(item);
        }
    }
}
