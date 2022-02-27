using FindCarrier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FindCarrier.Controllers
{
    public class HomeController : Controller
    {
        private FindCarrierDbModel db = new FindCarrierDbModel();

        public ActionResult Index()
        {

            ViewBag.Search = new SelectList(db.Cities, "CityName", "CityName");
            return View();


        }

        
       
        


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}