using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookWorm.Models;

namespace BookWorm.Controllers
{
    public class Book_TableController : Controller
    {
        private eLibraryDBEntities db = new eLibraryDBEntities();

        // GET: Book_Table
        public ActionResult Index()
        {
            return View(db.Book_Table.ToList());
        }

        // GET: Book_Table/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Table book_Table = db.Book_Table.Find(id);
            if (book_Table == null)
            {
                return HttpNotFound();
            }
            return View(book_Table);
        }

        // GET: Book_Table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book_Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Book_ID,BookName,AuthorName,PublisherName,Language,Edition,BookCost,Actual_Stock,Current_Stock")] Book_Table book_Table)
        {
            if (ModelState.IsValid)
            {
                db.Book_Table.Add(book_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book_Table);
        }

        // GET: Book_Table/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Table book_Table = db.Book_Table.Find(id);
            if (book_Table == null)
            {
                return HttpNotFound();
            }
            return View(book_Table);
        }

        // POST: Book_Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Book_ID,BookName,AuthorName,PublisherName,Language,Edition,BookCost,Actual_Stock,Current_Stock")] Book_Table book_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book_Table);
        }

        // GET: Book_Table/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book_Table book_Table = db.Book_Table.Find(id);
            if (book_Table == null)
            {
                return HttpNotFound();
            }
            return View(book_Table);
        }

        // POST: Book_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book_Table book_Table = db.Book_Table.Find(id);
            db.Book_Table.Remove(book_Table);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Request(int id)
        {
            try
            {
                Defaulter_Table val = new Defaulter_Table();
                val.Member_ID = ((int)Session["Member_ID"]);
                val.Contact_No = (string)Session["Contact_No"];
                val.MemberName = (string)Session["UserName"];
                val.Book_ID = id;
                db.Defaulter_Table.Add(val);
                db.SaveChanges();
                ModelState.Clear();
                ViewBag.SuccessMessage = "Request send";
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
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
