using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        STUDENTINFOEntities db = new STUDENTINFOEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.StudentInfoes.ToList();
            return View(data);
        }


        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Create(StudentInfo s)
        {

            if(ModelState.IsValid)
            {
                db.StudentInfoes.Add(s);
                int a = db.SaveChanges();

                if(a>0)
                {
                    TempData["s"] = "<p style=color:green>Data Inserted </p>"; 
                    return RedirectToAction("Index");
                }
            }

            return View();

        }



        public ActionResult Edit(int id)
        {
            var sid = db.StudentInfoes.Where(model => model.id == id).FirstOrDefault();

                return View(sid);
        }


        [HttpPost]

        public ActionResult Edit(StudentInfo s)
        {

            if (ModelState.IsValid)
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Modified;
                int a = db.SaveChanges();

                if (a > 0)
                {
                    TempData["s"] = "<p style=color:green>Data Edited</p>";
                    return RedirectToAction("Index");
                }
            }

            return View();

        }


        public ActionResult Delete(int id)
        {
            var sid = db.StudentInfoes.Where(model => model.id == id).FirstOrDefault();

            return View(sid);
        }


        [HttpPost]

        public ActionResult Delete(StudentInfo s)
        {

            if (ModelState.IsValid)
            {
                db.Entry(s).State = System.Data.Entity.EntityState.Deleted;
                int a = db.SaveChanges();

                if (a > 0)
                {
                    TempData["s"] = "<p style=color:green>Data Deleted</p>";
                    return RedirectToAction("Index");
                }
            }

            return View();

        }


        public ActionResult Details(int id)
        {
            var sid = db.StudentInfoes.Where(model => model.id == id).FirstOrDefault();

            return View(sid);
        }
    }
}