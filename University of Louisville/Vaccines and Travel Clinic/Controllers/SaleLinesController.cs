using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vaccines_and_Travel_Clinic.DAL;
using Vaccines_and_Travel_Clinic.Models;

namespace Vaccines_and_Travel_Clinic.Controllers
{
    public class SaleLinesController : Controller
    {
        private ClinicContext db = new ClinicContext();

        // GET: SaleLines1
        public ActionResult Index()
        {
            var saleLines = db.SaleLines.Include(s => s.Item).Include(s => s.Sale);
            return View(saleLines.ToList());
        }

        // GET: SaleLines1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleLine saleLine = db.SaleLines.Find(id);
            if (saleLine == null)
            {
                return HttpNotFound();
            }
            return View(saleLine);
        }

        // GET: SaleLines1/Create
        public ActionResult Create()
        {
            ViewBag.ItemID = new SelectList(db.Items, "ID", "Name");
            ViewBag.SaleID = new SelectList(db.Sales, "ID", "ID");
            return View();
        }

        // POST: SaleLines1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SaleID,ItemID,Quantity,Price")] SaleLine saleLine)
        {
            if (ModelState.IsValid)
            {
                db.SaleLines.Add(saleLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemID = new SelectList(db.Items, "ID", "Name", saleLine.ItemID);
            ViewBag.SaleID = new SelectList(db.Sales, "ID", "ID", saleLine.SaleID);
            return View(saleLine);
        }

        // GET: SaleLines1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleLine saleLine = db.SaleLines.Find(id);
            if (saleLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemID = new SelectList(db.Items, "ID", "Name", saleLine.ItemID);
            ViewBag.SaleID = new SelectList(db.Sales, "ID", "ID", saleLine.SaleID);
            return View(saleLine);
        }

        // POST: SaleLines1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SaleID,ItemID,Quantity,Price")] SaleLine saleLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saleLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(db.Items, "ID", "Name", saleLine.ItemID);
            ViewBag.SaleID = new SelectList(db.Sales, "ID", "ID", saleLine.SaleID);
            return View(saleLine);
        }

        // GET: SaleLines1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleLine saleLine = db.SaleLines.Find(id);
            if (saleLine == null)
            {
                return HttpNotFound();
            }
            return View(saleLine);
        }

        // POST: SaleLines1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaleLine saleLine = db.SaleLines.Find(id);
            db.SaleLines.Remove(saleLine);
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