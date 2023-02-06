using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookWorm.Models;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;

namespace BookWorm.Controllers
{
    public class AdminLoginController : Controller
    {
        eLibraryDBEntities db = new eLibraryDBEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin_Table log)
        {
            var user = db.Admin_Table.Where(x => x.UserName == log.UserName && x.Password == log.Password).FirstOrDefault();
            if (user != null)
            {
                Session["UserName"] = user.UserName;
                Session["Admin_ID"] = user.Admin_ID;
                return RedirectToAction("Dashboard");
            }
            else
            {
                return RedirectToAction("Index", "AdminLogin");
            }

        }

        public ActionResult Logout()
        {

            Session.Abandon();
            return RedirectToAction("Index", "AdminLogin");

        }

        public ActionResult Dashboard()
        {
            if (Session["Admin_ID"] != null)
            {
                string id;
                id = Session["Admin_ID"].ToString();
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                int num = int.Parse(id);
                Admin_Table member_Table = db.Admin_Table.Find(num);
                if (member_Table == null)
                {
                    return HttpNotFound();
                }
                return View(member_Table);
            }
            else
            {
                return RedirectToAction("Index", "AdminLogin");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dashboard([Bind(Include = "Admin_ID,UserName,Password,Email,Contact_No")] Member_Table member_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(member_Table);
        }


    }
}