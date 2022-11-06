using System;

namespace ClinicAppointment.API.Models
{
    public class DeleteAppointmentRequest
    {
        public Guid ScheduleId { get; set; }
        public Guid AppointmentId { get; set; }
    }
}
