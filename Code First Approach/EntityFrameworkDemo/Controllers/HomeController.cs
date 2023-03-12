using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkDemo.Models;
using System.Data.Entity;
namespace EntityFrameworkDemo.Controllers
{
    public class HomeController : Controller
    {

        StudentContext db = new StudentContext();
        // GET: Home
        public ActionResult Index()
        {

            var data = db.Stu.ToList();

            return View(data);
        }
        //shortcut view

        public ActionResult shortcut()
        {
            var data = db.Stu.ToList();

            return View(data);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]

        public ActionResult Create(StudentInfo s)
        {

            if(ModelState.IsValid == true)
            {

                db.Stu.Add(s);

                int a = db.SaveChanges();

                if(a > 0)
                {
                    TempData["s"] = "<script>alert(\"Successfully Inserted\")</script>";
                    return RedirectToAction("shortcut");
                }

            }

            return View();
        }



        public ActionResult Edit(int id)
        {
            var row = db.Stu.Where(model => model.id == id).FirstOrDefault();



            return View(row);
        }


        [HttpPost]

        public ActionResult Edit(StudentInfo s)
        {
            if(ModelState.IsValid ==true)
            {
                db.Entry(s).State = EntityState.Modified; //use name space  System.Data.Entity.

                int a = db.SaveChanges();

                if(a>0)
                {
                    TempData["s"] = "<script>alert(\"updated\")</script>";

                    return RedirectToAction("shortcut");
                }
            }

            return View();
        }


        public ActionResult Delete(int id)
        {

            var a = db.Stu.Where(model => model.id == id).FirstOrDefault();

            return View(a);

        }

        [HttpPost]

        public ActionResult Delete(StudentInfo s)
        {

            db.Entry(s).State = EntityState.Deleted;

            int a = db.SaveChanges();


            if(a>0)
            {
                TempData["s"] = "<script>alert(\"Deleted\")</script>";

                return RedirectToAction("shortcut");
            }

            return View();
        }


        public ActionResult Details(int id)
        {
            var studentid = db.Stu.Where(model => model.id == id).FirstOrDefault();

            return View(studentid);

        }
    }
}