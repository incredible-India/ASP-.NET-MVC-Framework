using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalImgUpload.Models;
using System.IO;
namespace FinalImgUpload.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        studentEntities db = new studentEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(student s)
        {


            string filename = Path.GetFileNameWithoutExtension(s.simg.FileName);

            string ext = Path.GetExtension(s.simg.FileName);

            filename = filename + ext;


            s.img = "~/image/" + filename;

            filename = Path.Combine(Server.MapPath("~/image/"), filename);

            s.simg.SaveAs(filename);

            db.students.Add(s);

            int a = db.SaveChanges();

            if(a>0)
            {
                TempData["s"] = "<script>alert(\"File Uploaded\")</script>";

            }else
            {
                TempData["s"] = "<script>alert(\"File Filed\")</script>";

            }


            return View();

        }


        public ActionResult Stulist()
        {

            var data = db.students.ToList();
            return View(data);
        }
    }
}