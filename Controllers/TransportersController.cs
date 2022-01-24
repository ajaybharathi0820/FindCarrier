using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FindCarrier.Models;

namespace FindCarrier.Controllers
{
    public class TransportersController : Controller
    {
        private FindCarrierDbModel db = new FindCarrierDbModel();

        // GET: Transporters
        public ActionResult Index()
        {
            return View(db.Transporters.ToList());
        }

        // GET: Transporters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporter transporter = db.Transporters.Find(id);
            if (transporter == null)
            {
                return HttpNotFound();
            }
            return View(transporter);
        }

        // GET: Transporters/Create
        public ActionResult Create(Transporter transporter)
        {
            transporter.cities = db.Cities.ToList();
            transporter.states = db.States.ToList();
            return View(transporter);
        }

        // POST: Transporters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost([Bind(Include = "TransporterID,TransportName,OwnerName,ContactNo,Address,City,State,UserId")] Transporter transporter)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    transporter.UserId = db.Users.ToList().Find(item => item.UserName == User.Identity.Name).Id;
                }
                db.Transporters.Add(transporter);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            transporter.cities = db.Cities.ToList();
            transporter.states = db.States.ToList();
            return View(transporter);
        }

        // GET: Transporters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporter transporter = db.Transporters.Find(id);
            if (transporter == null)
            {
                return HttpNotFound();
            }
            return View(transporter);
        }

        // POST: Transporters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransporterID,TransportName,OwnerName,ContactNo,Address,City,State")] Transporter transporter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transporter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transporter);
        }

        // GET: Transporters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporter transporter = db.Transporters.Find(id);
            if (transporter == null)
            {
                return HttpNotFound();
            }
            return View(transporter);
        }

        // POST: Transporters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transporter transporter = db.Transporters.Find(id);
            db.Transporters.Remove(transporter);
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
