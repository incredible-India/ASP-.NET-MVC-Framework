using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelFirstApprochDemo.Models;

namespace ModelFirstApprochDemo.Controllers
{
    public class HomeController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.StudentSEAs.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentSEA studentSEA = db.StudentSEAs.Find(id);
            if (studentSEA == null)
            {
                return HttpNotFound();
            }
            return View(studentSEA);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,Age")] StudentSEA studentSEA)
        {
            if (ModelState.IsValid)
            {
                db.StudentSEAs.Add(studentSEA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentSEA);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentSEA studentSEA = db.StudentSEAs.Find(id);
            if (studentSEA == null)
            {
                return HttpNotFound();
            }
            return View(studentSEA);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,Age")] StudentSEA studentSEA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentSEA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentSEA);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentSEA studentSEA = db.StudentSEAs.Find(id);
            if (studentSEA == null)
            {
                return HttpNotFound();
            }
            return View(studentSEA);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentSEA studentSEA = db.StudentSEAs.Find(id);
            db.StudentSEAs.Remove(studentSEA);
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
