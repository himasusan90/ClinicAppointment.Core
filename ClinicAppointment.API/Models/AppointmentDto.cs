using System;

namespace ClinicAppointment.API.Models
{
    public class AppointmentDto
    {
        public Guid AppointmentId { get; set; }
        public Guid ScheduleId { get; set; }
        public int DoctorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PatientId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Guid Id { get; internal set; }
    }
}
