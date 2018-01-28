using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFullDatabase.Models;
using TestFullDatabase.GetDataModels;

namespace TestFullDatabase.Controllers
{
    [Route("Api/[Controller]")]
    public class SubjectController : Controller
    {


        public SchoolContext _context;

        public SubjectController(SchoolContext context)
        {
            _context = context;
        }



        //add subject
        [HttpGet]
        public IEnumerable<Subject> GetAllsubject()
        {
            return _context.Subject;
        }

        //get subject details by subjectId
        [Route("GetSubjectByID/{id}")]
        [HttpGet("{id}")]
        public IEnumerable<Subject> GetAllsubject(int id)
        {
            return _context.Subject.Where(t=>t.SubjectId==id);
        }

        //add a subject
        [HttpPost]
        public IActionResult AddASubject([FromBody]Subject item)
        {
            if (item == null)
            {
                return BadRequest("Error");
            }
            else if (_context.Subject.Where(t => t.SubjectCode == item.SubjectCode).Any())
            {
                return BadRequest("Already Have");
            }
            else if (_context.Subject.Where(t => t.SubjectName == item.SubjectName).Any())
            {
                return BadRequest("Already Have");
            }
            else
            {
                _context.Subject.Add(item);
                _context.SaveChanges();

                return Ok("Successful");
            }

        }

        //Class With Subjects
        [Route("AddClassWithSubjects")]
        [HttpPost]

        public IActionResult AddClassWithSubject([FromBody]ClassWithSubject item)
        {

            if (item == null)
            {
                return BadRequest("Error");
            }
            else
            {
                foreach (var T in item.SubjectId)
                {
                    if(_context.ClassWithSubjects.Where(t=>t.SubjectId==T && t.ClassRoomId == item.ClassRoomId).Any())
                    {
                        return BadRequest("Already Assighned");
                    }
                }

                foreach (var T in item.SubjectId)
                {
                    ClassWithSubjects NewItem = new ClassWithSubjects
                    {

                        ClassRoomId = item.ClassRoomId,
                        SubjectId = T
                    };
                    _context.ClassWithSubjects.Add(NewItem);
                    _context.SaveChanges();


                }
                return Ok("successfull");
            }
        }

    


        [Route("GetAllClassesOfSubject/{subId}")]
        [HttpGet("{subId}")]
        public IQueryable GetClasses(int subId)
        {
            return _context.ClassWithSubjects.Where(t => t.SubjectId == subId).Select(u => new { u.ClassRoomId, u.GetClassRoom.ClassRoomName });
        }

        //get all subject of a student by studentid or parentid
        [Route("GetAllSubjectOfAStudent/{id}")]
        [HttpGet("{id}")]
        public IQueryable GetSubjectsOfAStudent(string id)
        {

            int clsId = 0;
            if (_context.Parents.Where(t => t.UserId == id).Any())
            {
                 clsId = _context.Students.FirstOrDefault(t => t.Parent.UserId == id).ClassRoomId;

                return _context.ClassWithSubjects.Where(t => t.ClassRoomId == clsId).Select(t => new { t.SubjectId, t.Subject.SubjectName });
            }

            else
            {
                clsId = _context.Students.FirstOrDefault(t => t.UserId == id).ClassRoomId;

                return _context.ClassWithSubjects.Where(t => t.ClassRoomId == clsId).Select(t => new { t.SubjectId, t.Subject.SubjectName });

            }
        }

    }
}
