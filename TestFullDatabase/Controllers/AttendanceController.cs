using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFullDatabase.Models;

namespace TestFullDatabase.Controllers
{


    [Route("Api/AttendanceDetails")]
    public class AttendanceController : Controller
    {
        private readonly SchoolContext _context;

        public AttendanceController(SchoolContext context)
        {
            _context = context;
        }


        //Get All
        [HttpGet]
        public IEnumerable<AttendanceDetails> GetAll()
        {
            return _context.AttendanceDetails;
        }


        //add attendance list
        [HttpPost]
        public IActionResult Create([FromBody] IList<AttendanceDetails> item)
        {
            if (item == null)
            {
                return BadRequest("null");
            }
            else
            {


                foreach (AttendanceDetails T in item)
                {
                    //if allready have attendance it can be updated
                    if ((_context.AttendanceDetails.Where(u => u.Date == T.Date && u.P_Id == T.P_Id).Any()))
                    {
                        var atdDetails = _context.AttendanceDetails.FirstOrDefault(t => t.Date == T.Date && t.P_Id == T.P_Id);

                        atdDetails.Date = T.Date;
                        atdDetails.PresentAbsent = T.PresentAbsent;

                        _context.AttendanceDetails.Update(atdDetails);
                        _context.SaveChanges();

                    }
                    //add new attendance
                    else
                    {
                        _context.AttendanceDetails.Add(T);
                        _context.SaveChanges();
                    }
                }

                // System.Diagnostics.Debug.WriteLine(T.ClassRoomName);
                //  Console.WriteLine("Welcome to the C# Station Tutorial!");
                return Ok("Successful");

            }

        }



        // get attendace of a students in a particualar class and date
        [HttpGet("{date}/{CName}", Name = "GetAtdOfStd")]
        public IQueryable GetByDate(DateTime date, string CName)
        {
            int clssId = (_context.ClassRoom.FirstOrDefault(u => u.ClassRoomName == CName).ClassRoomId);

            string stdId = _context.Students.FirstOrDefault(u => u.ClassRoomId == clssId).UserId;

            //not attendace send empty list of students
            if (!(GetAll().Where(t => t.Date == date && t.P_Id == stdId).Any()))
            {

                return _context.Students.Where(u => u.ClassRoomId == clssId).Select(u => new { P_Id=u.UserId, u.User.Name });
            }
            //send marked attendance
            else
            {
                return _context.AttendanceDetails.Where(u => u.Date == date && u.StdDetails.StdClass.ClassRoomName == CName).Select(u => new { u.P_Id, u.StdDetails.User.Name, u.PresentAbsent, u.Date });
            }


        }



        // get attendace of a students in a particualar class and date-by teacher_id
        //achiya
        [Route("AddAttendanceByDateAndTeacherId/{date}/{id}")]
        [HttpGet("{date}/{id}")]
        public IQueryable GetByDateAndThrId(DateTime date ,string id)
        {
            int clssId = _context.Teachers.FirstOrDefault(u => u.UserId == id).ClassRoomId;
            string stdId = _context.Students.FirstOrDefault(u => u.ClassRoomId == clssId).UserId;

            //if not marked send empty-list
            if (!(GetAll().Where(t => t.Date == date && t.P_Id == stdId).Any()))
            {

                return _context.Students.Where(u => u.ClassRoomId == clssId).Select(u => new { P_Id=u.UserId, u.User.Name });
            }
            //send marked attendace
            else
            {

                return _context.AttendanceDetails.Where(u => u.Date == date && u.StdDetails.StdClass.ClassRoomId == clssId).Select(u => new { u.P_Id, u.StdDetails.User.Name, u.PresentAbsent, u.Date });
            }



        }

        //get percentage of a student by student id 
        [Route("GetAttendancePercentageOfAStudent/{id}")]
        [HttpGet("{id}")]

        public string GetCount(string id)
        {

            var all = _context.AttendanceDetails.Where(t => t.StdDetails.UserId == id);

            float count = 0, max = 0;

            foreach (AttendanceDetails T in all)
            {

                if (T.PresentAbsent == true)
                {
                    count = count + 1;
                }

                max = max + 1;

            }

            float x = (count / max) * 100;

            return x.ToString("0.00");
        }

        //get absentdate of a student by student id 
        [Route("GetAbsentDatesOfAStudent/{id}")]
        [HttpGet("{id}")]

        public IQueryable AbDates(string id)
        {

             return _context.AttendanceDetails.Where(t => t.P_Id == id && t.PresentAbsent == false).Select(t => new { t.Date.Day, t.Date.Month,t.Date.Year });

           
        }

        //get absentdate of a student by Parentid 
        [Route("GetAbsentDatesToParent/{id}")]
        [HttpGet("{id}")]

        public IQueryable AbDatesToParent(string id)
        {
            string stdId = _context.Students.FirstOrDefault(t => t.Parent.UserId == id).UserId;

            return _context.AttendanceDetails.Where(t => t.P_Id == stdId && t.PresentAbsent == false).Select(t => new { t.Date.Day, t.Date.Month, t.Date.Year });

        }

        //get percentage of a student by Parent id
        [Route("GetAttendancePercentageOfAParentStd/{id}")]
        [HttpGet("{id}")]

        public string GetParentCount(string id)
        {

            string stdId = _context.Students.FirstOrDefault(t => t.Parent.UserId == id).UserId;

            var all = _context.AttendanceDetails.Where(t => t.StdDetails.UserId == stdId);

            float count = 0, max = 0;

            foreach (AttendanceDetails T in all)
            {

                if (T.PresentAbsent == true)
                {
                    count = count + 1;
                }

                max = max + 1;

            }

            float x = (count / max) * 100;



            return x.ToString("0.00");
        }


    }

}
