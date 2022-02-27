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
    public class BodyTypesController : Controller
    {
        private FindCarrierDbModel db = new FindCarrierDbModel();

        // GET: BodyTypes
        public ActionResult Index()
        {
            return View(db.BodyTypes.ToList());
        }

        // GET: BodyTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodyType bodyType = db.BodyTypes.Find(id);
            if (bodyType == null)
            {
                return HttpNotFound();
            }
            return View(bodyType);
        }

        // GET: BodyTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BodyTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeID,VehicleType")] BodyType bodyType)
        {
            if (ModelState.IsValid)
            {
                db.BodyTypes.Add(bodyType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bodyType);
        }

        // GET: BodyTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodyType bodyType = db.BodyTypes.Find(id);
            if (bodyType == null)
            {
                return HttpNotFound();
            }
            return View(bodyType);
        }

        // POST: BodyTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeID,VehicleType")] BodyType bodyType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bodyType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bodyType);
        }

        // GET: BodyTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodyType bodyType = db.BodyTypes.Find(id);
            if (bodyType == null)
            {
                return HttpNotFound();
            }
            return View(bodyType);
        }

        // POST: BodyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BodyType bodyType = db.BodyTypes.Find(id);
            db.BodyTypes.Remove(bodyType);
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
