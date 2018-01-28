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
    public class NoteController : Controller
    {

        SchoolContext _context;
        public DateTime Today;

        public NoteController(SchoolContext context)
        {

            _context = context;
            Today = DateTime.Now.AddHours(5.50);
        }


        //get All notes
        [HttpGet]
        public IEnumerable<NoteDetails> GetAll()
        {
            return _context.NoteDetails;
        }

        //add or update a note
        [HttpPost]
        public IActionResult AddNote([FromBody]NoteDetails item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            else
            {
                if (item.NoteId == 0)
                {
                    NoteDetails newItem = new NoteDetails
                    {

                        NoteUrl = item.NoteUrl,
                        NoteTitle = item.NoteTitle,
                        Description = item.Description,
                        UploadedDate = Today,
                        LastUpdatedDate = Today,
                        Visibility = item.Visibility,
                        TernaryId = item.TernaryId

                    };

                    _context.NoteDetails.Add(newItem);
                    _context.SaveChanges();

                    return Ok();
                }
                else
                {
                    NoteDetails newItem = _context.NoteDetails.FirstOrDefault(t => t.NoteId == item.NoteId);

                    newItem.NoteTitle = item.NoteTitle;
                    newItem.NoteUrl = item.NoteUrl;
                    newItem.Description = item.Description;
                    newItem.LastUpdatedDate = Today;
                    newItem.Visibility = item.Visibility;

                    _context.NoteDetails.Update(newItem);
                    _context.SaveChanges();

                    return Ok();

                }



            }

        }
        //get notes by teacher id
        //achiya
        [Route("GetByTeacherId/{id}")]
        [HttpGet("{id}")]
        public IQueryable GetByTeacherId(string id)
        {

            return _context.NoteDetails.Where(t => t.Ternary.TeacherId == id).Select(t => new { t.NoteId, t.NoteTitle, t.NoteUrl, t.Description, t.Visibility, t.UploadedDate, t.LastUpdatedDate, t.Ternary.GetClassRoom.ClassRoomName, t.Ternary.Subject.SubjectName });
        }
         //get by ternary ida
         //podda
        [Route("GetByTernaryId/{id}")]
        [HttpGet("{id}")]
        public IQueryable GetByTernaryId(int id)
        {

            return _context.NoteDetails.Where(t => t.TernaryId== id).Select(t => new { t.NoteId, t.NoteTitle, t.NoteUrl, t.Description, t.Visibility, t.UploadedDate, t.LastUpdatedDate});
        }
        //get comments by note id
        //podda
        [Route("GetCommentsByNoteId/{id}")]
        [HttpGet("{id}")]
        public IActionResult GetCommentsByNoteId(int id)
        {

            return Json(_context.NoteCommentDetails.Where(t => t.NoteID == id).Select(t => new {t.CommentId,t.CommentedTime,t.Content,t.UserId,t.User.Name,t.User.Image}));
        }
        //get notes by subjectName className
        //podda
        [Route("GetNotesByStudentClassandSub/{cName}/{subName}")]
        [HttpGet("{cName}/{subName}")]
        public IActionResult GetNoteToStudent(string cName,string subName)
        {

            return Json(_context.NoteDetails.Where(t => t.Ternary.GetClassRoom.ClassRoomName == cName && t.Ternary.Subject.SubjectName==subName && t.Visibility==true).Select(t => new { t.NoteId,t.NoteTitle,t.NoteUrl,t.Description,t.LastUpdatedDate,t.UploadedDate}));
        }
        //get by note id
        [Route("GetAById/{id}")]
        [HttpGet("{id}")]
        public IActionResult GetByAId(int id)
        {

            return Json(_context.NoteDetails.Where(t=>t.NoteId==id).Select(t=> new{ t.NoteId,t.NoteTitle,t.NoteUrl,t.Description,t.UploadedDate,t.LastUpdatedDate,t.TernaryId,t.Ternary.GetClassRoom.ClassRoomName,t.Ternary.Subject.SubjectName}).FirstOrDefault());
        }


        // all comments of a note
        [Route("GetAllCommentsRepliesByNoteId/{id}")]
        [HttpPost("{id}")]
        public IActionResult GetAllById(int id)
        {

            var noteItem = _context.NoteDetails.Where(t => t.NoteId == id).Select(t=>new {t.NoteId,t.Visibility,t.NoteTitle,t.NoteUrl,t.LastUpdatedDate,t.UploadedDate,t.Description,t.TernaryId,t.Ternary.Subject.SubjectName,t.Ternary.Teacher.User.Name,t.Ternary.Teacher.User.Image });
            var comments = _context.NoteCommentDetails.Where(t => t.NoteID == id).Select(t=>new {t.CommentId,t.Content,t.CommentedTime,t.UserId,t.NoteID,t.User.Name,t.User.Image,});

            List<GetComment> commentList = new List<GetComment>();

            foreach (var T in comments)
            {

                GetComment oneComment = new GetComment
                {
                    CommentId = T.CommentId,
                    Content = T.Content,
                    CommentedTime = T.CommentedTime,
                    NoteID = T.NoteID,
                    UserId = T.UserId,
                    UserName=T.Name,
                    PicUrl=T.Image
                };
                commentList.Add(oneComment);
            }
           

            if (comments == null)
            {
                return NotFound();
            }
            else
            {
                foreach (var k in noteItem)
                {
                    GetANote newItem = new GetANote
                    {
                        NoteId = k.NoteId,
                        NoteUrl = k.NoteUrl,
                        NoteTitle = k.NoteTitle,
                        Description = k.Description,
                        UploadedDate = k.UploadedDate,
                        LastUpdatedDate = k.LastUpdatedDate,
                        Visibility = k.Visibility,
                        TernaryId = k.TernaryId,
                        TeacherImageUrl = k.Image,
                        TeacherName = k.Name,
                        SubjectName = k.SubjectName,
                        Comments = commentList,
                    };

                    return Json(newItem);

                }

               

                return BadRequest();    
            }
        }


        //Delete a Note
        [Route("DeleteANote/{id}")]
        [HttpGet("{id}")]
        public IActionResult DeleteANotice(int id)
        {
            NoteDetails oneNote = _context.NoteDetails.FirstOrDefault(t => t.NoteId == id);
            if (oneNote == null)
            {
                return NotFound();
            }
            else
            {
                _context.NoteDetails.Remove(oneNote);
                _context.SaveChanges();
                return Ok();
            }
        }

        //get Student's Note
        [Route("GetByStudentId/{id}")]
        [HttpPost("{id}")]
        public IQueryable GetByStudentId(string id)
        {
            int clsId = _context.Students.FirstOrDefault(t => t.UserId == id).ClassRoomId;

            return _context.NoteDetails.Where(t=>t.Ternary.ClassRoomId==clsId && t.Visibility==true).Select(t => new { t.NoteId, t.NoteTitle, t.NoteUrl, t.Description, t.UploadedDate, t.LastUpdatedDate, t.TernaryId, t.Ternary.GetClassRoom.ClassRoomName, t.Ternary.Subject.SubjectName });
        }


        //add a Comment
        [Route("AddAComment")]
        [HttpPost]
        public IActionResult AddAComment([FromBody]NoteCommentDetails item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            else
            {
                NoteCommentDetails newItem = new NoteCommentDetails
                {

                    
                    Content =item.Content,
                    CommentedTime = Today,
                    NoteID = item.NoteID,
                    UserId = item.UserId,
                    

                };
                _context.NoteCommentDetails.Add(newItem);
                _context.SaveChanges();
                return Ok();
            }
        }
        [Route("GetAllComments")]
        [HttpGet]
        public IEnumerable<NoteCommentDetails> GetAllComments()
        {
            return _context.NoteCommentDetails;
        }

       







    }
    
}
