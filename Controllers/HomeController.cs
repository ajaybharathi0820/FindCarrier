using FindCarrier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindCarrier.Controllers
{
    public class HomeController : Controller
    {
        private FindCarrierDbModel db = new FindCarrierDbModel();

        public ActionResult Index()
        {
           
                ViewBag.CityID = new SelectList(db.Cities, "CityID", "CityName");
                return View();
           
            
        }

        public ActionResult TList()
        {
            using(var database=new FindCarrierDbModel())
            {
                List<Transporter> transporter = database.Transporters.ToList();
                return View(transporter);
            }
            
          
        }

        public ActionResult Dashboard()
        {
            using (var db = new FindCarrierDbModel() )
            {
                var count = db.Transporters.SqlQuery("select * from Transporter").ToList();
            }           

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}