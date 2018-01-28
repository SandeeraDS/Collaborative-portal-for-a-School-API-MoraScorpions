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
    public class ComplainController:Controller
    {

        SchoolContext _context;
        public DateTime Today;

        public ComplainController(SchoolContext context)
        {

            _context = context;
            Today = DateTime.Now.AddHours(5.50);//get time
        }

        //get All Complains
        [HttpGet]
        public IEnumerable<ComplainDetails> GetAll()
        {

            return _context.ComplainDetails;
        }

        //get TeacherId and principal Id by Parent Id
        [Route("GetByParentId/{id}")]
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {

            int clsId = _context.Students.FirstOrDefault(t => t.Parent.UserId == id).ClassRoomId;

            string tchrId = _context.Teachers.FirstOrDefault(t => t.ClassRoomId == clsId).UserId;
            string name = _context.AspNetUsers.FirstOrDefault(t => t.Id == tchrId).Name;
            string prncplId = _context.Principals.FirstOrDefault().UserId;
            string pName= _context.AspNetUsers.FirstOrDefault(t => t.Id == prncplId).Name;


            GetTeacherAndPrincipal newItem = new GetTeacherAndPrincipal
            {

                TeacherId = tchrId,
                TeacherName = name,
                PrincipalId = prncplId,
                PrincipalName = pName
            };

            return Json(newItem);
        }


        //add a complain
        [HttpPost]
        public IActionResult GetAComplaint([FromBody]ComplainDetails item)
        { 
            if(item == null)
            {
                return BadRequest();
            }
            else
            {
                ComplainDetails newItem = new ComplainDetails
                {
                    Content=item.Content,
                    Topic=item.Topic,
                    ComplaineeId=item.ComplaineeId,
                    ComplainerId=item.ComplainerId,
                    Anonymous=item.Anonymous,
                    ComplainDate=Today,
                    Status=false
                };

               _context.ComplainDetails.Add(newItem);
                _context.SaveChanges();


                //add to the Action Tables
             
                var lstId = _context.ComplainDetails.Last().ComplainId;

                
                ActionDetails newAdd = new ActionDetails
                {
                    Date = Today,
                    Satisfaction = false,
                    Action = null,
                    ActionTaken = false,
                    ComplainId = lstId


                };
                _context.ActionDetails.Add(newAdd);
                _context.SaveChanges();

                return Ok();
            }    
        }

        //get all the complain by a Parent
        [Route("GetAllComplainByComplainerId/{id}")]
        [HttpGet("{id}")]
        public IQueryable GetAllComplainByUser(string id)
        {
           
            return _context.ActionDetails.Where(t => t.Complain.ComplainerId == id).Select(t=>new {t.ActionId,t.Action,t.ActionTaken,ActionDate=t.Date,t.ComplainId,t.Complain.Topic,t.Complain.Content,t.Complain.ComplainDate,t.Complain.ComplaineeId,t.Complain.ComplainerId,t.Complain.Anonymous,t.Complain.Status ,ComplaineeName=t.Complain.Users.Name,t.Satisfaction});
        }

        //get All the complain by teacher & principal
        [Route("GetAllComplainByComplaineeId/{id}")]
        [HttpGet("{id}")]
        public IQueryable GetAllComplainByComplainee(string id)
        {
           
            return _context.ActionDetails.Where(t => t.Complain.ComplaineeId == id).Select(t => new { t.ActionId, t.Action, t.ActionTaken, ActionDate = t.Date, t.ComplainId, t.Complain.Topic, t.Complain.Content, t.Complain.ComplainDate, t.Complain.ComplaineeId, t.Complain.ComplainerId, t.Complain.Anonymous, t.Complain.Status, ComplainerName = t.Complain.Parent.User.Name,t.Satisfaction });
        }

        //update action by teacher or principal
        [Route("UpdateAction")]
        [HttpPost]

        public IActionResult UpdateAction([FromBody]ActionDetails item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            else
            {
                ActionDetails newItem = _context.ActionDetails.FirstOrDefault(t => t.ActionId == item.ActionId);

                newItem.Action = item.Action;
                newItem.ActionTaken = true;
                newItem.Date = Today;

                _context.ActionDetails.Update(newItem);
                _context.SaveChanges();

                return Ok();

            }
          
        }

        [Route("UpdateStatus/{cmplnId}")]
        [HttpGet("{cmplnId}")]
        public IActionResult UpdateStatus(int cmplnId)
        {

            if (_context.ComplainDetails.Where(t => t.ComplainId == cmplnId).Any())
            {

            }

            return Ok();
        }

        //set satisfaction by complain Id
        [Route("UpdateSatisfaction/{id}")]
        [HttpGet("{id}")]
        public IActionResult UpdateSatisfaction(int id)
        {
            ActionDetails item = _context.ActionDetails.FirstOrDefault(t=>t.ComplainId==id);

            if (item == null)
            {
                return BadRequest();
            }
            else
            {
                item.Satisfaction = true;
                _context.ActionDetails.Update(item);
                _context.SaveChanges();
                return Ok();
            }

            
        }


    }
}
