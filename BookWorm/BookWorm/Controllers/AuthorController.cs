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
    public class AuthorController : Controller
    {
        private eLibraryDBEntities db = new eLibraryDBEntities();

        // GET: Author
        public ActionResult Index()
        {
            var author_Table = db.Author_Table.Include(a => a.Book_Table);
            return View(author_Table.ToList());
        }

        // GET: Author/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author_Table author_Table = db.Author_Table.Find(id);
            if (author_Table == null)
            {
                return HttpNotFound();
            }
            return View(author_Table);
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            ViewBag.Book_ID = new SelectList(db.Book_Table, "Book_ID", "BookName");
            return View();
        }

        // POST: Author/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Author_ID,AuthorName,Book_ID")] Author_Table author_Table)
        {
            if (ModelState.IsValid)
            {
                db.Author_Table.Add(author_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Book_ID = new SelectList(db.Book_Table, "Book_ID", "BookName", author_Table.Book_ID);
            return View(author_Table);
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author_Table author_Table = db.Author_Table.Find(id);
            if (author_Table == null)
            {
                return HttpNotFound();
            }
            ViewBag.Book_ID = new SelectList(db.Book_Table, "Book_ID", "BookName", author_Table.Book_ID);
            return View(author_Table);
        }

        // POST: Author/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Author_ID,AuthorName,Book_ID")] Author_Table author_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Book_ID = new SelectList(db.Book_Table, "Book_ID", "BookName", author_Table.Book_ID);
            return View(author_Table);
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author_Table author_Table = db.Author_Table.Find(id);
            if (author_Table == null)
            {
                return HttpNotFound();
            }
            return View(author_Table);
        }

        // POST: Author/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author_Table author_Table = db.Author_Table.Find(id);
            db.Author_Table.Remove(author_Table);
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
