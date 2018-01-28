using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TestFullDatabase.Models;

namespace TestFullDatabase.Controllers
{
    [Route("Api/Login")]
    public class LoginController : Controller
    {

        private readonly SchoolContext _context;
     

        public LoginController(SchoolContext context)
        {
            _context = context;
           
        }



        [HttpGet("{Email}/{Password}", Name = "Login")]
        public IActionResult CheckLogin(string Email, string Password)
        {
           
            
            if (!_context.AspNetUsers.Where(pswr => pswr.Email == Email).Any())
            {
                return Json("Wrong Email");
            }

            else if (_context.AspNetUsers.FirstOrDefault(pswr => pswr.Email == Email).Password == Password)//
            {
                var first = _context.AspNetUsers.Where(t => t.Email == Email);

                if (first.Where(t => t.Password == Password).Any())
                {           
                       var Pid = first.First(t => t.Password == Password).Id;
                   

                    if (_context.Students.Where(t => t.UserId == Pid).Any())
                    {
                        var x = _context.Students.Where(t=>t.UserId==Pid).Select(t => new { t.UserId, t.User.Name, t.User.Email, t.User.Image, t.AdmissionNumber, t.AdmissionDate, t.StdClass.ClassRoomName, t.ClassRoomId ,t.User.Role.Id,RoleName=t.User.Role.Name});

                        return Json(x);  
                    }

                    else if (_context.Teachers.Where(t => t.UserId == Pid).Any())
                    {
                         var x = _context.Teachers.Where(t => t.UserId == Pid).Select(t => new { t.UserId, t.User.Name, t.User.Email, t.User.Image, t.TeacherGrade, t.TchrClass.ClassRoomName, t.ClassRoomId, t.User.PhoneNumber, t.User.Role.Id, RoleName = t.User.Role.Name });

                         return Json(x);
                    }

                    else if (_context.Parents.Where(t => t.UserId == Pid).Any())
                    {                      
                        var x = _context.Parents.Where(t => t.UserId == Pid).Select(t => new { t.UserId, t.User.Name, t.User.Email, t.User.Image,t.User.PhoneNumber, t.User.Role.Id, RoleName = t.User.Role.Name ,StudentName=t.Student.User.Name,StudentId=t.StudentId});

                        return Json(x);
                      
                    }

                    else if (_context.Principals.Where(t => t.UserId == Pid).Any())
                    {
                        var x = _context.Principals.Where(t => t.UserId == Pid).Select(t => new { t.UserId, t.User.Name, t.User.Email, t.User.Image, t.User.PhoneNumber ,t.PrincipalGrade, t.User.Role.Id, RoleName = t.User.Role.Name });

                        return Json(x);                      
                    }

                    //else if (_context.Admin.Where(t => t.UserId == Pid).Any())
                    //{


                    //    return Json(_context.Admin.Where(t => t.P_Id == Pid).Select(u => new { u.P_Id, u.Role_Id, u.RoleDetail.RoleName, u.Name, u.TpNumber, u.Email, u.PicUrl }));

                    //}
                    else
                    {
                        return Json(Pid);
                    }
                }
                else
                {
                    return Json("No Exit");
                }

            }

            else
            {

                return Json("Wrong Password");
            }

        }

    }
}
