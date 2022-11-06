using System;
using System.Collections.Generic;

namespace ClinicAppointment.API.Models
{
    public class ScheduleRequest
    {
        public DateTime Date { get; set; }

        private List<Guid> AppointmentIds { get; set; } = new List<Guid>();
    }
}