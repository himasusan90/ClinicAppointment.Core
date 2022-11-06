using System;

namespace ClinicAppointment.API.Models
{
    public class AppointmentRequest
    {
    
        public Guid ScheduleId { get; set; }
        public int DoctorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PatientId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndDTime { get; set; }
    }
}
