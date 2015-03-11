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
    [Authorize(Roles = "Admin, CanModifyInventory, CanViewInventory")]
    public class OrderLinesController : Controller
    {
        private ClinicContext db = new ClinicContext();

        // GET: OrderLines1
        public ActionResult Index()
        {
            var orderLines = db.OrderLines.Include(o => o.Item).Include(o => o.Order);
            return View(orderLines.ToList());
        }

        // GET: OrderLines1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLine orderLine = db.OrderLines.Find(id);
            if (orderLine == null)
            {
                return HttpNotFound();
            }
            return View(orderLine);
        }

        // GET: OrderLines1/Create
        public ActionResult Create()
        {
            ViewBag.ItemID = new SelectList(db.Items, "ID", "Name");
            ViewBag.OrderID = new SelectList(db.Orders, "ID", "ID");
            return View();
        }

        // POST: OrderLines1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OrderID,ItemID,Quantity,Price")] OrderLine orderLine)
        {
            if (ModelState.IsValid)
            {
                db.OrderLines.Add(orderLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemID = new SelectList(db.Items, "ID", "Name", orderLine.ItemID);
            ViewBag.OrderID = new SelectList(db.Orders, "ID", "ID", orderLine.OrderID);
            return View(orderLine);
        }

        // GET: OrderLines1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLine orderLine = db.OrderLines.Find(id);
            if (orderLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemID = new SelectList(db.Items, "ID", "Name", orderLine.ItemID);
            ViewBag.OrderID = new SelectList(db.Orders, "ID", "ID", orderLine.OrderID);
            return View(orderLine);
        }

        // POST: OrderLines1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OrderID,ItemID,Quantity,Price")] OrderLine orderLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(db.Items, "ID", "Name", orderLine.ItemID);
            ViewBag.OrderID = new SelectList(db.Orders, "ID", "ID", orderLine.OrderID);
            return View(orderLine);
        }

        // GET: OrderLines1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderLine orderLine = db.OrderLines.Find(id);
            if (orderLine == null)
            {
                return HttpNotFound();
            }
            return View(orderLine);
        }

        // POST: OrderLines1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderLine orderLine = db.OrderLines.Find(id);
            db.OrderLines.Remove(orderLine);
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
