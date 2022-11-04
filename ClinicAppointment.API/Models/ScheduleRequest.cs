using System;
using System.Collections.Generic;

namespace ClinicAppointment.API.Models
{
    public class ScheduleRequest
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        private List<Guid> AppointmentIds { get; set; } = new List<Guid>();
    }
}