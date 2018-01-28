using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFullDatabase.GetDataModels;
using TestFullDatabase.Models;

namespace TestFullDatabase.Controllers
{

    [Route("Api/[Controller]")]
    public class MarksController : Controller
    {

        private readonly SchoolContext _context;

        public MarksController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<MarksDetails> GetAllMarks()
        {

            return _context.MarkDetails;
        }

        //all ternary items for a teacher id
        [Route("GetAllTernaryItemsById/{id}")]
        [HttpGet("{id}")]
        public IQueryable GetAllItems(string id)
        {

            return _context.Ternary.Where(t => t.TeacherId == id).Select(t => new { t.Id, t.SubjectId, t.Subject.SubjectName, t.ClassRoomId, t.GetClassRoom.ClassRoomName });
        }

        //get student list by ternary id - if there marks ,send marks, or give list for marking
        [Route("GetStudentList/{tId}/{term}")]
        [HttpGet("{tId}/{term}")]
        public IActionResult GetAllStudent(int tId, string term)
        {
            //if marked
            if (_context.MarkDetails.Where(t => t.Term == term && t.TernaryId == tId).Any())
            {
                var x = _context.MarkDetails.Where(t => t.Term == term && t.TernaryId == tId).Select(t => new { t.MarksID, t.StudentID, StudentName = t.Student.User.Name, t.Marks, t.Term, t.TernaryId });

                return Json(x);
            }
            //if not marked
            else
            {

                int clsId = _context.Ternary.FirstOrDefault(t => t.Id == tId).ClassRoomId;

                var stdDtls = _context.Students.Where(t => t.ClassRoomId == clsId).Select(t => new { t.UserId, t.User.Name });

                List<GetMarks> AllMarks = new List<GetMarks>();

                foreach (var T in stdDtls)
                {
                    //ad to a model cast
                    GetMarks newItem = new GetMarks
                    {
                        TernaryId = tId,
                        StudentID = T.UserId,
                        StudentName = T.Name,
                        Marks = 0,
                        Term = null
                    };
                    AllMarks.Add(newItem);

                }
                return Json(AllMarks);
            }
        }

        //add marks
        [HttpPost]
        public IActionResult AddMarks([FromBody] IList<GetMarks> item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            else
            {
                foreach (GetMarks T in item)
                {
                    //updating marks
                    if (_context.MarkDetails.Where(t => t.Term == T.Term && t.StudentID == T.StudentID && t.TernaryId == T.TernaryId).Any())
                    {
                        MarksDetails details = _context.MarkDetails.FirstOrDefault(t => t.Term == T.Term && t.StudentID == T.StudentID && t.TernaryId == T.TernaryId);

                        details.Marks = T.Marks;

                        _context.MarkDetails.Update(details);
                        _context.SaveChanges();
                    }
                    //add new marks
                    else
                    {
                        MarksDetails newItem = new MarksDetails
                        {
                            TernaryId = T.TernaryId,
                            StudentID = T.StudentID,
                            Marks = T.Marks,
                            Term = T.Term
                        };

                        _context.MarkDetails.Add(newItem);
                        _context.SaveChanges();
                    }
                }
                return Ok();
            }
        }

        //get marks of all terms by parent id or student id
        [Route("GetByStudentterm/{id}")]
        [HttpGet("{id}")]
        public IActionResult GetByStudentTerm1(string id)
        {
            if (_context.Students.Where(t => t.UserId == id).Any())
            {
                var x = _context.MarkDetails.Where(t => t.StudentID == id).Select(t => new { t.MarksID, t.Term, t.Marks, t.Ternary.Subject.SubjectName });
                return Json(x);
            }
            else if (_context.Parents.Where(t => t.UserId == id).Any())
            {
                string stdId = _context.Students.FirstOrDefault(t => t.Parent.UserId == id).UserId;

                var x = _context.MarkDetails.Where(t => t.StudentID == stdId).Select(t => new { t.MarksID, t.Term, t.Marks, t.Ternary.Subject.SubjectName });

                return Json(x);
            }

            return BadRequest("empty"); ;
        }

    }
}
