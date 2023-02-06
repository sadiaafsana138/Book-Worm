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
    public class PublisherController : Controller
    {
        private eLibraryDBEntities db = new eLibraryDBEntities();

        // GET: Publisher
        public ActionResult Index()
        {
            var publisher_Table = db.Publisher_Table.Include(p => p.Book_Table);
            return View(publisher_Table.ToList());
        }

        // GET: Publisher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher_Table publisher_Table = db.Publisher_Table.Find(id);
            if (publisher_Table == null)
            {
                return HttpNotFound();
            }
            return View(publisher_Table);
        }

        // GET: Publisher/Create
        public ActionResult Create()
        {
            ViewBag.Book_ID = new SelectList(db.Book_Table, "Book_ID", "BookName");
            return View();
        }

        // POST: Publisher/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Publisher_ID,PublisherName,Book_ID")] Publisher_Table publisher_Table)
        {
            if (ModelState.IsValid)
            {
                db.Publisher_Table.Add(publisher_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Book_ID = new SelectList(db.Book_Table, "Book_ID", "BookName", publisher_Table.Book_ID);
            return View(publisher_Table);
        }

        // GET: Publisher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher_Table publisher_Table = db.Publisher_Table.Find(id);
            if (publisher_Table == null)
            {
                return HttpNotFound();
            }
            ViewBag.Book_ID = new SelectList(db.Book_Table, "Book_ID", "BookName", publisher_Table.Book_ID);
            return View(publisher_Table);
        }

        // POST: Publisher/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Publisher_ID,PublisherName,Book_ID")] Publisher_Table publisher_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publisher_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Book_ID = new SelectList(db.Book_Table, "Book_ID", "BookName", publisher_Table.Book_ID);
            return View(publisher_Table);
        }

        // GET: Publisher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publisher_Table publisher_Table = db.Publisher_Table.Find(id);
            if (publisher_Table == null)
            {
                return HttpNotFound();
            }
            return View(publisher_Table);
        }

        // POST: Publisher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publisher_Table publisher_Table = db.Publisher_Table.Find(id);
            db.Publisher_Table.Remove(publisher_Table);
            db.SaveChanges();
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
