using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vaccines_and_Travel_Clinic.Models
{
    public class Appointment
    {
        /// <summary>
        /// Primary key of the feedback entry.
        /// </summary>
        public virtual int AppointmentId { get; set; }

        /// <summary>
        /// The user who created the feedback entry.
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        /// The date in which the feedback was created.
        /// </summary>
        [Required]
        public virtual DateTime DateTime { get; set; }

        /// <summary>
        /// The feedback message for this feedback entry.
        /// </summary>
        [Required]
        [StringLength(2048, ErrorMessage = "The maximum note length is 2048.")]
        public virtual string Note { get; set; }
    }
}