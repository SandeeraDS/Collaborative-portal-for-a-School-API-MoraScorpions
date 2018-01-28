
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFullDatabase.Models;

namespace TestFullDatabase.Controllers
{

    [Route("Api/PrincipalDetails")]
    public class PrincipalController : Controller
    {

        public SchoolContext _context;
        public PrincipalController(SchoolContext context)
        {
            _context = context;
        }

        //get All the Principal
        [HttpGet]
        public IEnumerable<Principals> GetPrincipal()
        {
            return _context.Principals;
        }
        //add a principal
        [HttpPost]
        public IActionResult AddPrincipal([FromBody] Principals item)
        {
            if (item == null)
            {
                return BadRequest("Empty");
            }

            else if (_context.Principals.Where(t => t.User.RoleId == item.User.RoleId).Any())
            {
                return BadRequest("Already Have");
            }
            else if (_context.Principals.Where(t => t.User.Email == item.User.Email).Any())
                {
                    return BadRequest("Already Have Email");
                }

            else
            {
                _context.Principals.Add(item);
                _context.SaveChanges();
                return Ok("Successful");
            }
        }

        //Get By Id
        [HttpGet("{id}", Name = "GetPrincipal")]
        public IActionResult GetById(string id)
        {
            var item = _context.Principals.FirstOrDefault(t => t.UserId == id);
            if (item == null)
            {
                return BadRequest("Unsuccessful");
            }
            return new ObjectResult(item);
        }

    }
}
