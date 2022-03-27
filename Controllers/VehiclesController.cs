using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FindCarrier.Models;

namespace FindCarrier.Controllers
{
    public class VehiclesController : Controller
    {
        private FindCarrierDbModel db = new FindCarrierDbModel();

        // GET: Vehicles

        public ActionResult Index()
        {
            if (this.User.IsInRole("Transporter"))
            {
                string UserID;
                using (var UsersDb = new ApplicationDbContext())
                {
                    UserID = UsersDb.Users.ToList().Find(item => item.UserName == User.Identity.Name).Id;
                }
                return View(db.Vehicles.ToList().FindAll(item => item.UserId == UserID));


            }

            if (this.User.IsInRole("Admin"))
            {               
                return View(db.Vehicles.ToList());
            }

            return View();
        }

        public ActionResult VList(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporter transporter = db.Transporters.Find(id);
            var userId = transporter.UserId;
            if (transporter == null)
            {
                return HttpNotFound();
            }
            return View(db.Vehicles.ToList().FindAll(item => item.UserId == userId));
        }




        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create(Vehicle vehicle)
        {
            vehicle.bodyTypes = db.BodyTypes.ToList();

            return View(vehicle);
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost([Bind(Include = "VehicleID,VehicleName,VehicleNo,BodyType,LoadCapacity,Amount,UserId")] Vehicle vehicle)
        {
            
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    vehicle.UserId = db.Users.ToList().Find(item => item.UserName == User.Identity.Name).Id;
                }
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            vehicle.bodyTypes = db.BodyTypes.ToList();

            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(Vehicle vehicle)
        {
            vehicle.bodyTypes = db.BodyTypes.ToList();

            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost([Bind(Include = "VehicleID,VehicleName,VehicleNo,BodyType,LoadCapacity,Amount,VehicleImage,UserId")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
               
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.TransporterID = new SelectList(db.Transporters, "TransporterID", "TransportName", vehicle.TransporterID);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
