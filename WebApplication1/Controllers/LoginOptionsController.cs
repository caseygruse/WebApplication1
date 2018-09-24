using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginOptionsController : Controller
    {
        // GET: LoginOptions
        public ActionResult SignUp()
        {
            return View();
        }

        //Add new Member
        [HttpPost]
        public ActionResult SignUp(Member member)
        {
            if (ModelState.IsValid)
            {
                Member m = new Member()
                {
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    EmailAddress = member.EmailAddress,
                    Password = member.Password,
                    Username = member.Username
                };
                MemberDB.AddMember(m);
                SessionHelper.LogUserIn(m.Username);
                return RedirectToAction("index", "Home");
            }
            else
            {
                return View();
            }
        }

        //LogOut
        public ActionResult SignOut()
        {
            SessionHelper.LogOut();
            return RedirectToAction("Index", "Home");
        }

        //Create a way to LogIn an existing memeber
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(LogInViewModel log)
        {
            if(ModelState.IsValid && MemberDB.UserExists(log))
            {
                SessionHelper.LogUserIn(log.Username);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.NotValid = "You password or username does not match!";
                return View();
            }
        }
    }
}