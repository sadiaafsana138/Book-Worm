using BookWorm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookWorm.Controllers
{
    public class BookIssuingController : Controller
    {
        private eLibraryDBEntities db = new eLibraryDBEntities();
        // GET: BookIssuing
        public ActionResult Index()
        {
            return View(db.Defaulter_Table.ToList());
        }
        public ActionResult IssueBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IssueBook([Bind(Include = "IssuedBook_ID,Member_ID,Book_ID,IssuedDate,DueDate")] IssuedBook_Table Issue_Table)
        {
            if (ModelState.IsValid)
            {
                db.IssuedBook_Table.Add(Issue_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

        }
    }
}