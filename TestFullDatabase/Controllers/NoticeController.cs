using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFullDatabase.GetDataModels;
using TestFullDatabase.Models;

namespace TestFullDatabase.Controllers
{
    [Route("api/[Controller]")]
    public class NoticeController:Controller
    {
        SchoolContext _context;
        public DateTime Today;

        public NoticeController(SchoolContext context)
        {

            _context = context;
            Today = DateTime.Now.AddHours(5.50);
        }

        //get All Notices
        [HttpGet]
        public IList<NoticeEdit> GetAll()
        {

            List<NoticeEdit> newSet = new List<NoticeEdit>();

            var allNotices = _context.Notice;

            foreach(Notice item in allNotices)
            {
                bool expire=false;
                if (item.EndDate <= Today)
                {
                     expire = true; 
                }
                NoticeEdit newItem = new NoticeEdit
                {
                    NoticeId = item.NoticeId,
                    Topic = item.Topic,
                    Content = item.Content,
                    UploadDate = Today,
                    LastUpdatedDate = Today,
                    EndDate = item.EndDate,
                    StudentView = item.StudentView,
                    ParentView = item.ParentView,
                    TeacherView = item.TeacherView,
                    Expire = expire //exipred notices

                };
                newSet.Add(newItem);

            }

            return newSet;
        }

        //get notice by notice id
        [Route("GetById/{id}")]
        [HttpGet("{id}")]
        public NoticeEdit GetById(int id)
        {
            Notice item =  _context.Notice.FirstOrDefault(t => t.NoticeId == id);

            bool expire = false;
            if (item.EndDate <= Today)
            {
                expire = true;
            }
            NoticeEdit newItem = new NoticeEdit
            {
                NoticeId = item.NoticeId,
                Topic = item.Topic,
                Content = item.Content,
                UploadDate = Today,
                LastUpdatedDate = Today,
                EndDate = item.EndDate,
                StudentView = item.StudentView,
                ParentView = item.ParentView,
                TeacherView = item.TeacherView,
                Expire = expire

            };

            return newItem;
        }

        //add notice or update notice
        [HttpPost]
        public IActionResult AddNotice([FromBody]Notice item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            else
            {   //add notice
                if (item.NoticeId == 0)
                {

                    if (item.EndDate < Today)
                    {
                        return BadRequest();
                    }

                    Notice newItem = new Notice
                    {


                        Topic = item.Topic,
                        Content = item.Content,
                        UploadDate=Today,
                        LastUpdatedDate = Today,
                        EndDate = item.EndDate,
                        StudentView = item.StudentView,
                        ParentView = item.ParentView,
                        TeacherView = item.TeacherView

                    };

                    _context.Notice.Add(newItem);
                    _context.SaveChanges();
                }
                // update notice
                else
                {

                    if (item.EndDate < Today)
                    {
                        return BadRequest();
                    }
                    Notice details = _context.Notice.FirstOrDefault(t => t.NoticeId == item.NoticeId);

                    details.Topic = item.Topic;
                    details.Content = item.Content;
                    details.LastUpdatedDate = Today;
                    details.EndDate = item.EndDate;
                    details.StudentView = item.StudentView;
                    details.ParentView = item.ParentView;
                    details.TeacherView = item.TeacherView;

                    _context.Notice.Update(details);
                    _context.SaveChanges();

                }

                return Ok();
            }
        }

        //reading notices by user id
        [Route("NoticesGetById/{id}")]
        [HttpGet("{id}")]
        public IActionResult NoticesGetById(string id)
        {
            if (_context.Teachers.Where(t => t.UserId == id).Any())
            {

                if(_context.Notice.Where(t=>t.TeacherView==true && t.EndDate >= Today).Any())
                {
                    return Json(_context.Notice.Where(t=>t.TeacherView==true && t.EndDate>=Today).OrderByDescending(t=>t.LastUpdatedDate));
                }               
            }
            else if (_context.Parents.Where(t => t.UserId == id).Any())
            {
                if (_context.Notice.Where(t => t.ParentView == true && t.EndDate >= Today).Any())
                {
                    return Json(_context.Notice.Where(t => t.ParentView == true && t.EndDate >= Today).OrderBy(t => t.LastUpdatedDate));
                }
                
            }
            else if (_context.Students.Where(t => t.UserId == id).Any())
            {
                if (_context.Notice.Where(t => t.StudentView == true && t.EndDate >= Today).Any())
                {
                    return Json(_context.Notice.Where(t => t.StudentView == true && t.EndDate >= Today).OrderBy(t => t.LastUpdatedDate));
                }
               
            }

            
            return Json(_context.Principals.Where(t=>t.UserId==id));
        }


        //Delete a Notice- by principal by notice id
        [Route("DeleteANotice/{id}")]
        [HttpGet("{id}")]
        public IActionResult DeleteANotice(int id)
        {
            Notice oneNotice = _context.Notice.FirstOrDefault(t => t.NoticeId == id);
            if (oneNotice == null)
            {
                return NotFound();
            }
            else
            {
                _context.Notice.Remove(oneNotice);
                _context.SaveChanges();
                return Ok();
            }
        }


    }
}
