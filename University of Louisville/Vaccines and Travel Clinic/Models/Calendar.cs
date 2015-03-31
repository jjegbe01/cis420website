using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using DHTMLX.Scheduler;

namespace Vaccines_and_Travel_Clinic.Models
{
    public class Calendar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DHXJson(Alias = "id")]
        public int Id { get; set; }

        [DHXJson(Alias = "text")]
        public string Description { get; set; }

        [DHXJson(Alias = "start_date")]
        public DateTime StartDate { get; set; }

        [DHXJson(Alias = "end_date")]
        public DateTime EndDate { get; set; }

        [DHXJson(Alias = "room")]
        public string Room { get; set; }

        [DHXJson(Alias = "patient_id")]
        public int patientID { get; set; }
    }
}