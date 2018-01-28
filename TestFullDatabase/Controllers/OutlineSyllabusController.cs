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
    public class OutlineSyllabusController : Controller
    {
        private readonly SchoolContext _context;

        public OutlineSyllabusController(SchoolContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IEnumerable<SyllabusOutlineWithTernary> GetAll()
        {
            return _context.SyllabusOutlineWithTernary;
        }

        //Getting all the tuples of a teacher in Ternary
        [Route("GetTernaryItemByTchrId/{tchrId}")]
        [HttpGet("{tchrId}")]
        public IQueryable GetItemsByID(string tchrId)
        {

            return _context.Ternary.Where(t => t.TeacherId == tchrId).Select(t => new { t.SubjectId, t.Subject.SubjectName, t.ClassRoomId, t.GetClassRoom.ClassRoomName, t.Id });

        }

        //get all the outline by ternary id;
        [Route("GetAvailableOutline/{TernaryId}")]
        [HttpGet("{TernaryId}")]
        public IQueryable GetItemsByTernaryID(int TernaryId)
        {

            return _context.SyllabusOutlineWithTernary.Where(t => t.IdTernary == TernaryId);

        }

        //get subject & outline by student Id
        [Route("GetSubjectAndOutlineByStudentId/{id}")]
        [HttpGet("{id}")]
        public IActionResult GetSubjectAndOutlineByStudentId(string id)
        {
            int clsId = _context.Students.FirstOrDefault(t => t.UserId == id).ClassRoomId;

            var subjects = _context.ClassWithSubjects.Where(t => t.ClassRoomId == clsId).Select(t=>new {t.SubjectId,t.Subject.SubjectName });

            List<GiveSyllabus> syllabusList = new List<GiveSyllabus>();

            foreach (var T in subjects)
            {
                string subjectName = T.SubjectName;

                IQueryable<SyllabusOutlineWithTernary> outlines = _context.SyllabusOutlineWithTernary.Where(t => t.Ternary.SubjectId == T.SubjectId);

                GiveSyllabus newItem = new GiveSyllabus//model class
                {
                    SubjectName=subjectName,
                    Syllabus=outlines
                };
                syllabusList.Add(newItem);

            }

            return Json(syllabusList);
            
        }

        //get subject & outline by parentId
        [Route("GetSubjectAndOutlineByParentId/{id}")]
        [HttpGet("{id}")]
        public IActionResult GetSubjectAndOutlineByParentId(string id)
        {
            string stdId = _context.Students.FirstOrDefault(t => t.Parent.UserId == id).UserId;

            int clsId = _context.Students.FirstOrDefault(t => t.UserId == stdId).ClassRoomId;

            var subjects = _context.ClassWithSubjects.Where(t => t.ClassRoomId == clsId).Select(t => new { t.SubjectId, t.Subject.SubjectName });

            List<GiveSyllabus> syllabusList = new List<GiveSyllabus>();

            foreach (var T in subjects)
            {
                string subjectName = T.SubjectName;

                IQueryable<SyllabusOutlineWithTernary> outlines = _context.SyllabusOutlineWithTernary.Where(t => t.Ternary.SubjectId == T.SubjectId);

                GiveSyllabus newItem = new GiveSyllabus
                {
                    SubjectName = subjectName,
                    Syllabus = outlines
                };
                syllabusList.Add(newItem);

            }

            return Json(syllabusList);

        }




        //Add to  the Outline 
        [Route("AddToOutlineSubject")]
        [HttpPost]

        public IActionResult FillOutlineSubject([FromBody]SyllabusOutlineWithTernary item)
        {

            if (item == null)
            {
                return BadRequest();
            }
            else
            {
                _context.SyllabusOutlineWithTernary.Add(item);
                _context.SaveChanges();
                return Ok("Successful");
            }
        }

        //Add to  the Outline by Array of outline 
        [Route("AddToOutlineSubjectByArray")]
        [HttpPost]

        public IActionResult FillOutlineByArray([FromBody] AddSyllabus item)
        {

            if (item == null)
            {
                return BadRequest();
            }

            else
            {
                bool count = false;//check all null
                foreach (var T in item.Outline)
                {
                    if (T == null)
                    {
                        continue;
                    }
                    else
                    {
                        count = true;
                        SyllabusOutlineWithTernary newItem = new SyllabusOutlineWithTernary
                        {
                            IdTernary = item.IdTernary,
                            DoneOrNot = false,
                            Outline = T
                        };

                        _context.SyllabusOutlineWithTernary.Add(newItem);
                        _context.SaveChanges();
                    }
                }

                if (count == true)
                    return Ok("Successful");
                else
                    return BadRequest("All Null");
            }
        }

        //update outline-do or not
        [Route("UpdateAOutline")]
        [HttpPost]
        public IActionResult UpdateAOutline([FromBody]SyllabusOutlineWithTernary Details)
        {
            SyllabusOutlineWithTernary OutlineDetails = _context.SyllabusOutlineWithTernary.FirstOrDefault(t => t.Id == Details.Id);

            if (OutlineDetails == null)
            {

                return BadRequest("null");
            }
            else
            {             
                OutlineDetails.DoneOrNot = Details.DoneOrNot;
                _context.SyllabusOutlineWithTernary.Update(OutlineDetails);
                _context.SaveChanges();

                return Json("Successful");
            }
        }

        //Delete a outline
        [Route("DeleteAOutline/{id}")]
        [HttpGet("{id}")]
        public IActionResult DeleteAOutline(int id)
        {
            SyllabusOutlineWithTernary OutlineSy = _context.SyllabusOutlineWithTernary.FirstOrDefault(t => t.Id == id);
            if (OutlineSy == null)
            {
                return NotFound();
            }
            else
            {
                _context.SyllabusOutlineWithTernary.Remove(OutlineSy);
                _context.SaveChanges();
                return Ok();
            }
        }

        //All Syllabus by student ID
        //podda
        [Route("GetSyllabusesByStudent/{subName}/{clsName}")]
        [HttpGet("{subName}/{clsName}")]
        public IQueryable GetAllSyllabuses(string subName, string clsName)
        {
            return _context.SyllabusOutlineWithTernary.Where(t => t.Ternary.GetClassRoom.ClassRoomName == clsName && t.Ternary.Subject.SubjectName == subName);
        }

        //All Syllabus by Parent
        //podda
        [Route("GetSyllabusesByParent/{parentId}/{subName}")]
        [HttpGet("{parentId}/{subName}")]
        public IQueryable GetAllSyllabusesToParent(string parentId, string subName)
        {
            int subId = _context.Subject.FirstOrDefault(t => t.SubjectName == subName).SubjectId;

            string stdId = _context.Students.FirstOrDefault(t => t.Parent.UserId == parentId).UserId;

            int clsId = _context.Students.FirstOrDefault(t => t.UserId == stdId).ClassRoomId;

            return _context.SyllabusOutlineWithTernary.Where(t => t.Ternary.ClassRoomId == clsId && t.Ternary.SubjectId==subId);      
        }
    }
}
