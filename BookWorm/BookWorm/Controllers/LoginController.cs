using System.Collections.Generic;
using System.Linq;
using BookWorm.Models;
using System.Web.Mvc;
using System.Runtime.Remoting.Contexts;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Net;

namespace BookWorm.Controllers
{

    public class LoginController : Controller
    {
        eLibraryDBEntities db = new eLibraryDBEntities();

        [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Index(Member_Table log)
        {
           
            
            Member_Table user = db.Member_Table.Where(x => x.UserName == log.UserName && x.Password == log.Password).FirstOrDefault();
            if(user !=null)
            {
       
                Session["UserName"] = user.UserName;
                Session["Password"] = user.Password;
                Session["Member_ID"] = user.Member_ID;
                Session["FullName"] = user.FullName;
                Session["Contact_No"] = user.Contact_No;
                return RedirectToAction("Dashboard");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
            
        }

        public ActionResult Logout()
        {

            Session.Abandon();
            return RedirectToAction("Index", "Login");

        }

        public ActionResult Dashboard()
        {
            if (Session["UserName"] != null)
            {
                string id;
                id = Session["Member_ID"].ToString();
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                int num = int.Parse(id);
                Member_Table member_Table = db.Member_Table.Find(num);
                if (member_Table == null)
                {
                    return HttpNotFound();
                }
                return View(member_Table);

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dashboard([Bind(Include = "Member_ID,FullName,UserName,Password,Contact_No,City,Area,account_status,Email")] Member_Table member_Table)
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