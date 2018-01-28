using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestFullDatabase.Models;

namespace TestFullDatabase.Controllers
{
    //Get all the persons
    [Route("Api/[Controller]")]
    public class PersonDetailsController : Controller
    {
        public SchoolContext _context;

        public PersonDetailsController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<AspNetUsers> GetPersons()
        {
            return _context.AspNetUsers;
        }

        //add a profile pictuture
        [Route("AddPic")]
        [HttpPost]
        public IActionResult AddProfilePic([FromBody]AspNetUsers Details)
        {
            AspNetUsers PDetails = _context.AspNetUsers.FirstOrDefault(t => t.Id == Details.Id);

            if (PDetails == null)
            {

                return BadRequest("null");
            }
            else
            {
                PDetails.Image = Details.Image;
                _context.AspNetUsers.Update(PDetails);
                _context.SaveChanges();

                return Json("Successful");
            }
        }
    }
}
