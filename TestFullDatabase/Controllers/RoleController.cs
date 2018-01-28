using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFullDatabase.Models;

namespace TestFullDatabase.Controllers
{
    [Route("Api/Roles")]
    public class RoleController : Controller
    {

        public SchoolContext _context;

        public RoleController(SchoolContext context)
        {
            _context = context;
        }


        //Get All roles
        [HttpGet]
        public IEnumerable<AspNetRoles> GetAll()
        {
            return _context.AspNetRoles;
        }

        ////Add a role
        //[HttpPost]
        //public IActionResult AddRole([FromBody] AspNetRoles item)
        //{
        //    if (item == null)
        //    {
        //        return BadRequest("Unsuccessful");
        //    }

        //    else if (_context.Role.Where(t => t.RoleName == item.RoleName).Any())
        //    {

        //        return BadRequest("Already Have");
        //    }
        //    else
        //    {
        //        _context.Role.Add(item);
        //        _context.SaveChanges();

        //        return Ok("Successful");
        //    }
        //}
    }
}
