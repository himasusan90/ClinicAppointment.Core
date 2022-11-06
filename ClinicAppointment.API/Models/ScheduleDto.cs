using System;
using System.Collections.Generic;

namespace ClinicAppointment.API.Models
{
    public class ScheduleDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public List<Guid> AppointmentIds { get; set; } = new List<Guid>();
    }
}
