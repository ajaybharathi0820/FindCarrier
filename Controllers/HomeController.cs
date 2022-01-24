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
        public ActionResult Index()
        {
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