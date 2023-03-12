using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Cookiesinfo.Models;

namespace Cookiesinfo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            HttpCookie c = new HttpCookie("username");

            c.Value = "hello";

            HttpContext.Response.Cookies.Add(c);

            return View();
        }

        public ActionResult Coo()
        {
            if(Request.Cookies["username"] != null)
            {
                return Content($"Cookie is set {Request.Cookies["username"].Value}");
            }
            else
            {
                return RedirectToAction("Index");
            }
          
        }


        //student image

        STUDENTINFOEntities db = new STUDENTINFOEntities();

        public ActionResult Stulist()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        

        [HttpPost]
        public ActionResult Create(stuimg s)
        {
            string fileName = Path.GetFileNameWithoutExtension(s.myimg.FileName);

            string ext = Path.GetExtension(s.myimg.FileName);

            fileName = fileName  + ext;

            s.img_path = "~/image/" + fileName;

            fileName = Path.Combine(Server.MapPath("~/image/"), fileName);

            s.myimg.SaveAs(fileName);

            db.stuimgs.Add(s);

            db.SaveChanges();

            return RedirectToAction("Stulist");


            
        }
    }
}