using System;

namespace ClinicAppointment.API.Models
{
    public class GetByIdAppointmentRequest
    {
        public Guid ScheduleId { get; set; }
        public Guid AppointmentId { get; set; }
    }
}
