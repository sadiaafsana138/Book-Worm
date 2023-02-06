using BookWorm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BookWorm.Controllers
{
    public class CharityFund_TableController : Controller
    {
        private eLibraryDBEntities db = new eLibraryDBEntities();
        // GET: CharityFund_Table
        public ActionResult Index()
        {
            return View(db.CharityFund_Table.ToList());
        }

        // GET: CharityFund_Table/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharityFund_Table charityFund_Table = db.CharityFund_Table.Find(id);
            //CharityFund_Table charityFund_Table = db.CharityFund_Table.Find(id);
            if (charityFund_Table == null)
            {
                return HttpNotFound();
            }
            return View(charityFund_Table);
        }

        // GET: CharityFund_Table/Donate
        public ActionResult Donate()
        {
            return View();
        }

        // POST: CharityFund_Table/Donate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Donate([Bind(Include = "Contributor_ID,ContributorName,Fund_ID,Email,Contact_No,Amount")] Contributor_Table contributor_Table)
        {
            if (ModelState.IsValid)
            {
                db.Contributor_Table.Add(contributor_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // ViewBag.SuccessMessage = "Thank you for your Donation";

            return View(contributor_Table);
        }









        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }





    }
}