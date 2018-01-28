using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFullDatabase.GetDataModels;
using TestFullDatabase.Models;

namespace TestFullDatabase.Controllers
{

    [Route("Api/[controller]")]
    public class TernaryOperationController : Controller
    {

        private readonly SchoolContext _context;

        public TernaryOperationController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Ternary> GetAll()
        {

            return _context.Ternary;
        }

        [HttpGet("{ClsId}")]

        public IQueryable GetbyClassId(int ClsId)
        {

            return _context.Ternary.Where(t => t.ClassRoomId == ClsId).Select(t => new { t.Teacher.User.Name });
        }


        [Route("AddTernary")]
        [HttpPost]
        public IActionResult AddClassWithTeacher([FromBody]TernaryFill item)
        {

            if (item == null)
            {
                return BadRequest("Error");
            }
            else
            {
                foreach (var T in item.ClassRoomId) {

                    if (_context.Ternary.Where(t => t.SubjectId == item.SubjectID && t.ClassRoomId == T).Any())
                    {
                        return BadRequest("The Subject Of the class is already assighned");
                    }
                  
                }
                foreach (var T in item.ClassRoomId)
                {
                    Ternary NewItem = new Ternary
                    {
                        ClassRoomId = T,
                        TeacherId = item.TeacherId,
                        SubjectId = item.SubjectID
                    };
                        _context.Ternary.Add(NewItem);
                        _context.SaveChanges();
                }
                return Ok("successfull");
            }
        }


    }
}
