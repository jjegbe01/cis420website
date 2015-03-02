using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Vaccines_and_Travel_Clinic.DAL;
using Vaccines_and_Travel_Clinic.Models;

namespace Vaccines_and_Travel_Clinic.Controllers
{
    public class AppointmentController : Controller
    {
        private ClinicContext db = new ClinicContext();

        // GET: Items
        public ActionResult Index()
        {
            return View(db.Appointment.ToList());
        }

        public ActionResult Summary()
        {
            return View("Summary");
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointment.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointmentId,Email,DateTime,Note")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointment.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(appointment);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointment.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentId,Email,DateTime,Note")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointment.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointment.Find(id);
            db.Appointment.Remove(appointment);
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



        private static void SendAppointmentEmail(Appointment model)
        {
            var emailBody = new StringBuilder();
            var message = new MailMessage();

            var emailFrom = ConfigurationManager.AppSettings["AppointmentEmailFrom"];
            var emailTo = ConfigurationManager.AppSettings["AppointmentEmailTo"];
            var emailServer = ConfigurationManager.AppSettings["AppointmentSmtpServer"];

            message.From = new MailAddress(emailFrom);
            message.To.Add(emailTo);

            message.IsBodyHtml = false;

            message.Subject = "Appointment Message";
            emailBody.AppendLine("Date: " + model.DateTime);
            emailBody.AppendLine("User: " + model.Email);
            emailBody.AppendLine("Note:");
            emailBody.AppendLine(model.Note);

            message.Body = emailBody.ToString();

            var client = new SmtpClient(emailServer);
            client.Send(message);
        }
    }
}