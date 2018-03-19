using System;
using System.Web.Mvc;

namespace TestSignalR.Controllers
{
    public class HomeController : Controller
    {
   
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}