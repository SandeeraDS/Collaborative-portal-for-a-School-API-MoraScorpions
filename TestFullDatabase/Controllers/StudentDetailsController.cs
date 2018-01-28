using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFullDatabase.Models;

namespace TestFullDatabase.Controllers
{
    //[Route("Api/StudentDetails")]
    public class StudentDetailsController : Controller
    {

        public SchoolContext _context;

        public StudentDetailsController(SchoolContext context)
        {

            _context = context;

        }

        //get all student
        [Route("Api/AllStudentDetails")]
        [HttpGet]
        public IQueryable GetStudents()
        {
             return _context.Students.Select(t=>new {t.UserId,t.User.Name,t.User.Email,t.User.Image,t.AdmissionNumber,t.AdmissionDate,t.StdClass.ClassRoomName,t.ClassRoomId,RoleName=t.User.Role.Name,RoleId=t.User.Role.Id });
        }

        [Route("Api/CheckAdmissionNumber/{adNum}")]
        [HttpGet("{adNum}")]
        public IActionResult CheckAdmissionNum(string adNum)
        {
            if (_context.Students.Where(t => t.AdmissionNumber == adNum).Any())
            {
                return BadRequest();

            }
            else
            {

                return Ok();
            }
           
        }



        //add  a student
        [Route("Api/AddStudentDetails")]
        [HttpPost]
        public IActionResult AddStudent([FromBody] Students item)
        {
            if (item == null)
            {
                return BadRequest("Empty");
            }
            else if (_context.Students.Where(t => t.AdmissionNumber == item.AdmissionNumber).Any())
            {

                return BadRequest("Already Have");
            }
            //else if (_context.Student.Where(t => t.Email == item.Email).Any())
            //{
            //    return BadRequest("Already Have Email");

            //}

            else
            {
                _context.Students.Add(item);
                _context.SaveChanges();

                return Ok("Successful");
            }
        }



        //Get By Id
        [Route("Api/StudentGetByID/{Id}")]
        [HttpGet("{id}", Name = "GetStudent")]
        public IActionResult GetById(string id)
        {
            var item = _context.Students.FirstOrDefault(t => t.UserId== id);
            if (item == null)
            {
                return BadRequest("Empty");
            }
            return new ObjectResult(item);
        }


        //Get By Id
        [Route("Api/StudentDetailsGetByID/{Id}")]
        [HttpGet("{id}")]
        public IActionResult GetDetailsById(string id)
        {
            var item = _context.Students.Where(t => t.UserId == id).Select(t=>new { t.AdmissionDate, t.AdmissionNumber,t.StdClass.ClassRoomName});
            if (item == null)
            {
                return BadRequest("Empty");
            }
            return new ObjectResult(item);
        }


        // get all the teachers of the student
        // come studentid
        [Route("Api/TeachersOfAStudent/{id}")]
       [HttpGet("{id}")]
        public IQueryable GetTeachersOfStudent(string id)
        {
            int clsId = _context.Students.FirstOrDefault(u => u.UserId == id).ClassRoomId;
            return _context.Ternary.Where(t => t.ClassRoomId == clsId).Select(t => new { t.Teacher.UserId, t.Teacher.User.Name, t.Teacher.User.Image, t.SubjectId, t.Subject.SubjectName });
        }


    }
}
