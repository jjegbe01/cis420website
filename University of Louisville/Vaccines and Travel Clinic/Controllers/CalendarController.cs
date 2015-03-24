using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.Entity;
using DHTMLX.Helpers;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using DHTMLX.Common;


using Vaccines_and_Travel_Clinic.Models;

namespace Vaccines_and_Travel_Clinic.Controllers
{
    public class CalendarController : Controller
    {
        

        private CalendarContext db = new CalendarContext();

        // GET: Calendar
        public ActionResult Index()
        {
            var scheduler = new DHXScheduler(this);
            
            scheduler.Skin = DHXScheduler.Skins.Flat;
            scheduler.Config.drag_resize = false;
            scheduler.Config.drag_move = false;
            scheduler.Config.drag_in = false;
            scheduler.Config.drag_out = false;
            scheduler.Config.limit_drag_out = true;
            scheduler.Config.limit_time_select = true;
            scheduler.Config.collision_limit = 2;
            scheduler.Config.dblclick_create = true;
            scheduler.Config.drag_create = false;
            scheduler.Config.event_duration = 30;
            scheduler.Config.auto_end_date = true;  
            scheduler.Config.first_hour = 8;
            scheduler.Config.last_hour = 17;
             
           
            
            scheduler.EnableDynamicLoading(SchedulerDataLoader.DynamicalLoadingMode.Month);

            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;

            
            return View(scheduler);
        }

        public ContentResult Data()
        {

            var apps = db.Appointments.ToList();
            return new SchedulerAjaxData(apps);
        }

        public ActionResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);

            try
            {
                var changedEvent = DHXEventsHelper.Bind<Calendar>(actionValues);
                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        db.Appointments.Add(changedEvent);
                        break;
                    case DataActionTypes.Delete:
                        db.Entry(changedEvent).State = EntityState.Deleted;
                        break;
                    default:// "update"  
                        db.Entry(changedEvent).State = EntityState.Modified;
                        break;
                }
                db.SaveChanges();
                action.TargetId = changedEvent.Id;
            }
            catch (Exception )
            {
                action.Type = DataActionTypes.Error;
            }

            return (new AjaxSaveResponse(action));
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