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

        
        

        
        // GET: Home
        public ActionResult Index()
        {

           

            

            ViewData["hello"] = "message";
            var a = new List<string>()
            {
                "Himanshu" ,"Sahil","Singh"
            };

            ViewData["a"] = a;

            Emp i = new Emp();
            i.name = "banmanus";

            ViewData["op"] = i;

            TempData["g"] = "hello from index";

            Session["o"] = "hello i am the seesion from index page"; 
            return View();
        }

        public string show() 
        {

            return $"hello world {TempData["g"]} session is {Session["o"]}";

        }

        public string stu(int id)
        {
           // TempData.Keep();
            return $"the id is {id}";
        }

        public ActionResult about()
        {
           // TempData.Keep();
            return Json(new { id = 1, value = TempData["g"], session = Session["o"]}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            Emp hi = new Emp();

            hi.name = "himanshu Sjarm";
            hi.last = "banmsi";
            return View(hi);
        }

        [HttpPost]

        public ActionResult Contact(string fname,string lname)
        {
            if(fname.Equals("") == true)
            {
                ModelState.AddModelError("fname", "First name wont be empty");

            }else if(lname.Equals("") == true)
                    {

                ModelState.AddModelError("lname", "First name wont be empty");
            }else
            {
                ViewData["s"] = "<script> alert(\"hurray\") </script>";
                ModelState.Clear();
            }
            return View();
        }


        public ActionResult Student()
        {

            stu st = new stu();
            
            
            return View(st);

        }

        [HttpPost]

        public ActionResult Student(stu st)
        {
            return View();
        }
    }
}