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
    public class Member_TableController : Controller
    {
        private eLibraryDBEntities db = new eLibraryDBEntities();

        // GET: Member_Table
        public ActionResult Index()
        {
            return View(db.Member_Table.ToList());
        }

        // GET: Member_Table/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member_Table member_Table = db.Member_Table.Find(id);
            if (member_Table == null)
            {
                return HttpNotFound();
            }
            return View(member_Table);
        }

        // GET: Member_Table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Member_Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Member_ID,FullName,UserName,Password,Contact_No,City,Area,account_status,Email")] Member_Table member_Table)
        {
            if (ModelState.IsValid)
            {
                db.Member_Table.Add(member_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member_Table);
        }

        // GET: Member_Table/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member_Table member_Table = db.Member_Table.Find(id);
            if (member_Table == null)
            {
                return HttpNotFound();
            }
            return View(member_Table);
        }

        // POST: Member_Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Member_ID,FullName,UserName,Password,Contact_No,City,Area,account_status,Email")] Member_Table member_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member_Table);
        }

        // GET: Member_Table/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member_Table member_Table = db.Member_Table.Find(id);
            if (member_Table == null)
            {
                return HttpNotFound();
            }
            return View(member_Table);
        }

        // POST: Member_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member_Table member_Table = db.Member_Table.Find(id);
            db.Member_Table.Remove(member_Table);
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
