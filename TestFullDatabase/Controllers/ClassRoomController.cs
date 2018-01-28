using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFullDatabase.Models;

namespace TestFullDatabase.Controllers
{
    [Route("Api/[Controller]")]

    public class ClassRoomController : Controller
    {
        private SchoolContext _context;

        public ClassRoomController(SchoolContext context)
        {
            _context = context;
        }


        //Get All classes
        [HttpGet]
        public IEnumerable<ClassRoom> GetAll()
        {
            return _context.ClassRoom;
        }


        //Get By Id
        [HttpGet("{id}", Name = "GetClassRoom")]
        public IActionResult GetById(long id)
        {
            var item = _context.ClassRoom.FirstOrDefault(t => t.ClassRoomId == id);
            if (item == null)
            {
                 return BadRequest(); // should come error report
            }
            return new ObjectResult(item);
        }

        //create a classRoom
        [HttpPost]
        public IActionResult Create([FromBody]ClassRoom item)
        {
            if (item == null)
            {
                return BadRequest("Empty");
            }
            else if (_context.ClassRoom.Where(t => t.ClassRoomName == item.ClassRoomName).Any())
            {

                return BadRequest("Already Have");
            }
            else
            {
                _context.ClassRoom.Add(item);
                _context.SaveChanges();
                return Ok("Successful");
            }
        }



        //update a class Room
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] ClassRoom item)
        {
            if (item == null || item.ClassRoomId != id)
            {
                //return BadRequest();
            }
            var classDetail = _context.ClassRoom.FirstOrDefault(t => t.ClassRoomId == id);
            if (classDetail == null)
            {
                // return NotFound();
            }

            classDetail.ClassRoomName = item.ClassRoomName;
            _context.ClassRoom.Update(classDetail);
            _context.SaveChanges();
            return new NoContentResult();
        }

        //delete by Id
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var classDetail = _context.ClassRoom.FirstOrDefault(t => t.ClassRoomId == id);
            if (classDetail == null)
            {
                // return NotFound();
            }
            _context.ClassRoom.Remove(classDetail);
            _context.SaveChanges();
            return new NoContentResult();
        }


        //get Parents By ClassName
        [HttpGet("{CName}", Name = "GetClassRoomParents")]
        public IQueryable GetAllParentsOfClass(string CName)
        {

            return _context.Students.Where(u => u.StdClass.ClassRoomName == CName).Select((u => new { u.Parent.UserId, u.Parent.User.Name, }));

        }
    }
}
