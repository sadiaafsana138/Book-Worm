using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookWorm.Models;

namespace BookWorm.Controllers
{
    public class SignupController : Controller
    {
       [HttpGet]
        public ActionResult Index(int id=0)
        {
            Member_Table userTable = new Member_Table();
            return View(userTable);
        }
        [HttpPost]
        public ActionResult Index(Member_Table userModel)
        {
            using(eLibraryDBEntities dbModel =new eLibraryDBEntities())
            {
                if (dbModel.Member_Table.Any(x => x.UserName == userModel.UserName))
                {
                    ViewBag.DuplicateMessage = "Username already exist.";
                    return View("Index", userModel);
                }
                
                {
                   
                    dbModel.Member_Table.Add(userModel);
                   
                    dbModel.SaveChanges();
                }
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Sign Up SuccessFul";
            return View("Index", new Member_Table());
        }
    }
}