using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Vaccines_and_Travel_Clinic.Models
{
    public class CalendarContext : DbContext
    {
        public CalendarContext() : base()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CalendarContext>());
        }
        public System.Data.Entity.DbSet<Vaccines_and_Travel_Clinic.Models.Calendar> Appointments { get; set; }
    }
}