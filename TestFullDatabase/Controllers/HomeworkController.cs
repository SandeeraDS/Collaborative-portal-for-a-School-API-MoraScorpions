using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFullDatabase.Models;

namespace TestFullDatabase.Controllers
{

    [Route("Api/[Controller]")]
    public class HomeworkController : Controller
    {

        public SchoolContext _context;
        public DateTime Today;

        public HomeworkController(SchoolContext context)
        {

            _context = context;

            Today = DateTime.Now.AddHours(5.50);


        }

        //add a homework
        //achiya
        [Route("AddAHomeworkFile")]
        [HttpPost]
        public IActionResult Create([FromBody]HomeworkDetails item)
        {
            if (item == null)
            {
                return BadRequest("Error");
            }
            _context.HomeworkDetails.Add(item);
            _context.SaveChanges();

            return Ok("Successful");
        }



        //geting all the subject of a student
        [Route("GetStudentSubjects/{id}")]
        [HttpGet("{id}", Name = "GetStudentSubjects")]
        public IActionResult SubjectsGetByStdId(string id)
        {
            var clsId = _context.Students.FirstOrDefault(t => t.UserId == id).ClassRoomId;

            var subjects = _context.ClassWithSubjects.Where(t => t.ClassRoomId == clsId).Select(t => new { t.Subject.SubjectName, t.Subject.SubjectId, t.Subject.SubjectCode });

            if (subjects == null)
            {
                return BadRequest();
            }
            return new ObjectResult(subjects);
        }


        //geting all the claSSES of a teacher
        [Route("GetTeacherClass/{id}")]
        [HttpGet("{id}", Name = "GetTeacherClass")]
        public IActionResult SubjectsGetByTchrId(string id)
        {


            var classes = _context.Ternary.Where(t => t.TeacherId == id).Select(t => new { t.ClassRoomId, t.GetClassRoom.ClassRoomName });

            if (classes == null)
            {
                return BadRequest();
            }
            return new ObjectResult(classes);
        }

        //get classid and subjectid for a teacher id
        [Route("TeacherClassSubject/{id}")]
        [HttpGet("{id}", Name = "GetClassAndSubject")]
        public IActionResult GetTeachersClasses(string id)
        {
            var clsSub = _context.Ternary.Where(t => t.TeacherId == id).Select(t => new { t.Id, t.ClassRoomId, t.GetClassRoom.ClassRoomName, t.SubjectId, t.Subject.SubjectName });

            return Json(clsSub);
        }

        //get Student's Homework by student id
        //achiya , podda
        [Route("GetHomeworkOfAStudent/{id}")]
        [HttpGet("{id}")]
        public IQueryable GetHomeworkOfAStudent(string id)
        {

            int clsId = _context.Students.FirstOrDefault(t => t.UserId == id).ClassRoomId;

            return _context.HomeworkDetails.Where(t => t.Ternary.ClassRoomId == clsId).Select(t => new { t.HomeworkId, t.PDF, t.TernaryId, t.Topic, t.UploadedTime, t.Visibility, t.VisibilityEndDate, t.VisibilityStartDate, t.Content, t.Deadline, t.Ternary.GetClassRoom.ClassRoomName, t.Ternary.Subject.SubjectName });
        }

        //Get All Homework of A Teacher by teacher id
        //Achiya ,podda
        [Route("GetHomeworkOfATeacher/{id}")]
        [HttpGet("{id}")]
        public IQueryable GetHomeworkOfATeacher(string id)
        {
            return _context.HomeworkDetails.Where(t => t.Ternary.TeacherId == id && (t.Visibility == true || (t.VisibilityEndDate >= Today && t.VisibilityStartDate.Date <= Today))).Select(t => new { t.HomeworkId, t.PDF, t.TernaryId, t.Topic, t.UploadedTime, t.Visibility, t.VisibilityEndDate, t.VisibilityStartDate, t.Content, t.Deadline, t.Ternary.GetClassRoom.ClassRoomName, t.Ternary.Subject.SubjectName });
        }

        //Get All Homework of A Parent by parent id
        //Achiya , podda
        [Route("GetHomeworkOfAParent/{id}")]
        [HttpGet("{id}")]
        public IQueryable GetHomeworkOfAParent(string id)
        {

            int clsId = _context.Students.FirstOrDefault(t => t.Parent.UserId == id).ClassRoomId;

            return _context.HomeworkDetails.Where(t => t.Ternary.ClassRoomId == clsId && (t.Visibility == true || (t.VisibilityEndDate >= Today && t.VisibilityStartDate.Date <= Today))).Select(t => new { t.HomeworkId, t.PDF, t.TernaryId, t.Topic, t.UploadedTime, t.Visibility, t.VisibilityEndDate, t.VisibilityStartDate, t.Content, t.Deadline, t.Ternary.GetClassRoom.ClassRoomName, t.Ternary.Subject.SubjectName });
        }


        //Get All Homework using ternary-give me ternary_ID
        //Podda
        [Route("GetHomeworkMobileApp/{id}")]
        [HttpGet("{id}")]
        public IQueryable GetHomeworkMobileApp(int id)
        {
            return _context.HomeworkDetails.Where(t => t.TernaryId == id);
        }


        //check for give homework according to time //check method
        [Route("GetTime/{id}")]
        [HttpGet("{id}")]
        public IQueryable GetTime(string id)
        {
            int clsId = _context.Students.FirstOrDefault(t => t.UserId == id).ClassRoomId;


            return _context.HomeworkDetails.Where(t => t.Ternary.ClassRoomId == clsId && (t.Visibility == true || (t.VisibilityEndDate >= Today && t.VisibilityStartDate.Date <= Today)));
            // return Today;
        }


    }
}
