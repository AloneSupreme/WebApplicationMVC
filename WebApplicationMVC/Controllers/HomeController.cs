using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(String id)
        {
            ViewBag.CountriesList = new List<string>()
            {
                "India",
                "USA",
                "Canada"
            };
            return View();
        }

        public String GetDetails()
        {
            return "Details";
        }
    }
}