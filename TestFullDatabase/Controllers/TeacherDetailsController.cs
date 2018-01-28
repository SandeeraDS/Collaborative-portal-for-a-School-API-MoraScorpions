using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFullDatabase.GetDataModels;
using TestFullDatabase.Models;

namespace TestFullDatabase.Controllers
{
    [Route("Api/[Controller]")]

    public class TeacherDetailsController : Controller
    {

        public SchoolContext _context;
        public TeacherDetailsController(SchoolContext context)
        {

            _context = context;

        }

        //Get All the Teachers
        [HttpGet]
        public IQueryable GetPersons()
        {

            return _context.Teachers.Select(t=>new{ t.UserId,t.User.Name,t.User.Email,t.User.Image,t.ClassRoomId,t.User.PhoneNumber,t.User.RoleId,RoleName=t.User.Role.Name,t.User.Password});
        }

        //get teacher by id
        [Route("GetTeacherById/{id}")]
        [HttpGet("{id}")]
        public IQueryable GetPersons(string id)
        {

            return _context.Teachers.Where(t=>t.UserId==id).Select(t => new { t.UserId, t.User.Name, t.User.Email, t.User.Image, t.ClassRoomId, t.User.PhoneNumber, t.User.RoleId, RoleName = t.User.Role.Name });
        }

        //get teacher by id
        [Route("GetTeacherDetailsById/{id}")]
        [HttpGet("{id}")]
        public IQueryable GetTeacher(string id)
        {

            return _context.Ternary.Where(t => t.TeacherId == id).Select(t => new { t.Subject.SubjectName,t.GetClassRoom.ClassRoomName,ownsClass=t.Teacher.TchrClass.ClassRoomName});
        }

        //add Teacher
        [HttpPost]
        public IActionResult Create([FromBody] Teachers item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            //else if (_context.Teacher.Where(t => t.User.Email == item.Email).Any())
            //{
            //    return BadRequest("Already Have");
            //}

            //else if (item.ClassRoomId == 3)//No Class State
            //{

            //    _context.Teacher.Add(item);
            //    _context.SaveChanges();
            //    return Ok("Succcessful");
            //}

            //else if (_context.Teacher.Where(t => t.ClassRoomId == item.ClassRoomId).Any())
            //{
            //    return BadRequest("This Class has already assigned");
            //}

            else
            {
                _context.Teachers.Add(item);
                _context.SaveChanges();
                return Ok("Succcessful");
            }
        }

        //Get teaching classes and subjects of a teacher
        //by Teacher Id
        //podda
        [Route("SubjectClassesOfTeacher/{id}")]
        [HttpGet("{id}")]
        public IActionResult GetTeachersClasses(string id)
        {
            var ClsIds = _context.Ternary.Where(t => t.TeacherId == id).Select(t => new { t.Id, t.ClassRoomId, t.GetClassRoom.ClassRoomName, t.SubjectId, t.Subject.SubjectName });

            return Json(ClsIds);
        }

        //get teachers Classes only
        //podda
        [Route("ClassesOfTeacher/{id}")]
        [HttpGet("{id}")]
        public IQueryable TeachersClasses(string id)
        {
            return _context.Ternary.Where(t => t.TeacherId == id).Select(t => new { t.GetClassRoom.ClassRoomName });
        }

        //Get all parents of a class
        //podda
        [Route("GetAllParentOfAClass/{clsName}")]
        [HttpGet("{clsName}")]

        public IQueryable GetParentsOfAClass(string clsName)
        {

            int clsId = _context.ClassRoom.FirstOrDefault(t => t.ClassRoomName == clsName).ClassRoomId;
           
            return _context.Parents.Where(t => t.Student.ClassRoomId == clsId).Select(t => new { t.UserId, t.User.Name, t.Student.User.Image,StudentName=t.Student.User.Name,StudentId=t.Student.UserId });
        }

    }
}
