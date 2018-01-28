using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFullDatabase.Models;

namespace TestFullDatabase.Controllers
{
    [Route("Api/[Controller]")]
    public class AchievementController : Controller
    {
        SchoolContext _context;

        public AchievementController(SchoolContext context)
        {

            _context = context;
        }

        //get All Achievements
        [HttpGet]
        public IEnumerable<AchievementDetails> GetAll()
        {

            return _context.AchievementDetails;
        }

        
        //Add Achievements
        [HttpPost]
        public IActionResult AddAchievement([FromBody]AchievementDetails item)
        {

            if (item == null)
            {

                return BadRequest("Unsuccesfull");
            }
            else
            {

                AchievementDetails newItem = new AchievementDetails
                {
                    Details=item.Details,
                    Date=item.Date,
                    StudentId=item.StudentId
                };

                _context.AchievementDetails.Add(newItem);
                _context.SaveChanges();

                return Ok("Successfull");
            }

        }

        //get achivements by Studet-by student id
        [Route("GetByStudentID/{id}")]
        [HttpGet("{id}")]
        public IQueryable GetByStudent(string id)
        {

            return _context.AchievementDetails.Where(t => t.StudentId == id).Select(t => new { t.AchievementID, t.Date, t.Details, t.Student.User.Name,t.Student.UserId});

        }

        //get achievements by parent-by parent id
        [Route("GetByParentID/{id}")]
        [HttpGet("{id}")]
        public IQueryable GetByParent(string id)
        {

            string stdId = _context.Parents.FirstOrDefault(t => t.UserId == id).StudentId;

            return _context.AchievementDetails.Where(t => t.StudentId == stdId).Select(t => new { t.AchievementID, t.Date, t.Details, t.Student.User.Name, t.Student.Parent.UserId});

        }

        //get all the student of teacher own class-by teacher Id
        [Route("GetStudentsOfAClass/{id}")]
        [HttpGet("{id}")]
        public IQueryable GetStudentsOfAClass(string id)
        {

            int clsId = _context.Teachers.FirstOrDefault(t => t.UserId == id).ClassRoomId;

            return _context.Students.Where(t => t.ClassRoomId == clsId).Select(t => new { t.UserId, t.User.Name });

        }

        //get all student who has achievemt-by teacher id - own class
        [Route("GetStudentHaveAchievements/{id}")]
        [HttpGet("{id}")]
        public IQueryable GetAchievementStudents(string id)
        {
            int clsId = _context.Teachers.FirstOrDefault(t => t.UserId == id).ClassRoomId;

            return _context.AchievementDetails.Where(t => t.Student.ClassRoomId == clsId).Select(t=>new { t.AchievementID,t.Date,t.Details,t.StudentId,t.Student.User.Name,t.Student.StdClass.ClassRoomName});
        }


    }
}
