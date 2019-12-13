using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppEka2019.Models;
using System.Net;
using System.Data.Entity;

namespace WebAppEka2019.Controllers
{
    public class ShippersController : Controller
    {
        // GET: Shippers
        northwindEntities db = new northwindEntities();
        public ActionResult Index()
        {
            var shippers = db.Shippers.Include(x => x.Region);
            return View(shippers.ToList());
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Shippers shipperi = db.Shippers.Find(id);
            if (shipperi == null) return HttpNotFound();
            ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription", shipperi.RegionID);
            return View(shipperi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShipperID, CompanyName, Phone, RegionID")] Shippers shipperi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipperi).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription", shipperi.RegionID);
                return RedirectToAction("Index");
            }
            return View(shipperi);
        }

        public ActionResult Create()
        {
            ViewBag.RegionID = new SelectList(db.Region, "RegionID", "RegionDescription", null);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "ShipperID, CompanyName, Phone, RegionID")] Shippers shipperi)
        {
            if (ModelState.IsValid)
            {
                db.Shippers.Add(shipperi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipperi);
        }

        

        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Shippers shipperi = db.Shippers.Find(id);
            if (shipperi == null) return HttpNotFound();
            return View(shipperi);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shippers shipperi = db.Shippers.Find(id);
            db.Shippers.Remove(shipperi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}